using ModelLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Model
{
    public class BookStoreDataBaseSetting : IBookStoreDataBaseSetting
    {
        public string ConnectionString { get; set; }

        public string DataBaseName { get; set; }
       
    }
}
