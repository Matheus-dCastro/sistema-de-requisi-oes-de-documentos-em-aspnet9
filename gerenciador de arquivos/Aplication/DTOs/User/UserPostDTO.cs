using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication.DTOs.User
{
    public class UserPostDTO
    {
        [Required(ErrorMessage ="O campo é obrigatorio")]
        [MaxLength(100, ErrorMessage ="O nome deve ter no maximo 100 caracteres")]
        public string UserName { get; set; } = string.Empty;
    }
}