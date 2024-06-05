using ADSProjetc.DB;
using ADSProjetc.Interfaces;
using ADSProjetc.Models;

namespace ADSProjetc.Repositories
{
    public class EstudianteRepository : IEstudiante
    {
        /*private List<Estudiante> lstEstudiantes =new List<Estudiante>
        {
            new Estudiante{ IdEstudiante=1, NombresEstudiante="JUAN CARLOS",
            ApellidosEstudiante="PEREZ SOSA", CodigoEstudiante="PS24I04002",
            CorreoEstudiante="PS24I04002@usonsonate.edu.sv"
            } 
        };*/
        private readonly ApplicationDbContext applicationDbContext;

        public EstudianteRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public int AgregarEstudiante(Estudiante estudiante)

        {
            try
            {
                //validar si existen datos en la lista, de ser asi, tomaremos el ultmo ID
                //y lo incrementamos en una unidad
                /*if (lstEstudiantes.Count > 0)
                {
                    estudiante.IdEstudiante=lstEstudiantes.Last().IdEstudiante+1;
                }
                lstEstudiantes.Add(estudiante);*/

                applicationDbContext.Estudiantes.Add(estudiante);
                applicationDbContext.SaveChanges();

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
                var item = applicationDbContext.Estudiantes.SingleOrDefault(x => x.IdEstudiante == idEstudiante);
                applicationDbContext.Entry(item).CurrentValues.SetValues(estudiante);
                applicationDbContext.SaveChanges();

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
                /*bool bandera = false;
                int indice = lstEstudiantes.FindIndex(aux => aux.IdEstudiante == idEstudiante);

                if (indice >= 0)
                {
                    lstEstudiantes.RemoveAt(indice);
                    bandera = true;
                }*/

                var item = applicationDbContext.Estudiantes.SingleOrDefault(x => x.IdEstudiante == idEstudiante);
                applicationDbContext.Estudiantes.Remove(item);
                applicationDbContext.SaveChanges();

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
                
                var estudiante = applicationDbContext.Estudiantes.SingleOrDefault(x => x.IdEstudiante == idEstudiante);

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
                // return lstEstudiantes;
                return applicationDbContext.Estudiantes.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
