using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Model
{
    public class ResponceModel<T>
    {
        public bool Status { get; set; }

        public string Massage { get; set; }

        public T Data { get; set; }
    }
}
