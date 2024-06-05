using ADSProjetc.DB;
using ADSProjetc.Interfaces;
using ADSProjetc.Migrations;
using ADSProjetc.Models;

namespace ADSProjetc.Repositories
{
    public class MateriaRepository : IMateria
    {
        /*private List<Materia> materiaList = new List<Materia>
        {
            new Materia {IdMateria=1,NombreMateria="Estatica"},
            new Materia {IdMateria=2,NombreMateria="Matematica 1"}
        };*/

        private readonly ApplicationDbContext applicationDbContext;
        public int AgregarMateria(Materia materia)
        {
            try
            {
                applicationDbContext.Materias.Add(materia);
                applicationDbContext.SaveChanges();

                return materia.IdMateria;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int ActualizarMateria(int idMateria, Materia materia)
        {
            try
            {
                var item = applicationDbContext.Materias.SingleOrDefault(tmp => tmp.IdMateria == idMateria);

                applicationDbContext.Entry(item).CurrentValues.SetValues(materia);
                applicationDbContext.SaveChanges();

                return idMateria;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EliminarMateria(int idMateria)
        {
            try
            {
                var item = applicationDbContext.Materias.SingleOrDefault(x => x.IdMateria == idMateria);
                applicationDbContext.Materias.Remove(item);
                applicationDbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Materia ObtenerMateriaPorID(int idMateria)
        {
            try
            {
              
                var materia = applicationDbContext.Materias.SingleOrDefault(tmp => tmp.IdMateria == idMateria);

                return materia;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Materia> ObtenerTodasLasMaterias()
        {
            try
            {
                return applicationDbContext.Materias.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
