using AutoMapper;
using InvestmentsApp.Backend.DTOs.Investment;
using InvestmentsApp.Backend.DTOs.TypeInvestment;
using InvestmentsApp.Backend.Models;

namespace InvestmentsApp.Backend.Services
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // TypeInvestment
            CreateMap<InsertTypeInvestmentDto, TypeInvestment>();
            CreateMap<UpdateTypeInvestmentDto, TypeInvestment>();
            CreateMap<TypeInvestment, TypeInvestmentDto>();

            //Investment
            CreateMap<InsertInvestmentDto, Investmetn>();
            CreateMap<UpdateTypeInvestmentDto, Investmetn>();
            CreateMap<Investmetn, InvestmentDto>();
        }
    }
}
