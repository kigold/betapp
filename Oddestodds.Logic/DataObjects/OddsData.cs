using System;
using System.Collections.Generic;
using System.Text;

namespace Oddestodds.Logic.DataObjects
{
    public class OddsData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Home { get; set; }
        public double Away { get; set; }
        public double Draw { get; set; }

    }
}
