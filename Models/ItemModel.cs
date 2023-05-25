using System;
using System.Collections.Generic;

namespace Shop.Models
{
    public class ItemModel
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public Dictionary<string, string> Properties {get; set;} 
    }
}
