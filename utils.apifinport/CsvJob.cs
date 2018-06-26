using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using entities.apifinport.Entities;
using entities.apifinport.Mappers;
using CsvHelper;

namespace utils.apifinport
{
    public class CsvJob
    {
        public string filename { get; set; }

        public CsvJob(string filename)
        {
            this.filename = filename;
        }

        public List<TickerCSVMapper> GetAllTickers()
        {
            List<TickerEntity> CsvData = new List<TickerEntity>();
            IEnumerable<TickerCSVMapper> Records = new List<TickerCSVMapper>();
            using (TextReader fileReader = File.OpenText(this.filename))
            {
                try
                {
                    var csv = new CsvReader(fileReader);
                    csv.Configuration.HasHeaderRecord = false;
                    Records = csv.GetRecords<TickerCSVMapper>().ToList();
                    Records = Records.Skip(1);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.InnerException.Message);
                }
            }
            return Records.ToList();
        }
    }
}
