using System;

namespace DataAccess.Models
{
    public class LoggingModel
    {
        public int ID { get; set; }

        public DateTime When { get; set; }

        public string? Message { get; set; }

        public string? Level { get; set; }

        public string? Exception { get; set; }

        public string?  Trace { get; set; }

        public string? Logger { get; set; }
                   

    }
}
