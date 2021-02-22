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
    public class Tipos_EjerciciosController : Controller
    {
        private readonly ITipos_EjerciciosRepository _Tipos_Ejercicios;
        private readonly AppSettings _appSettings;

        public Tipos_EjerciciosController(ITipos_EjerciciosRepository _iTipos_Ejercicios, IOptions<AppSettings> appSettings)
        {
            _Tipos_Ejercicios = _iTipos_Ejercicios;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync(Tipos_Ejercicios model)
        {
            Response<string> response = new Response<string>();
            try
            {
                if (model == null)
                    return BadRequest();

                var result = await _Tipos_Ejercicios.InsertAsync(model);
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
        public async Task<IActionResult> UpdateAsync(Tipos_Ejercicios model)
        {
            Response<string> response = new Response<string>();
            try
            {
                if (model == null)
                    return BadRequest();

                var result = await _Tipos_Ejercicios.UpdateAsync(model);
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

        [HttpDelete("{IdTipos_Ejercicios}")]
        public async Task<IActionResult> DeleteAsync(int IdTipoEjercicio)
        {
            Response<string> response = new Response<string>();

            try
            {
                var result = await _Tipos_Ejercicios.DeleteAsync(IdTipoEjercicio);

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
        public async Task<IActionResult> GetTipos_Ejercicios(int IdUsuario)
        {
            Response<IEnumerable<Tipos_Ejercicios>> response = new Response<IEnumerable<Tipos_Ejercicios>>();

            try
            {
                var result = await _Tipos_Ejercicios.getTipos_Ejercicios(IdUsuario);

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
