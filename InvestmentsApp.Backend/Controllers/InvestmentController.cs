using InvestmentsApp.Backend.DTOs.Investment;
using InvestmentsApp.Backend.DTOs.TypeInvestment;
using InvestmentsApp.Backend.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InvestmentsApp.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentController : ControllerBase
    {
        private readonly IInvestmentService _service;

        public InvestmentController(IInvestmentService service)
        {
            _service = service;
        }

        // GET: api/<InvestmentController>
        [HttpGet]
        public async Task<IEnumerable<InvestmentDto>> Get()
            => await _service.GetAll();

       

        // GET api/<InvestmentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvestmentDto>> Get(long id)
        {
            var investmentDto = await _service.GetById(id);
            return investmentDto == null ? NotFound() : Ok(investmentDto);
        }

        // GET api/<InvestmentController>/byTicker/ticker
        [HttpGet("byTicker/{ticker}")]
        public async Task<ActionResult<InvestmentDto>> GetByTicker(string ticker)
        {
            var investmentDto = await _service.GetByTicker(ticker);
            return investmentDto == null ? NotFound() : Ok(investmentDto);
        }


        // GET api/<InvestmentController>/5
        [HttpGet("byIdTypeInvestment/{idTypeInvestment}")]
        public async Task<ActionResult<InvestmentDto>> GetByIdTypeInvestment(long idTypeInvestment)
        {
            var investmentDto = await _service.GetByTypeInvestment(idTypeInvestment);
            return investmentDto == null ? NotFound() : Ok(investmentDto);
        }


        // POST api/<InvestmentController>
        [HttpPost]
        public async Task<ActionResult<InvestmentDto>> Add(InsertInvestmentDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(dto);
            }

            if (!await _service.Validate(dto))
            {
                return BadRequest(_service.Errors);
            }

            var investmentDto = await _service.Add(dto);
            return CreatedAtAction(nameof(Get), new { id = investmentDto.Id }, investmentDto);
        }

        // PUT api/<InvestmentController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<InvestmentDto>> Put(long id, UpdateInvestmentDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(dto);
            }

            if (! await _service.Validate(id, dto))
            {
                return BadRequest(_service.Errors);
            }

            var investmentDto = await _service.Update(id, dto);
            return investmentDto == null ? NotFound() : Ok(investmentDto);
        }

        // DELETE api/<InvestmentController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InvestmentDto>> Delete(long id)
        {
            var investmentDto = await _service.Delete(id);
            return investmentDto == null ? NotFound() : Ok(investmentDto);
        }
    }
}
