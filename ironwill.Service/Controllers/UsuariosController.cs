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
    public class UsuariosController : Controller
    {
        private readonly IUsuarioRepository _Usuario;
        private readonly AppSettings _appSettings;

        public UsuariosController(IUsuarioRepository _iUsuario, IOptions<AppSettings> appSettings)
        {
            _Usuario = _iUsuario;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync(Usuarios model)
        {
            Response<string> response = new Response<string>();
            try
            {
                if (model == null)
                    return BadRequest();

                var result = await _Usuario.InsertAsync(model);
                if (result == "success")
                {
                    response.Data = result;
                    response.IsSuccess = true;
                    response.Message = "";

                    return Ok(response);
                } else
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
        public async Task<IActionResult> UpdateAsync(Usuarios model)
        {
            Response<string> response = new Response<string>();
            try
            {
                if (model == null)
                    return BadRequest();

                var result = await _Usuario.UpdateAsync(model);
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

        [HttpDelete("{IdUsuario}")]
        public async Task<IActionResult> DeleteAsync(int IdUsuario)
        {
            Response<string> response = new Response<string>();

            try
            {
                var result = await _Usuario.DeleteAsync(IdUsuario);

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

        [HttpGet("{Correo}/{Clave}")]
        public async Task<IActionResult> GetUserByLogin(string Correo, string Clave)
        {
            Response<Usuarios> response = new Response<Usuarios>();

            try
            {
                var result = await _Usuario.getUserByLogin(Correo, Clave);
                
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
                    response.Message = "Correo o contraseña incorrectos";

                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = "Correo o contraseña incorrectos";

                return BadRequest(response);
            }
        }

    }
}
