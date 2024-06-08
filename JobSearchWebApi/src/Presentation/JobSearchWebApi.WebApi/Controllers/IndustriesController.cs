using Azure;
using JobSearchWebApi.Application.Features.Commands.IndustryCommand.RemoveIndustry;
using JobSearchWebApi.Application.Features.Commands.IndustryCommand.UpdateIndustry;
using JobSearchWebApi.Application.Features.Commands.StaffCommand.CreateStaff;
using JobSearchWebApi.Application.Features.Queries.IndustryQuery.GetAllIndustry;
using JobSearchWebApi.Application.Features.Queries.IndustryQuery.GetByIdIndustry;
using JobSearchWebApi.Application.Repositories.IndustryRepository;
using JobSearchWebApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchWebApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndustriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IndustriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllIndustryQueryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var responses = await _mediator.Send(request);
            if (responses.Count == 0)
            {
                return Ok(new { Message = "Industry is empty"});
            }
            return Ok(responses);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetIndustry([FromRoute] GetByIdIndustryQueryRequest request)
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

        [HttpPost]
        public async Task<IActionResult> CreateIndustry(CreateIndustryCommandRequest request)
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
                    return Ok(new { Data = response });
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
        public async Task<IActionResult> UpdateIndustry([FromBody] UpdateIndustryCommandRequest request)
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
                    return Ok(new { Message= response.Message, Data = response });
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
        public async Task<IActionResult> RemoveIndustry([FromRoute]RemoveIndustryCommandRequest request)
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
                    return Ok(new { Message = response.Message});
                }
                else
                {
                    return  BadRequest(response.Message);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
