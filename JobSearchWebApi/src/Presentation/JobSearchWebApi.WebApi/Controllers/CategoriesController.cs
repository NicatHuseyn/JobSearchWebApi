using JobSearchWebApi.Application.Features.Commands.CategoryCommand.CreateCategory;
using JobSearchWebApi.Application.Features.Commands.CategoryCommand.RemoveCategory;
using JobSearchWebApi.Application.Features.Commands.CategoryCommand.UpdateCategory;
using JobSearchWebApi.Application.Features.Queries.CategoryQuery.GetAllCategory;
using JobSearchWebApi.Application.Features.Queries.CategoryQuery.GetByIdCategory;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchWebApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]GetAllCategoryQueryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var responses = await _mediator.Send(request);

            if (responses.Count == 0)
            {
                return Ok(new { Message = "Categry is empty"});
            }

            return Ok(responses);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCategory([FromRoute]GetByIdCategoryQueryRequest request)
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
                    return Ok(new { Message = response.Message, Data = response});
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
        public async Task<IActionResult> UpdateCategory([FromBody]UpdateCategoryCommandRequest request)
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
                    return Ok(new { Message = response.Message, Data = response});
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
        public async Task<IActionResult> CreateCategory(CreateCategoryCommandRequest request)
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
        public async Task<IActionResult> DeleteCategory([FromRoute]RemoveCategoryCommandRequest request)
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
                    return BadRequest(response.Message);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message );
            }
        }
    }
}
