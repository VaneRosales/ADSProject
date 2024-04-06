using ADSProjetc.Interfaces;
using ADSProjetc.Models;
using ADSProjetc.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ADSProjetc.Controllers
{
    [Route("api/estudiantes/")]
    public class EstudiantesController : ControllerBase
    {
        private readonly IEstudiante estudiante;
        private string pCodRespuesta;
        private string pMensajeUsuario;
        private string pMensajeTecnico;

        public EstudiantesController(IEstudiante estudiante)
        {
            this.estudiante = estudiante;
            
        }

        [HttpPost("agregarEstudiante")]
        public ActionResult<string> AgregarEstudiante([FromBody] Estudiante estudiante)
        {
            try
            {
                //verificar que todas las validaciones por atributo del modello este correctas
                if (!ModelState.IsValid)
                {
                    //En caso de no cumplir con todas las validaciones se procede a retornar una respuesta erronea
                    return BadRequest(ModelState);
                }

                int contador = this.estudiante.AgregarEstudiante(estudiante);
                if (contador > 0)
                {
                    pCodRespuesta = Constants.COD_EXITO;
                    pMensajeUsuario = "Se agrego correctamente";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }

                else
                {
                    pCodRespuesta = Constants.COD_ERROR;
                    pMensajeUsuario = "Error inesperado, no se pudo agregar";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;

                }
                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });

            }
            catch (Exception)
            {
                throw;
            }

        }


        [HttpPut("actualizarEstudiante/{idEstudiante}")]
        public ActionResult<string> ActualizarEstudiante(int idEstudiante, [FromBody] Estudiante estudiante)
        {
            try
            {
                //verificar que todas las validaciones por atributo del modello este correctas
                if (!ModelState.IsValid)
                {
                    //En caso de no cumplir con todas las validaciones se procede a retornar una respuesta erronea
                    return BadRequest(ModelState);
                }
                int contador = this.estudiante.ActualizarEstudiante(idEstudiante,estudiante);

                if (contador > 0)
                {
                    pCodRespuesta = Constants.COD_EXITO;
                    pMensajeUsuario = "Se actulizo correctamente";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;

                }
                else
                {
                    pCodRespuesta = Constants.COD_ERROR;
                    pMensajeUsuario = "Error inesperado, no se pudo actualizar";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;

                }
                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });

            }
            catch (Exception)
            {
                throw;
            }

        }


        [HttpDelete("eliminarEstudiante/{idEstudiante}")]
        public ActionResult<string> EliminarEstudiante(int idEstudiante)
        {
            try
            {
                bool eliminado = this.estudiante.EliminarEstudiante(idEstudiante);
                if (eliminado)
                {
                    pCodRespuesta = Constants.COD_EXITO;
                    pMensajeUsuario = "Se elimino correctamente";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;

                }
                else
                {
                    pCodRespuesta = Constants.COD_ERROR;
                    pMensajeUsuario = "Error inesperado, no se pudo eliminar";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {
                throw;
            }

        }



        [HttpGet("obtenerEstudiantePorID/{idEstudiante}")]
        public ActionResult<Estudiante> ObtenerEstudiantePorID(int idEstudiante)
        {
            try
            {
                Estudiante estudiante = this.estudiante.ObtenerEstudiantesPorID(idEstudiante);
                if (estudiante != null)
                {
                    return Ok(estudiante);

                }
                else
                {
                    pCodRespuesta = Constants.COD_ERROR;
                    pMensajeUsuario = "Error inesperado, no se pudo agregar";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                    return NotFound(new {pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
                }

                
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpGet("obtenerEstudiantes")]
        public ActionResult<List<Estudiante>> ObtenerEstudiantes()
        {
            try
            {
                List<Estudiante> lstEstudiantes = this.estudiante.ObtenerTodosLosEstudiantes();
                return Ok(lstEstudiantes);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }


}
