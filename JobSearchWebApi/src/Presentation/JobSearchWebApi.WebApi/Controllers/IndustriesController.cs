using JobSearchWebApi.Application.Repositories.IndustryRepository;
using JobSearchWebApi.Application.ViewModels.IndustryViewModels;
using JobSearchWebApi.Domain.Entities;
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
        private readonly IIndustryRepository _industryRepository;

        public IndustriesController(IIndustryRepository industryRepository)
        {
            _industryRepository = industryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var industries = _industryRepository.GetAll();
            return Ok(industries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDataById(int id)
        {
            var industry = await _industryRepository.GetByIdAsync(id);
            return Ok(industry);
        }

        [HttpPost]
        public async Task<IActionResult> CreateIndustry([FromBody] CreateIndustryViewModel model)
        {
            await _industryRepository.AddAsync(new()
            {
                IndustryName = model.IndustryName,
                Icon = model.Icon
            });
            await _industryRepository.SaveAsync();
            return Ok("Create Industry");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateIndustryViewModel model)
        {
            Industry industry = await _industryRepository.GetByIdAsync(model.Id);
            industry.IndustryName = model.IndustryName;
            industry.Icon = model.Icon;
            await _industryRepository.SaveAsync();
            return Ok("Updated Industry");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        { 
            await _industryRepository.RemoveAsync(id);
            await _industryRepository.SaveAsync();
            return Ok("deleted data");
        }
    }
}
