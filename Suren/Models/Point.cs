using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Suren.Models
{
    public class Point
    {
        [Key]
        public int PointId { get; set; }
        public string PointName { get; set; }
        public string Remark { get; set; }
        public int Status { get; set; }
        public int ProjectId { get; set; }
        public int TargetId { get; set; }
        //[ForeignKey("ProjectId")]
        public Project Project { get; set; }
        //[ForeignKey("TargetId")]
        public Target Target { get; set; }
    }
}
