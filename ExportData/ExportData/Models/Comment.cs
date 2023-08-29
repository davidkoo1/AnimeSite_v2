using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportData.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string AnimeName { get; set; }
        public int SeasonNumber { get; set; }
        public int EpisodeNumber { get; set; }
        public string AppUserId { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}
