using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace curso.api.Models.Usuarios
{

    ///<summary>
    ///Este serviço permite autenticar um usuário cadastrado e ativo.
    ///</summary>
    ///<param name="LoginViewModelInput"></param>
    ///<returns>Retorna o status OK e o token de acesso em caso de sucesso.</returns>


    public class LoginViewModelInput
    {
        [Required(ErrorMessage = "O Login é obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "A Senha é obrigatória")]
        public string Senha { get; set; }
    }
}
