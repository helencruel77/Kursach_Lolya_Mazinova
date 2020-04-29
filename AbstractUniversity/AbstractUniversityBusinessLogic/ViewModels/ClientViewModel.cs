using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace AbstractUniversityBusinessLogic.ViewModels
{
    [DataContract]
    public class ClientViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [DisplayName("Имя")]
        public string ClientName { get; set; }
        [DataMember]
        [DisplayName("Фамилия")]
        public string ClientLastName { get; set; }
        [DataMember]
        [DisplayName("Почта")]
        public string Email { get; set; }
        [DataMember]
        [DisplayName("Пароль")]
        public string Password { get; set; }
        [DataMember]
        [DisplayName("Логин")]
        public string Login { get; set; }
    }
}
