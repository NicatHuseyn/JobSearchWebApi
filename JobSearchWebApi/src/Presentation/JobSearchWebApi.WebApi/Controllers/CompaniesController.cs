using JobSearchWebApi.Application.Features.Commands.CategoryCommand.RemoveCategory;
using JobSearchWebApi.Application.Features.Commands.CategoryCommand.UpdateCategory;
using JobSearchWebApi.Application.Features.Commands.CompanyCommand.CreateCompany;
using JobSearchWebApi.Application.Features.Commands.CompanyCommand.RemoveCompany;
using JobSearchWebApi.Application.Features.Commands.CompanyCommand.UpdateCompany;
using JobSearchWebApi.Application.Features.Queries.CompanyQuery.GetAllCompany;
using JobSearchWebApi.Application.Features.Queries.CompanyQuery.GetByIdCompany;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchWebApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompaniesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]GetAllCompanyQueryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var responses = await _mediator.Send(request);

                if (responses.Count == 0)
                {
                    return Ok(new { Message = "Categry is empty" });
                }
                return Ok(responses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCompany([FromRoute] GetByIdCompanyQueryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var response = await _mediator.Send(request);
                if (response.Success)
                {
                    return Ok(new { Message = response.Message, Data = response });
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateCompany(CreateCompanyCommandRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var response = await _mediator.Send(request);
                if (response.Success)
                {
                    return Ok(new { Message = response.Message, Data = response });
                }
                else
                {
                    return BadRequest(response.Message);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateCompany([FromBody] UpdateCompanyCommandRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var response = await _mediator.Send(request);
                if (response.Success)
                {
                    return Ok(new { Message = response.Message, Data = response });
                }
                else
                {
                    return BadRequest(response.Message);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCompany([FromRoute] RemoveCompanyCommandRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var response = await _mediator.Send(request);
                if (response.Success)
                {
                    return Ok(new { Message = response.Message });
                }
                else
                {
                    return BadRequest(response.Message);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
