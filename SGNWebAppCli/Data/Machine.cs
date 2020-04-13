using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGNWebAppCli.Data
{
    public class Machine
    {
        public int IdMachine { get; set; }
        public string Model { get; set; }
        public string Sn { get; set; }
        public string SoftwareVersion { get; set; }

        public ICollection<QualityDetailAndMachine> QualityDetails { get; set; }
    }
}
