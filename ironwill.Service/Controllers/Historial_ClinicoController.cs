using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ironwill.Models;
using ironwill.Service.Common;
using ironwill.Service.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ironwill.Service.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Historial_ClinicoController : Controller
    {
        private readonly IHistorial_ClinicoRepository _Historial;
        private readonly AppSettings _appSettings;

        public Historial_ClinicoController(IHistorial_ClinicoRepository _iHistorial, IOptions<AppSettings> appSettings)
        {
            _Historial = _iHistorial;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync(Historial_Clinico model)
        {
            Response<string> response = new Response<string>();
            try
            {
                if (model == null)
                    return BadRequest();

                var result = await _Historial.InsertAsync(model);
                if (result == "success")
                {
                    response.Data = result;
                    response.IsSuccess = true;
                    response.Message = "";

                    return Ok(response);
                }
                else
                {
                    response.Data = null;
                    response.IsSuccess = false;
                    response.Message = result;

                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Historial_Clinico model)
        {
            Response<string> response = new Response<string>();
            try
            {
                if (model == null)
                    return BadRequest();

                var result = await _Historial.UpdateAsync(model);
                if (result == "success")
                {
                    response.Data = result;
                    response.IsSuccess = true;
                    response.Message = "";

                    return Ok(response);
                }
                else
                {
                    response.Data = null;
                    response.IsSuccess = false;
                    response.Message = result;

                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }

        [HttpDelete("{IdHistorialClinico}")]
        public async Task<IActionResult> DeleteAsync(int IdHistorialClinico)
        {
            Response<string> response = new Response<string>();

            try
            {
                var result = await _Historial.DeleteAsync(IdHistorialClinico);

                if (result == "success")
                {
                    response.Data = result;
                    response.IsSuccess = true;
                    response.Message = "Registro eliminado correctamente.";

                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }

        [HttpGet("{IdUsuario}")]
        public async Task<IActionResult> GetHistorial_Clinico(int IdUsuario)
        {
            Response<IEnumerable<Historial_Clinico>> response = new Response<IEnumerable<Historial_Clinico>>();

            try
            {
                var result = await _Historial.getHistorial_Clinico(IdUsuario);

                if (result != null)
                {
                    response.Data = result;
                    response.IsSuccess = true;
                    response.Message = string.Empty;

                    return Ok(response);
                }
                else
                {
                    response.Data = null;
                    response.IsSuccess = false;
                    response.Message = "No se encontraron registros";

                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = "Ha ocurrido un error, inesperado. " + ex.Message;

                return BadRequest(response);
            }
        }

    }
}
