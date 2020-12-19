using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Logic.BindingModel
{
    [DataContract]
    public class DopBindingModel
    {
        public int? Id { get; set; }

        public int OsnvId { get; set; }

        public string DopName { get; set; }

        public int Count { get; set; }

        public DateTime DataCreateDop { get; set; }

        public string Place { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }
    }
}
