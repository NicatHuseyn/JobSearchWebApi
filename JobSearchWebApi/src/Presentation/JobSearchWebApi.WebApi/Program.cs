
using FluentValidation.AspNetCore;
using JobSearchWebApi.Application;
using JobSearchWebApi.Application.Features.Commands.CategoryCommand.CreateCategory;
using JobSearchWebApi.Application.Features.Commands.CompanyCommand.CreateCompany;
using JobSearchWebApi.Application.Validators.IndustryValidator;
using JobSearchWebApi.Application.Validators.JobValidator;
using JobSearchWebApi.Infrastructure;
using JobSearchWebApi.Infrastructure.Filters;
using JobSearchWebApi.Persistence;
using JobSearchWebApi.Persistence.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace JobSearchWebApi.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            #region My Services
            builder.Services.AddPersistenceService();
            builder.Services.AddApplicationService();
            builder.Services.AddInfrastructureService();
            #endregion

            builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
            {
                policy.WithOrigins("http://localhost:5173", "https://localhost:5173").AllowAnyHeader().AllowAnyMethod();
            }));

            builder.Services.AddControllers(option=>option.Filters.Add<ValidationFilter>())
                .AddFluentValidation(fv=>fv.RegisterValidatorsFromAssemblyContaining<CreateIndustryValidator>())
                .AddFluentValidation(fv=>fv.RegisterValidatorsFromAssemblyContaining<CreateJobValidator>())
                .AddFluentValidation(fv=>fv.RegisterValidatorsFromAssemblyContaining<CreateCompanyCommandRequest>())
                .AddFluentValidation(fv=>fv.RegisterValidatorsFromAssemblyContaining<CreateCategoryCommandRequest>())
                .ConfigureApiBehaviorOptions(options=>options.SuppressMapClientErrors = true);


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer("Admin",options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidAudience = builder.Configuration["Token:Auidence"],
                        ValidIssuer = builder.Configuration["Token:Issure"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"]))
                    };
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors();

            app.UseHttpsRedirection();


            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
