using ADSProjetc.Models;
using Microsoft.EntityFrameworkCore;

namespace ADSProjetc.DB
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {

        }
        //Con un DbSet se indica a EntityFramewortCore cuales van a ser las tablas que quiero tener en la base de datos
        //tambien le diremos en base a que modelos o entidades vamos a basar dichas tablas, por ejem

        public DbSet<Estudiante> Estudiantes { get; set; }
    }
}
