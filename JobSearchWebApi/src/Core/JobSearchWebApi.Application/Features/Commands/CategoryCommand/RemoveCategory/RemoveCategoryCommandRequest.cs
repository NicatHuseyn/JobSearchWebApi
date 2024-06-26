﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Features.Commands.CategoryCommand.RemoveCategory
{
    public class RemoveCategoryCommandRequest:IRequest<RemoveCategoryCommandResponse>
    {
        public int Id { get; set; }
    }
}
