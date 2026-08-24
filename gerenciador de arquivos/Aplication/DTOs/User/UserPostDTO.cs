using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication.DTOs.User
{
    public class UserPostDTO                                                                                                                               
    {                                                                                                                                                      
        [Required(ErrorMessage = "O nome de usuário é obrigatório")]                                                                                       
        [MaxLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]                                                                        
        public string UserName { get; set; } = string.Empty;                                                                                               

        [Required(ErrorMessage = "A senha é obrigatória")]                                                                                                 
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres")]                                                                           
        public string Password { get; set; } = string.Empty;                                                                                               
    }   
}