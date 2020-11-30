using curso.api.Models.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curso.api.Controllers
{
    [Route("api/v1/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        ///<summary>
        ///Este serviço permite autenticar um usuário cadastrado e ativo.
        ///</summary>
        ///<param name="LoginViewModelInput"></param>
        ///<returns>Retorna o status OK e o token de acesso em caso de sucesso.</returns>

        [SwaggerResponse(statusCode:200, description:"Sucesso ao autenticar", type: typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos Obrigatórios", type: typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno do servidor", type: typeof(ErroGenericoViewModelOutput))]
        [HttpPost]
        [Route("logar")]
        public IActionResult Logar(LoginViewModelInput loginViewModelInput) {

            return Ok(loginViewModelInput);

        }


        ///<summary>
        ///Este serviço permite cadastrar um usuário com e-mail, login e senha.
        ///</summary>
        ///<param name="RegistroViewModelInput"></param>
        ///<returns>Retorna o status OK e o token de acesso em caso de sucesso.</returns>

        [SwaggerResponse(statusCode:200, description:"Sucesso ao cadastrar", type: typeof(RegistroViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos Obrigatórios", type: typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno do servidor", type: typeof(ErroGenericoViewModelOutput))]
        [HttpPost]
        [Route("registrar")]
        public IActionResult Registrar(RegistroViewModelInput registroViewModelInput)
        {

            return Created("", registroViewModelInput);

        }
    }
}
