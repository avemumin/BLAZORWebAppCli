namespace SGNWebAppCli.Data
{
    public class QualityDetail
    {
        //id slownika
        public short IdCurrencyFaceValue { get; set; }
        //nominal
        public decimal FaceValue { get; set; }
        public long CountedCount { get; set; }
        //ilosc
        public long Count { get; set; }
        public string QualityValue { get; set; }
        public string Symbol { get; set; }
        public string ModeValue { get; set; }
        public short IdCurrency { get; set; }
    }
}
