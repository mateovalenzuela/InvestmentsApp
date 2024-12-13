using InvestmentsApp.Backend.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InvestmentsApp.Backend.DTOs
{
    public class InvestmentDto
    {
        public long Id { get; set; }

        public string Tikcker { get; set; }

        public string? Descripcion { get; set; }

        public decimal ImporteInicial { get; set; }

        public decimal ImporteFinal { get; set; }

        public DateTime FechaEntrada { get; set; }

        public DateTime FechaCierre { get; set; }

        public DateTime FechaCreacion { get; set; }

        public long IdTypeInvestment { get; set; }

    }
}
