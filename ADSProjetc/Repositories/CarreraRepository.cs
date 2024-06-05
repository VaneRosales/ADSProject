using ADSProjetc.DB;
using ADSProjetc.Interfaces;
using ADSProjetc.Migrations;
using ADSProjetc.Models;

namespace ADSProjetc.Repositories
{
    public class CarreraRepository : ICarrera
    {
        /*private List<Carrera> carreraList = new List<Carrera>
        {
            new Carrera {IdCarrera=1, NombreCarrera="Ingenieria en Sistemas", CodigoCarrera="I04"},
            new Carrera {IdCarrera=2, NombreCarrera="Ingenieria Industrial", CodigoCarrera="I03"}
        };*/

        private readonly ApplicationDbContext applicationDbContext;

        public int AgregarCarrera(Carrera carrera)
        {
            try
            {

                applicationDbContext.Carreras.Add(carrera);
                applicationDbContext.SaveChanges();

                return carrera.IdCarrera;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public int ActualizarCarrera(int idCarrera, Carrera carrera)
        {
            try
            {
                var item = applicationDbContext.Carreras.SingleOrDefault(tmp => tmp.IdCarrera == idCarrera);

                applicationDbContext.Entry(item).CurrentValues.SetValues(carrera);
                applicationDbContext.SaveChanges();

                return idCarrera;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EliminarCarrera(int idCarrera)
        {
            try
            {
                var item = applicationDbContext.Carreras.SingleOrDefault(x => x.IdCarrera == idCarrera);
                applicationDbContext.Carreras.Remove(item);
                applicationDbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Carrera ObtenerCarreraPorID(int idCarrera)
        {
            try
            {
                
                var carrera= applicationDbContext.Carreras.SingleOrDefault(tmp => tmp.IdCarrera== idCarrera);

                return carrera;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Carrera> ObtenerTodasLasCarreras()
        {
            try
            {

                return applicationDbContext.Carreras.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
