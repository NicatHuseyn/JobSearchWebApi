﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Infrastructure.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState
                    .Where(x => x.Value.Errors.Any())
                    .ToDictionary(e => e.Key, e => e.Value.Errors.Select(e => e.ErrorMessage))
                    .ToArray();

                context.Result = new BadRequestObjectResult(errors);
            }

            return next();
        }
    }
}
