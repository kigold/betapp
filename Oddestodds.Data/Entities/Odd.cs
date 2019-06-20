using System;
using System.Collections.Generic;
using System.Text;

namespace Oddestodds.Data.Entities
{
    public class Odd
    {
        public int Id { get; set; }
        public string Name {get; set;}
        public double Home { get; set; }
        public double Away { get; set; }
        public double Draw { get; set; }
    }
}
