using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace curso.api.Models.Usuarios
{

    ///<summary>
    ///Este serviço permite cadastrar um usuário com e-mail, login e senha.
    ///</summary>
    ///<param name="RegistroViewModelInput"></param>
    ///<returns>Retorna o status OK e o cadastro do usuário em caso de sucesso.</returns>

    public class RegistroViewModelInput
    {
        [Required (ErrorMessage = "O Login é obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O E-mail é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O Senha é obrigatório")]
        public string Senha { get; set; }

    }
}
