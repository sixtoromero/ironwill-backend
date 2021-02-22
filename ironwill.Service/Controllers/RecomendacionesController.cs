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
    public class RecomendacionesController : Controller
    {
        private readonly IRecomendacionesRepository _Recomendaciones;
        private readonly AppSettings _appSettings;

        public RecomendacionesController(IRecomendacionesRepository _iRecom, IOptions<AppSettings> appSettings)
        {
            _Recomendaciones = _iRecom;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync(Recomendaciones model)
        {
            Response<string> response = new Response<string>();
            try
            {
                if (model == null)
                    return BadRequest();

                var result = await _Recomendaciones.InsertAsync(model);
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
        public async Task<IActionResult> UpdateAsync(Recomendaciones model)
        {
            Response<string> response = new Response<string>();
            try
            {
                if (model == null)
                    return BadRequest();

                var result = await _Recomendaciones.UpdateAsync(model);

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

        [HttpDelete("{IdRecomendaciones}")]
        public async Task<IActionResult> DeleteAsync(int IdRecomendacion)
        {
            Response<string> response = new Response<string>();

            try
            {
                var result = await _Recomendaciones.DeleteAsync(IdRecomendacion);

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
        public async Task<IActionResult> GetRecomendaciones(int IdUsuario)
        {
            Response<IEnumerable<Recomendaciones>> response = new Response<IEnumerable<Recomendaciones>>();

            try
            {
                var result = await _Recomendaciones.getRecomendaciones(IdUsuario);

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
