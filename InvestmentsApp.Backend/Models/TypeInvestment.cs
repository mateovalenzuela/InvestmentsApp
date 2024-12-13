using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvestmentsApp.Backend.Models
{
    public class TypeInvestment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 4 ,ErrorMessage = "La descripcion debe tener entre 4 y 50 caracteres")]
        public string Descripcion { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        [Required]
        public bool Baja { get; set; }


        public virtual ICollection<Investmetn> Investemnts { get; set; }

    }
}
