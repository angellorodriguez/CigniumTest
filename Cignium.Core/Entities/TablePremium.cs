using System;
using System.Collections.Generic;
using System.Text;

namespace Cignium.Core.Entities
{
    public class TablePremium
    {
        public string State { get; set; }
        public string MonthOfBirth { get; set; }
        public int AgeMin { get; set; }
        public int AgeMax { get; set; }
        public double Premium { get; set; }
    }
}
