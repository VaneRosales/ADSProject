using ADSProjetc.Validations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ADSProjetc.Models
{
    [PrimaryKey(nameof(IdGrupo))]
    public class Grupo
    {
        public int IdGrupo {  get; set; }
        [CustomRequired(ErrorMessage = "Este es un campo requerido y mayor a 0")]
        public int IdCarrera {  get; set; }
        [CustomRequired(ErrorMessage = "Este es un campo requerido y mayor a 0")]
        public int IdMateria {  get; set; }
        [CustomRequired(ErrorMessage = "Este es un campo requerido y mayor a 0")]
        public int IdProfesor {  get; set; }
        [CustomRequired(ErrorMessage = "Este es un campo requerido y mayor a 0")]
        public int Ciclo {  get; set; }
        [CustomRequired(ErrorMessage = "Este es un campo requerido y mayor a 0")]
        public int Anio {  get; set; }
    }
}
