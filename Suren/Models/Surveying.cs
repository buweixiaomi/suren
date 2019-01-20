using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Suren.Models
{
    public class Surveying
    {
        [Key]
        public int SurveyingId { get; set; }
        public string SurveyingName { get; set; }
        public DateTime SurveyingTime { get; set; }
        public string DayWeather { get; set; }
        public string SurveyingMan { get; set; }
        public string DataUnit { get; set; }

        public string Remark { get; set; }
        public int ProjectId { get; set; }
        public int TargetId { get; set; }
        public int Status { get; set; }

       // [ForeignKey("ProjectId")]
        public Project Project { get; set; }
        //[ForeignKey("TargetId")]
        public Target Target { get; set; }

        public virtual List<SurveyingDetail> SurveyingDetails { get; set; }
    }
}
