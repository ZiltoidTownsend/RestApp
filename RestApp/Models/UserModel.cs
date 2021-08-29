using RestApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;

namespace RestApp.Models
{
    public class UserModel : BaseInpc
    {
        private string login;
        private string password;
        private string role;
        public string Login { get => login; set => Set(ref login, value); }
        public string Password { get => password; set => Set(ref password, value); }
        [JsonIgnore]
        public string Role { get => role; set => Set(ref role, value); }
        [JsonIgnore]
        public CookieContainer Cookies { get; set; }
    }
}
