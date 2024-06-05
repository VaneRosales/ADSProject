using ADSProjetc.DB;
using ADSProjetc.Interfaces;
using ADSProjetc.Migrations;
using ADSProjetc.Models;
using System.Linq;

namespace ADSProjetc.Repositories
{
    public class ProfesorRepository : IProfesor
    {
        /*private List<Profesor> profesorList = new List<Profesor>
        {
            new Profesor {IdProfesor=1, NombresProfesor="Lucas Antonio", ApellidosProfesor="Calderon Barrera", Email="lucasantonio@usonsonate.edu.sv"}          
        };*/

        private readonly ApplicationDbContext applicationDbContext;
        public int AgregarProfesor(Profesor profesor)
        {
            try
            {

                applicationDbContext.Profesores.Add(profesor);
                applicationDbContext.SaveChanges();

                return profesor.IdProfesor;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public int ActualizarProfesor(int idProfesor, Profesor profesor)
        {
            try
            {
                var item = applicationDbContext.Profesores.SingleOrDefault(tmp => tmp.IdProfesor == idProfesor);

                applicationDbContext.Entry(item).CurrentValues.SetValues(profesor);
                applicationDbContext.SaveChanges();

                return idProfesor;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public bool EliminarProfesor(int idProfesor)
        {
            try
            {
                var item = applicationDbContext.Profesores.SingleOrDefault(x => x.IdProfesor == idProfesor);
                applicationDbContext.Profesores.Remove(item);
                applicationDbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Profesor ObtenerProfesorPorID(int idProfesor)
        {
            try
            {

                var profesor = applicationDbContext.Profesores.SingleOrDefault(tmp => tmp.IdProfesor == idProfesor);

                return profesor;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Profesor> ObtenerTodosLosProfesores()
        {
            try
            {

                return applicationDbContext.Profesores.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
