﻿namespace InvestmentsApp.Frontend.Services
{
    public interface IInvestmentService
    {
        Task<ClientSwagger.InvestmentDto> AddInvestment(ClientSwagger.InsertInvestmentDto dto);

        Task<ClientSwagger.InvestmentDto> GetSelectedInvestment(long id);

        Task UpdateInvestment(long id, ClientSwagger.UpdateInvestmentDto dto);

        Task DeleteInvestment(long id);

        Task<IEnumerable<ClientSwagger.InvestmentDto>> GetInvestments();
    }
}