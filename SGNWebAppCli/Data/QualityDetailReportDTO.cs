namespace SGNWebAppCli.Data
{
    public class QualityDetailReportDTO
    {
        public short IdCurrencyFaceValue { get; set; }
        public decimal FaceValue { get; set; }
        public long CountedCount { get; set; }
        public long Count { get; set; }
        public string QualityValue { get; set; }
        public string Symbol { get; set; }
        public string ModeValue { get; set; }
    }
}
