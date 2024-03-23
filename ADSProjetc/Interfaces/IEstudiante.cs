using ADSProjetc.Models;

namespace ADSProjetc.Interfaces
{
    public interface IEstudiante
    {
        public int AgregarEstudiante(Estudiante estudiante);
        public int ActualizarEstudiante(int idEstudiante, Estudiante estudiante);
        public bool EliminarEstudiante(int idEstudiante);
        public List<Estudiante> ObtenerTodosLosEstudiantes();
        public Estudiante ObtenerEstudiantesPorID(int idEstudiante);

    }
}
