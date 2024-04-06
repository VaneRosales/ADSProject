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
                int bandera=0;
                int indice = carreraList.FindIndex(tmp => tmp.IdCarrera == idCarrera);

                if (indice >= 0)
                {
                    carreraList[indice] = carrera;
                    bandera = idCarrera;
                }
                else
                {
                    bandera = -1;
                }

                return bandera;
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
                bool bandera = false;
                int indice = carreraList.FindIndex(aux => aux.IdCarrera== idCarrera);

                if (indice >= 0)
                {
                    carreraList.RemoveAt(indice);
                    bandera = true;
                }

                return bandera;
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
                
                var carrera= carreraList.FirstOrDefault(tmp => tmp.IdCarrera== idCarrera);

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
