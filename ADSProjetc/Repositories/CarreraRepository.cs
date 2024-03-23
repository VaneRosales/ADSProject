using ADSProjetc.Interfaces;
using ADSProjetc.Models;

namespace ADSProjetc.Repositories
{
    public class CarreraRepository : ICarrera
    {
        private List<Carrera> carreraList = new List<Carrera>
        {
            new Carrera {IdCarrera=1, NombreCarrera="Ingenieria en Sistemas", CodigoCarrera="I04001"},
            new Carrera {IdCarrera=2, NombreCarrera="Ingenieria Industrial", CodigoCarrera="I03001"}
        };

        public int AgregarCarrera(Carrera carrera)
        {
            try
            {
                //validar si existen datos en la lista, de ser asi, tomaremos el ultmo ID
                //y lo incrementamos en una unidad
                if (carreraList.Count > 0)
                {
                    carrera.IdCarrera = carreraList.Last().IdCarrera + 1;
                }
                carreraList.Add(carrera);

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
                //Obtenemos el indice del objeto para actualizar
                int indice = carreraList.FindIndex(tmp => tmp.IdCarrera == idCarrera);

                //procedemos con la actualizacion
                carreraList[indice] = carrera;

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
                //Obtenemos el indice del objeto a eliminar
                int indice = carreraList.FindIndex(tmp => tmp.IdCarrera== idCarrera);

                //procedemos con la actualizacion
                carreraList.RemoveAt(indice);

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
                //Obtenemos el indice del objeto para actualizar
                Carrera carrera= carreraList.FirstOrDefault(tmp => tmp.IdCarrera== idCarrera);

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

                return carreraList;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
