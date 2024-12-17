using InvestmentsApp.Backend.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InvestmentsApp.Backend.DTOs.Investment
{
    public class InvestmentDto
    {
        public long Id { get; set; }

        public string Ticker { get; set; }

        public string? Descripcion { get; set; }

        public decimal ImporteInicial { get; set; }

        public decimal ImporteFinal { get; set; }

        public DateTime FechaEntrada { get; set; }

        public DateTime FechaCierre { get; set; }

        public DateTime FechaCreacion { get; set; }

        public long IdTypeInvestment { get; set; }

        public decimal Rendimiento {  get; set; }

        public string TypeInvestmentDescripcion { get; set; }

        public InvestmentDto()
        {
            if (ImporteInicial != 0)
            {
                Rendimiento = ((ImporteFinal - ImporteInicial) / ImporteInicial) * 100;
            }
            else
            {
                Rendimiento = 0;
            }
        }

    }
}
