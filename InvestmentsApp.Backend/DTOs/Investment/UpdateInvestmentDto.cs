using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InvestmentsApp.Backend.DTOs.Investment
{
    public class UpdateInvestmentDto
    {
        [Required]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "La descripcion debe tener entre 4 y 50 caracteres")]
        public string Tikcker { get; set; }

        [StringLength(200, ErrorMessage = "La descripcion debe tener menos de 200 caracteres")]
        public string? Descripcion { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ImporteInicial { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ImporteFinal { get; set; }

        [Required]
        public DateTime FechaEntrada { get; set; }

        [Required]
        public DateTime FechaCierre { get; set; }

        [Required]
        public long IdTypeInvestment { get; set; }

    }
}
