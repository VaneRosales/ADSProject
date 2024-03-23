using ADSProjetc.Interfaces;
using ADSProjetc.Models;

namespace ADSProjetc.Repositories
{
    public class EstudianteRepository : IEstudiante
    {
        private List<Estudiante> lstEstudiantes =new List<Estudiante>
        {
            new Estudiante{ IdEstudiante=1, NombresEstudiante="JUAN CARLOS",
            ApellidosEstudiante="PEREZ SOSA", CodigoEstudiante="PS24I04002",
            CorreoEstudiante="PS24I04002@usonsonate.edu.sv"
            } 
        };

        public int AgregarEstudiante(Estudiante estudiante)

        {
            try
            {
                //validar si existen datos en la lista, de ser asi, tomaremos el ultmo ID
                //y lo incrementamos en una unidad
                if (lstEstudiantes.Count > 0)
                {
                    estudiante.IdEstudiante=lstEstudiantes.Last().IdEstudiante+1;
                }
                lstEstudiantes.Add(estudiante);

                return estudiante.IdEstudiante;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int ActualizarEstudiante(int idEstudiante, Estudiante estudiante)
        {
            try
            {
                //Obtenemos el indice del objeto para actualizar
                int indice = lstEstudiantes.FindIndex(tmp => tmp.IdEstudiante == idEstudiante);

                //procedemos con la actualizacion
                lstEstudiantes[indice] = estudiante;

                return idEstudiante;
            }
            catch (Exception)
            {
                throw;
            }

        }


        public bool EliminarEstudiante(int idEstudiante)
        {
            try
            {
                //Obtenemos el indice del objeto a eliminar
                int indice = lstEstudiantes.FindIndex(tmp => tmp.IdEstudiante == idEstudiante);

                //procedemos con la actualizacion
                lstEstudiantes.RemoveAt(indice);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Estudiante ObtenerEstudiantesPorID(int idEstudiante)
        {
            try
            {
                //Obtenemos el indice del objeto para actualizar
                Estudiante estudiante = lstEstudiantes.FirstOrDefault(tmp => tmp.IdEstudiante == idEstudiante);

                return estudiante;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Estudiante> ObtenerTodosLosEstudiantes()
        {
            try
            {

                return lstEstudiantes;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
