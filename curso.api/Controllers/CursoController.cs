using curso.api.Models.Cursos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace curso.api.Controllers
{
    [Route("api/v1/cursos")]
    [ApiController]
    [Authorize]
    public class CursoController : ControllerBase
    {
        ///<summary>
        ///Este serviço permite cadastrar um curso.
        ///</summary>
        ///<param name="CursoViewModelInput"></param>
        ///<returns>Retorna o status 201 e dados do curso do usuario.</returns>

        [SwaggerResponse(statusCode: 201, description: "Cadastrado com Sucesso", type: typeof(CursoViewModelInput))]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post(CursoViewModelInput cursoViewModelInput) 
        {
            var codigoUsusario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

            return Created("", cursoViewModelInput);
        }

        ///<summary>
        ///Este serviço obtem todos os cursos cadastrados
        ///</summary>
        ///<param name="CursoViewModelInput"></param>
        ///<returns>Retorna o status 201 e dados do curso do usuario.</returns>
        ///
        [SwaggerResponse(statusCode: 201, description: "Cadastrado com Sucesso", type: typeof(CursoViewModelInput))]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            var listaCurso = new List<CursoViewModelOutput>();

            //var codigoUsusario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

            listaCurso.Add(new CursoViewModelOutput()
            {
                Nome = "ASP.NET Core",
                Descricao = "Desenvolvimento em .NET Core",
                Login = "gustavo_gcs@teste.com"
            });

            listaCurso.Add(new CursoViewModelOutput()
            {
                Nome = "Spring Framework",
                Descricao = "Desenvolvimento Java com Spring Framework",
                Login = "gustavo_gcs@teste.com"
            });

            listaCurso.Add(new CursoViewModelOutput()
            {
                Nome = "Oracle DB",
                Descricao = "Operações de DB Oracle",
                Login = "gustavo_gcs@teste.com"
            });

            return Ok(listaCurso);
        }

    }
}
