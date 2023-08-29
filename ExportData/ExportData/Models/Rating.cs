using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportData.Models
{
    public class Rating
    {
        public string AnimeName { get; set; }
        public int SeasonNumber { get; set; }
        public string AppUserId { get; set; }
        public int Mark { get; set; }
    }
}
