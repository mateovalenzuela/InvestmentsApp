using AutoMapper;
using InvestmentsApp.Backend.DTOs.Investment;
using InvestmentsApp.Backend.DTOs.TypeInvestment;
using InvestmentsApp.Backend.Models;
using InvestmentsApp.Backend.Repositories;

namespace InvestmentsApp.Backend.Services
{
    public class InvestmentService : IInvestmentService
    {
        private readonly IInvestmentRepository _repository;
        private readonly ITypeInvestmentRepository _typeInvestmentRepository;
        private readonly IMapper _mapper;
        public Dictionary<string, string> Errors { get; }

        public InvestmentService(IInvestmentRepository repository, ITypeInvestmentRepository typeInvestmentRepository, IMapper mapper)
        {
            _repository = repository;
            _typeInvestmentRepository = typeInvestmentRepository;
            _mapper = mapper;
            Errors = new ();
        }

        


        public async Task<InvestmentDto> Add(InsertInvestmentDto dto)
        {
            var investment = _mapper.Map<Investmetn>(dto);
            investment = InitializeDefaultProps(investment);

            investment.TypeInvestment = await _typeInvestmentRepository.GetActive(dto.IdTypeInvestment);

            await _repository.Add(investment);
            await _repository.Save();

            var investmentDto = _mapper.Map<InvestmentDto>(investment);
            return investmentDto; 
        }

        public async Task<InvestmentDto?> Delete(long id)
        {
            var investment = await _repository.GetActive(id);

            if (investment != null)
            {
                _repository.BajaLogica(investment);
                await _repository.Save();

                var investmentDto = _mapper.Map<InvestmentDto>(investment);
                return investmentDto;
            }

            return null;
        }

        public async Task<IEnumerable<InvestmentDto>> GetAll()
        {
            var investments = await _repository.GetAllActives();

            var investmentsDtos = investments.Select(i => _mapper.Map<InvestmentDto>(i)).ToList();
            return investmentsDtos;
        }

        public async Task<InvestmentDto?> GetById(long id)
        {
            var investment = await _repository.GetActive(id);

            if (investment != null)
            {
                var investmentDto = _mapper.Map<InvestmentDto>(investment);
                return investmentDto;
            }

            return null;
        }

        public async Task<IEnumerable<InvestmentDto>> GetByTicker(string ticker)
        {
            var investments = await _repository.GetActiveByTicker(ticker);

            if (investments != null)
            {
                var investmentDto = investments.Select(i => _mapper.Map<InvestmentDto>(i)).ToList();
                return investmentDto;
            }

            return null;
        }

        public async Task<IEnumerable<InvestmentDto>> GetByTypeInvestment(long idTypeInvestment)
        {
            var investments = await _repository.GetActiveByTypeInvestment(idTypeInvestment);

            if (investments != null)
            {
                var investmentDto = investments.Select(i => _mapper.Map<InvestmentDto>(i)).ToList();
                return investmentDto;
            }

            return null;
        }

        public async Task<InvestmentDto?> Update(long id, UpdateInvestmentDto dto)
        {
            var investment = await _repository.GetActive(id);

            if (investment != null)
            {
                investment.Tikcker = dto.Tikcker;
                investment.ImporteInicial = dto.ImporteInicial;
                investment.ImporteFinal = dto.ImporteFinal;
                investment.Descripcion = dto.Descripcion;
                investment.FechaEntrada = dto.FechaEntrada;
                investment.FechaCierre = dto.FechaCierre;
                investment.IdTypeInvestment = dto.IdTypeInvestment;

                _repository.Update(investment);
                await _repository.Save();

                var investmentDto = _mapper.Map<InvestmentDto>(investment);
                return investmentDto;
            }

            return null;
        }

        public async Task<bool> Validate(InsertInvestmentDto dto)
        {
            bool flag = true;

            var typeInvestment = await _typeInvestmentRepository.GetActive(dto.IdTypeInvestment);
            if (typeInvestment == null)
            {
                Errors.Add("TypeInvestment", "El TypeInvestment no existe");
                flag = false;
            }

            if (dto.FechaCierre < dto.FechaEntrada)
            {
                Errors.Add("FechaCierre", "La Fecha de Cierre no puede ser anterior a la fecha de Entrada");
                flag = false;
            }

            return flag;
        }

        public async Task<bool> Validate(long id, UpdateInvestmentDto dto)
        {
            bool flag = true;

            var typeInvestment = await _typeInvestmentRepository.GetActive(dto.IdTypeInvestment);
            if (typeInvestment == null)
            {
                Errors.Add("TypeInvestment", "El TypeInvestment no existe");
                flag = false;
            }

            if (dto.FechaCierre < dto.FechaEntrada)
            {
                Errors.Add("FechaCierre", "La Fecha de Cierre no puede ser anterior a la fecha de Entrada");
                flag = false;
            }

            return flag;
        }

        private static Investmetn InitializeDefaultProps(Investmetn entity)
        {
            entity.Baja = false;
            return entity;
        }
    }
}
