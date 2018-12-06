using System;
using System.Collections.Generic;

namespace ElectronicsAPI.Models
{
    public partial class Electronics
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
