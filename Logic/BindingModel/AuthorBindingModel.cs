using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Logic.BindingModel
{
    [DataContract]
    public class AuthorBindingModel
    {
        public int? Id { get; set; }

        public int ArticleId { get; set; }

        public string AuthorName { get; set; }

        public string Email { get; set; }

        public DateTime Birthday { get; set; }

        public string Place { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }
    }
}
