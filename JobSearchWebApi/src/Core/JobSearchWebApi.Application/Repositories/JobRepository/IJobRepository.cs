﻿using JobSearchWebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Repositories.JobRepository
{
    public interface IJobRepository:IRepository<Job>
    {
    }
}
