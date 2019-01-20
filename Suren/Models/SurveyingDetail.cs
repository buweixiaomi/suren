using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Suren.Models
{
    public class SurveyingDetail
    {
        [Key]
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int TargetId { get; set; }
        public int SurveyingId { get; set; }
        public int PointId { get; set; }
        public decimal Data1 { get; set; }
        public decimal Data2 { get; set; }
        public decimal Data3 { get; set; }
        public decimal Data4 { get; set; }
        public int NoUseable { get; set; }
        public string Remark { get; set; }


       // [ForeignKey("ProjectId")]
        public Project Project { get; set; }
        //[ForeignKey("TargetId")]
        public Target Target { get; set; }
        //[ForeignKey("PointId")]
        public Point Point { get; set; }
        //[ForeignKey("SurveyingId")]
        public Surveying Surveying { get; set; }

        //extends
        public string PointName { get; set; }
        public string ProjectName { get; set; }
        public string TargetName { get; set; }
        public string SurveyingName { get; set; }
        public DateTime SurveyingTime { get; set; }
    }
}
