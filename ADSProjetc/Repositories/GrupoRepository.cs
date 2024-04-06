using ADSProjetc.Interfaces;
using ADSProjetc.Models;

namespace ADSProjetc.Repositories
{
    public class GrupoRepository : IGrupo
    {
        private List<Grupo> grupoList = new List<Grupo>
        {
            new Grupo{IdGrupo=1,IdCarrera=1,IdProfesor=1,IdMateria=2,Ciclo=01,Anio=2023 }
        };
        
        public int AgregarGrupo(Grupo grupo)
        {
            try
            {

                if (grupoList.Count > 0)
                {
                    grupo.IdGrupo = grupoList.Last().IdGrupo + 1;
                }
                grupoList.Add(grupo);

                return grupo.IdGrupo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int ActualizarGrupo(int idGrupo, Grupo grupo)
        {
            try
            {
                int bandera = 0;
                int indice = grupoList.FindIndex(tmp => tmp.IdGrupo == idGrupo);

                if (indice >= 0)
                {
                    grupoList[indice] = grupo;
                    bandera = idGrupo;
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

        public bool EliminarGrupo(int idGrupo)
        {
            try
            {
                bool bandera = false;
                int indice = grupoList.FindIndex(aux => aux.IdGrupo == idGrupo);

                if (indice >= 0)
                {
                    grupoList.RemoveAt(indice);
                    bandera = true;
                }

                return bandera;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Grupo ObtenerGrupoPorID(int idGrupo)
        {
            try
            {

                var grupo = grupoList.FirstOrDefault(tmp => tmp.IdGrupo == idGrupo);

                return grupo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Grupo> ObtenerTodosLosGrupos()
        {
            try
            {

                return grupoList;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
