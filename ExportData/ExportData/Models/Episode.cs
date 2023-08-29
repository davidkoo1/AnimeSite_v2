using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportData.Models
{
    public class Episode
    {
        public string AnimeName { get; set; }
        public int SeasonNumber { get; set; }
        public int EpisodeNumber { get; set; }
        public string EpisodeSrc { get; set; }
        public DateTime Date { get; set; }
    }
}
