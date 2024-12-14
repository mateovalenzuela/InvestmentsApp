﻿using InvestmentsApp.Backend.DTOs.Investment;
using InvestmentsApp.Backend.DTOs.TypeInvestment;

namespace InvestmentsApp.Backend.Services
{
    public interface ITypeInvestmentService : IService<TypeInvestmentDto, InsertTypeInvestmentDto, UpdateTypeInvestmentDto>
    {
    }
}
