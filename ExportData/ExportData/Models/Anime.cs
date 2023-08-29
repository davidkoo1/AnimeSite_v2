using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportData.Models
{
    public class Anime
    {
        public int EditorId { get; set; }
        public string AnimeName { get; set; }
        public string? Description { get; set; }
        public string TitleImage { get; set; }
        public string Trailer { get; set; }
    }
}
