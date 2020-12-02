using curso.api.Filters;
using curso.api.Models;
using curso.api.Models.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
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
        [ValidacaoModelStateCustomizado]
        public IActionResult Logar(LoginViewModelInput loginViewModelInput)
        {

            // manual user creation only for tests, remove after creating DB connection
            var usuarioViewModelOutput = new UsuarioViewModelOutput()
            {

                Codigo = 1,
                Login = "GustavoCSilva",
                Email = "gustavo@teste.com"
            
            };

            var secret = Encoding.ASCII.GetBytes("@_S3cReT_T0kEn_@");
            var symmetricSecurityKey = new SymmetricSecurityKey(secret);

            // configuration of the descriptor of the token data received
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, usuarioViewModelOutput.Codigo.ToString()),
                    new Claim(ClaimTypes.Name, usuarioViewModelOutput.Login.ToString()),
                    new Claim(ClaimTypes.Email, usuarioViewModelOutput.Email.ToString())
                }),

                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            // token generation using the descriptor definition
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenGenerated = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(tokenGenerated);

            return Ok(new 
            { 
                Token = token, 
                Usuario = usuarioViewModelOutput 
            });

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
        [ValidacaoModelStateCustomizado]
        public IActionResult Registrar(RegistroViewModelInput registroViewModelInput)
        {

            return Created("", registroViewModelInput);

        }
    }
}
