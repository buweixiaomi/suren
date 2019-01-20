using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Suren.Models
{
    public class SurDataGen
    {
        public int ProjectId { get; set; }
        public int TargetId { get; set; }
        public int PointId { get; set; }
        public int SurveyingId { get; set; }
        public DateTime SurveyingTime { get; set; }
        public decimal? Data1 { get; set; }
    }
}
