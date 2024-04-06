using ADSProjetc.Interfaces;
using ADSProjetc.Models;

namespace ADSProjetc.Repositories
{
    public class MateriaRepository : IMateria
    {
        private List<Materia> materiaList = new List<Materia>
        {
            new Materia {IdMateria=1,NombreMateria="Estatica"},
            new Materia {IdMateria=2,NombreMateria="Matematica 1"}
        };

        public int AgregarMateria(Materia materia)
        {
            try
            {
                if (materiaList.Count > 0)
                {
                    materia.IdMateria = materiaList.Last().IdMateria + 1;
                }
                materiaList.Add(materia);

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
                int bandera = 0;
                int indice = materiaList.FindIndex(tmp => tmp.IdMateria == idMateria);
                
                if (indice >= 0)
                {
                    materiaList[indice] = materia;
                    bandera = idMateria;
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

        public bool EliminarMateria(int idMateria)
        {
            try
            {
                bool bandera = false;
                int indice = materiaList.FindIndex(aux => aux.IdMateria == idMateria);
                if (indice >= 0)
                {
                    materiaList.RemoveAt(indice);
                    bandera = true;
                }

                return bandera;
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
                var materia = materiaList.FirstOrDefault(tmp => tmp.IdMateria == idMateria);

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
                return materiaList;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
