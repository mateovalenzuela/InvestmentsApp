using InvestmentsApp.Backend.DTOs.TypeInvestment;
using InvestmentsApp.Backend.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InvestmentsApp.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeInvestmentController : ControllerBase
    {

        private readonly ITypeInvestmentService _service;

        public TypeInvestmentController(ITypeInvestmentService service)
        {
            _service = service;
        }

        // GET: api/<TypeInvestmentController>
        [HttpGet]
        public async Task<IEnumerable<TypeInvestmentDto>> Get()
            => await _service.GetAll();

        // GET api/<TypeInvestmentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeInvestmentDto>> Get(long id)
        {
            var typeInvestment = await _service.GetById(id);
            return typeInvestment == null ? NotFound() : Ok(typeInvestment);
        }

        // POST api/<TypeInvestmentController>
        [HttpPost]
        public async Task<ActionResult<TypeInvestmentDto>> Add(InsertTypeInvestmentDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(dto);
            }

            if(!_service.Validate(dto))
            {
                return BadRequest(_service.Errors);
            }

            var typeInvestmentDto = await _service.Add(dto);
            return CreatedAtAction(nameof(Get), new { id = typeInvestmentDto.Id }, typeInvestmentDto);
        }

        // PUT api/<TypeInvestmentController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<TypeInvestmentDto>> Put(long id, UpdateTypeInvestmentDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(dto);
            }

            if (!_service.Validate(id, dto))
            {
                return BadRequest(_service.Errors);
            }

            var typeInvestmentDto = await _service.Update(id, dto);
            return typeInvestmentDto == null ? NotFound() : Ok(typeInvestmentDto);
        }

        // DELETE api/<TypeInvestmentController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var typeInvestmentDto = await _service.Delete(id);
            return typeInvestmentDto == null ? NotFound() : Ok(typeInvestmentDto);
        }
    }
}
