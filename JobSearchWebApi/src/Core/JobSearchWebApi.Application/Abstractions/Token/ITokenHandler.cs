using JobSearchWebApi.Application.DTOs.TokenDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchWebApi.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        DTOs.TokenDtos.Token CreateAccessToken();
    }
}
