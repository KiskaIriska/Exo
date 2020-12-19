using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Logic.BindingModel
{
    [DataContract]
    public class ArticleBindingModel
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public DateTime DateCreate { get; set; }

        public List<AuthorBindingModel> Authors { get; set; }
    }
}
