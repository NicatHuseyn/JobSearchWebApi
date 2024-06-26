﻿using FluentValidation;
using HotelierProject.Persistence;
using JobSearchWebApi.Application.Repositories.CategroyRepository;
using JobSearchWebApi.Application.Repositories.CompanyRepository;
using JobSearchWebApi.Application.Repositories.IndustryRepository;
using JobSearchWebApi.Application.Repositories.JobRepository;
using JobSearchWebApi.Domain.Entities.Identity;
using JobSearchWebApi.Persistence.Contexts;
using JobSearchWebApi.Persistence.Repositories.CategoryRepository;
using JobSearchWebApi.Persistence.Repositories.CompanyRepository;
using JobSearchWebApi.Persistence.Repositories.IndustryRepository;
using JobSearchWebApi.Persistence.Repositories.JobRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceService(this IServiceCollection services)
        {
            services.AddDbContext<JobSearchDbContext>(option=>option.UseSqlServer(Configuration.ConnectionString));

            services.AddIdentity<AppUser, AppRole>(options=>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
            }
            ).AddEntityFrameworkStores<JobSearchDbContext>();

            services.AddScoped<ICategoryRepsoitory,CategoryRepository>();
            services.AddScoped<ICompanyRepository,CompanyRepository>();
            services.AddScoped<IIndustryRepository,IndustryRepository>();
            services.AddScoped<IJobRepository,JobRepository>();

        }
    }
}
