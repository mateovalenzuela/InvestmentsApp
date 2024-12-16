using InvestmentsApp.Backend.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InvestmentsApp.Backend.DTOs.TypeInvestment
{
    public class TypeInvestmentDto
    {
        public long Id { get; set; }

        public string Descripcion { get; set; }

        public DateTime FechaCreacion { get; set; }

    }
}
