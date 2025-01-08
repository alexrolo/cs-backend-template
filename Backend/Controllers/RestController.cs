using Backend.Services.Rest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models.Entities.DTOs;
using Models.Entities.Mappers;
using Models.Entities.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestController<TModel, TDto>(
        IRestService<TModel> service,
        IMapper<TModel, TDto> mapper
    ) : ControllerBase
        where TModel : class, IModel
        where TDto : class, IDto
    {
        private readonly IRestService<TModel> _service = service;
        private readonly IMapper<TModel, TDto> _mapper = mapper;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<TModel> entities = await _service.GetAllAsync();
            IEnumerable<TDto> dtos = entities.Select(entity => _mapper.ToDto(entity));
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            TModel? entity = await _service.GetByIdAsync(id);
            if (entity == null)
                return NotFound();
            TDto dto = _mapper.ToDto(entity);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            TModel model = _mapper.ToModel(dto);
            TModel entity = await _service.AddAsync(model);
            return Created("", _mapper.ToDto(entity));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            TModel model = _mapper.ToModel(dto);
            bool updated = await _service.UpdateAsync(id, model);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
