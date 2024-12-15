using InvestmentsApp.Backend.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace InvestmentsApp.Backend.DTOs.Investment
{
    public class InsertInvestmentDto
    {
        [Required]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "La descripcion debe tener entre 4 y 50 caracteres")]
        public string Tikcker { get; set; }

        [StringLength(200, ErrorMessage = "La descripcion debe tener menos de 200 caracteres")]
        public string? Descripcion { get; set; }

        [Required]
        [Range(1, 9999999999999999.99, ErrorMessage = "El Importe debe ser positivo y con menos de 19 dígitos")]
        public decimal ImporteInicial { get; set; }

        [Required]
        [Range(1, 9999999999999999.99, ErrorMessage ="El Importe debe ser positivo y con menos de 19 dígitos")]
        public decimal ImporteFinal { get; set; }

        [Required]
        public DateTime FechaEntrada { get; set; }

        [Required]
        public DateTime FechaCierre { get; set; }

        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "El IdTypeInvestment debe ser positivo y mayor a 0")]

        public long IdTypeInvestment { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

    }
}
