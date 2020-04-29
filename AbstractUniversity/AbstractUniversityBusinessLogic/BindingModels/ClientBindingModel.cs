using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractUniversityBusinessLogic.BindingModels
{
    public class ClientBindingModel //client
    {
        public int? Id { get; set; }
        public string ClientName { get; set; }
        public string ClientLastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
    }
}
