using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsBlog
{
    public class Items
    {
        public string Id { get; set; }
        public string Value { get; set; }

        public Items() { }

        public Items(string id, string value)
        {
            Value = value;
            Id = id;
        }

    }
}
