using ADSProjetc.Interfaces;
using ADSProjetc.Models;
using Microsoft.AspNetCore.Mvc;
using ADSProjetc.Utils;
using System.Text.RegularExpressions;

namespace ADSProjetc.Controllers
{
    [ApiController]//para el manejo eficinete de errores
    [Route("api/grupos")]
    public class GruposController:ControllerBase
    {
        private readonly IGrupo grupo;
        private string pCodRespuesta;
        private string pMensajeUsuario;
        private string pMensajeTecnico;

        public GruposController(IGrupo grupo)
        {
            this.grupo = grupo;
        }

        [HttpPost("agregarGrupo")]
        public ActionResult<string> AgregarGrupo(Grupo grupo)
        {
            try
            {
               
                int contador = this.grupo.AgregarGrupo(grupo);
                if (contador > 0)
                {
                    pCodRespuesta = Constants.COD_EXITO;
                    pMensajeUsuario = "Registro insertado con exito";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = Constants.COD_ERROR;
                    pMensajeUsuario = "Ocurrio un problema al insertar el registro";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPut("actualizarGrupo/{idGrupo}")]
        public ActionResult<string> ActualizarGrupo(int idGrupo,Grupo grupo)
        {
            try
            {
               
                int contador = this.grupo.ActualizarGrupo(idGrupo, grupo);
                if (contador > 0)
                {
                    pCodRespuesta = Constants.COD_EXITO;
                    pMensajeUsuario = "Registro actualizado con exito";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = Constants.COD_ERROR;
                    pMensajeUsuario = "Ocurrio un problema al actualizar el registro";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }

                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpDelete("eliminarGrupo/{idGrupo}")]
        public ActionResult<string> EliminarGrupo(int idGrupo)
        {
            try
            {
                bool eliminado = this.grupo.EliminarGrupo(idGrupo);
                if (eliminado)
                {
                    pCodRespuesta = Constants.COD_EXITO;
                    pMensajeUsuario = "Registro eliminado con exito";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = Constants.COD_ERROR;
                    pMensajeUsuario = "Ocurrio un problema al eliminar el registro";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }

                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet("obtenerGrupoPorID/{idGrupo}")]
        public ActionResult<Grupo> ObtenerGrupoPorID(int idGrupo)
        {
            try
            {
                Grupo grupo = this.grupo.ObtenerGrupoPorID(idGrupo);
                if (grupo != null)
                {
                    return Ok(grupo);
                }
                else
                {
                    pCodRespuesta = Constants.COD_ERROR;
                    pMensajeUsuario = "No e encontraron datos del grupo";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;

                    return NotFound(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet("obtenerGrupos")]
        public ActionResult<List<Grupo>> ObtenerGrupos()
        {
            try
            {
                List<Grupo> grupoList = this.grupo.ObtenerTodosLosGrupos();
                return Ok(grupoList);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
