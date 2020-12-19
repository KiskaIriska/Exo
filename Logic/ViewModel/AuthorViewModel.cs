using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace Logic.ViewModel
{
    [DataContract]
    public class AuthorViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int ArticleId { get; set; }

        [DataMember]
        [DisplayName("ФИО")]
        public string AuthorName { get; set; }

        [DataMember]
        [DisplayName("Email")]
        public string Email { get; set; }

        [DataMember]
        [DisplayName("День рождения")]
        public DateTime Birthday { get; set; }

        [DataMember]
        [DisplayName("Место работы")]
        public string Place { get; set; }

        [DataMember]
        [DisplayName("Название статьи")]
        public string Name { get; set; }

        public DateTime DateCreate { get; set; }
    }
}
