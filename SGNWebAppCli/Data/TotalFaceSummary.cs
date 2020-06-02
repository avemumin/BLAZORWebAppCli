using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGNWebAppCli.Data
{
    /// <summary>
    /// Help class to Linq grouping summary report
    /// grouped by IdCurrency than IdCurrencyFaceValue
    /// </summary>
    public class TotalFaceSummary
    {
        public short IdCurrencyFaceValue { get; set; }
        public long Count { get; set; }
        public string Symbol { get; set; }
        public short IdCurrency { get; set; }
        public decimal FaceValue { get; set; }
    }
}
