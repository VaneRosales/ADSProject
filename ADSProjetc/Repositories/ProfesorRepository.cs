using ADSProjetc.Interfaces;
using ADSProjetc.Models;

namespace ADSProjetc.Repositories
{
    public class ProfesorRepository : IProfesor
    {
        private List<Profesor> profesorList = new List<Profesor>
        {
            new Profesor {IdProfesor=1, NombresProfesor="Lucas Antonio", ApellidosProfesor="Calderon Barrera", Email="lucasantonio@usonsonate.edu.sv"}          
        };
        
        public int AgregarProfesor(Profesor profesor)
        {
            try
            {

                if (profesorList.Count > 0)
                {
                    profesor.IdProfesor = profesorList.Last().IdProfesor + 1;
                }
                profesorList.Add(profesor);

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
                int bandera = 0;
                int indice = profesorList.FindIndex(tmp => tmp.IdProfesor == idProfesor);

                if (indice >= 0)
                {
                    profesorList[indice] = profesor;
                    bandera = idProfesor;
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


        public bool EliminarProfesor(int idProfesor)
        {
            try
            {
                bool bandera = false;
                int indice = profesorList.FindIndex(aux => aux.IdProfesor == idProfesor);

                if (indice >= 0)
                {
                    profesorList.RemoveAt(indice);
                    bandera = true;
                }

                return bandera;
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

                var profesor = profesorList.FirstOrDefault(tmp => tmp.IdProfesor == idProfesor);

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

                return profesorList;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
