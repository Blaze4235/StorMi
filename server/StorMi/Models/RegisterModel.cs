﻿using System.ComponentModel.DataAnnotations;

namespace StoMi.ViewModels
{
    public class RegisterModel
    {
        [Required]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        [Required]
        public string ConfirmPassword { get; set; }
    }
}