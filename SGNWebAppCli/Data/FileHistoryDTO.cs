using System;

namespace SGNWebAppCli.Data
{
    public class FileHistoryDTO
    {
        public long IdFileHistory { get; set; }
        public string FileName { get; set; }
        public bool IsProceededSuccess { get; set; }
        public string ErrorDescription { get; set; }
        public DateTime ProcessDate { get; set; }
        public long? IdCountResult { get; set; }
    }
}
