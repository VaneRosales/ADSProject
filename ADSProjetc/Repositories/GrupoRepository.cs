using ADSProjetc.DB;
using ADSProjetc.Interfaces;
using ADSProjetc.Migrations;
using ADSProjetc.Models;
using System.Linq;

namespace ADSProjetc.Repositories
{
    public class GrupoRepository : IGrupo
    {
       /* private List<Grupo> grupoList = new List<Grupo>
        {
            new Grupo{IdGrupo=1,IdCarrera=1,IdProfesor=1,IdMateria=2,Ciclo=01,Anio=2023 }
        };*/
        private readonly ApplicationDbContext applicationDbContext;
        public int AgregarGrupo(Grupo grupo)
        {
            try
            {

                applicationDbContext.Grupos.Add(grupo);
                applicationDbContext.SaveChanges();

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
                var item = applicationDbContext.Grupos.SingleOrDefault(tmp => tmp.IdGrupo == idGrupo);

                applicationDbContext.Entry(item).CurrentValues.SetValues(grupo);
                applicationDbContext.SaveChanges();

                return idGrupo;
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
                var item = applicationDbContext.Grupos.SingleOrDefault(x => x.IdGrupo == idGrupo);
                applicationDbContext.Grupos.Remove(item);
                applicationDbContext.SaveChanges();

                return true;
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

                var grupo = applicationDbContext.Grupos.SingleOrDefault(tmp => tmp.IdGrupo == idGrupo);

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

                return applicationDbContext.Grupos.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
