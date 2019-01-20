using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Suren.Models
{
    public class Target
    {
        [Key]
        public int TargetId { get; set; }
        public string TargetName { get; set; }
        public string Remark { get; set; }
        public int Status { get; set; }
        public int ProjectId { get; set; }
        //[ForeignKey("ProjectId")]
        public Project Project { get; set; }

        public virtual List<Point> Points { get; set; }
    }
}
