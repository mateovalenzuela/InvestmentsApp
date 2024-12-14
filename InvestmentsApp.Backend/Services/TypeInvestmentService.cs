using AutoMapper;
using InvestmentsApp.Backend.DTOs.Investment;
using InvestmentsApp.Backend.DTOs.TypeInvestment;
using InvestmentsApp.Backend.Models;
using InvestmentsApp.Backend.Repositories;

namespace InvestmentsApp.Backend.Services
{
    public class TypeInvestmentService : ITypeInvestmentService
    {
        private readonly ITypeInvestmentRepository _repository;
        private readonly IMapper _mapper;
        public Dictionary<string, string> Errors { get; }

        public TypeInvestmentService(ITypeInvestmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            Errors = new ();
            _mapper = mapper;
        }

        public async Task<TypeInvestmentDto> Add(InsertTypeInvestmentDto dto)
        {
            var typeInvestment = _mapper.Map<TypeInvestment>(dto);
            typeInvestment = InitializeDefaultProps(typeInvestment);

            await _repository.Add(typeInvestment);
            await _repository.Save();

            var typeInvestmentDto = _mapper.Map<TypeInvestmentDto>(typeInvestment);
            return typeInvestmentDto;
        }

        public async Task<TypeInvestmentDto?> Delete(long id)
        {
            var typeInvestment = await _repository.GetActive(id);

            if(typeInvestment != null)
            {
                _repository.BajaLogica(typeInvestment);
                await _repository.Save();

                var typeInvestmentDto = _mapper.Map<TypeInvestmentDto>(typeInvestment);
                return typeInvestmentDto;
            }

            return null;
        }

        public async Task<IEnumerable<TypeInvestmentDto>> GetAll()
        {
            var typesInvestment = await _repository.GetAllActives();

            var typesInvestmetDto = typesInvestment.Select(t => _mapper.Map<TypeInvestmentDto>(t)).ToList();
            return typesInvestmetDto;
        }

        public async Task<TypeInvestmentDto?> GetById(long id)
        {
            var typeInvestment = await _repository.GetActive(id);

            if (typeInvestment != null)
            {
                var typeInvestmentDto = _mapper.Map<TypeInvestmentDto>(typeInvestment);
                return typeInvestmentDto;
            }

            return null;
        }

        public async Task<TypeInvestmentDto?> Update(long id, UpdateTypeInvestmentDto dto)
        {
            var typeInvestment = await _repository.GetActive(id);

            if (typeInvestment != null)
            {
                typeInvestment.Descripcion = dto.Descripcion;
                await _repository.Save();

                var typeInvestmentDto = _mapper.Map<TypeInvestmentDto>(typeInvestment);
                return typeInvestmentDto;
            }

            return null;
        }

        public bool Validate(InsertTypeInvestmentDto dto)
        {
            if(_repository.Search(t=> t.Descripcion == dto.Descripcion && t.Baja == false, 1).Count() > 0)
            {
                Errors.Add("Descripcion", "El Type Investment ya existe");
                return false;
            }
            return true;
        }

        public bool Validate(long id, UpdateTypeInvestmentDto dto)
        {
            if (_repository.Search(t => t.Descripcion == dto.Descripcion &&
                                        t.Id != id &&
                                        t.Baja == false, 2).Count() > 0)
            {
                Errors.Add("Descripcion", "El Type Investment ya existe");
                return false;
            }
            return true;
        }


        private TypeInvestment InitializeDefaultProps(TypeInvestment entity)
        {
            entity.Baja = false;
            return entity;
        }
    }
}
