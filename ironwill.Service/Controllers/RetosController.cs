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
    public class RetosController : Controller
    {
        private readonly IRetosRepository _Reto;
        private readonly AppSettings _appSettings;

        public RetosController(IRetosRepository _iReto, IOptions<AppSettings> appSettings)
        {
            _Reto = _iReto;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync(Retos model)
        {
            Response<string> response = new Response<string>();
            try
            {
                if (model == null)
                    return BadRequest();

                var result = await _Reto.InsertAsync(model);
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
        public async Task<IActionResult> UpdateAsync(Retos model)
        {
            Response<string> response = new Response<string>();
            try
            {
                if (model == null)
                    return BadRequest();

                var result = await _Reto.UpdateAsync(model);
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

        [HttpDelete("{IdRetos}")]
        public async Task<IActionResult> DeleteAsync(int IdRetos)
        {
            Response<string> response = new Response<string>();

            try
            {
                var result = await _Reto.DeleteAsync(IdRetos);

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
        public async Task<IActionResult> GetRetos(int IdUsuario)
        {
            Response<IEnumerable<Retos>> response = new Response<IEnumerable<Retos>>();

            try
            {
                var result = await _Reto.getRetos(IdUsuario);

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
