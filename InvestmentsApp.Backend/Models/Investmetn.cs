using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvestmentsApp.Backend.Models
{
    public class Investmetn
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "La descripcion debe tener entre 4 y 50 caracteres")]
        public string Tikcker {  get; set; }

        [StringLength(200)]
        public string? Descripcion {  get; set; }

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
        public DateTime FechaCreacion { get; set; }

        [Required]
        public long IdTypeInvestment { get; set; }

        [Required]
        public bool Baja {  get; set; }

        [ForeignKey("IdTypeInvestment")]
        public virtual TypeInvestment TypeInvestment { get; set; }

    }
}
