using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyEvernote.WebApp.ViewModels
{
    public class RegisterViewModel
    {
        [DisplayName("Kullanıcı Adı"), Required(ErrorMessage = "{0} boş geçilemez!"),StringLength(25,ErrorMessage ="{0} maximum 25 karakter olmalı.")]
        public string Username { get; set; }

        [DisplayName("EPosta"), Required(ErrorMessage = "{0} boş geçilemez!"), StringLength(70, ErrorMessage = "{0} maximum 25 karakter olmalı."),EmailAddress(ErrorMessage ="Geçerli bir Email adresi giriniz.")]

        public string EMail { get; set; }

        [DisplayName("Şifre"), Required(ErrorMessage = "{0} boş geçilemez!"), StringLength(25, ErrorMessage = "{0} maximum 25 karakter olmalı.")]
        public string Password { get; set; }

        [DisplayName("Şifre Tekrar"), Required(ErrorMessage = "{0} boş geçilemez!"), StringLength(25, ErrorMessage = "{0} maximum 25 karakter olmalı."),Compare("Password",ErrorMessage ="Şifre ve ŞifreTekrar uyuşmuyor!")]
        public string RePassword { get; set; }
    }
}