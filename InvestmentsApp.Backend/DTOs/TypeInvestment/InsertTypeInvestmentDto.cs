using InvestmentsApp.Backend.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InvestmentsApp.Backend.DTOs.TypeInvestment
{
    public class InsertTypeInvestmentDto
    {
        [Required]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "La descripcion debe tener entre 4 y 50 caracteres")]
        public string Descripcion { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

    }
}
