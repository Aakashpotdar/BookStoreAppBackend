using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Interface
{
    public interface IBookStoreDataBaseSetting
    {
        public string ConnectionString { get; set; }

        public string DataBaseName { get; set; }
    }
}
