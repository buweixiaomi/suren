using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Suren.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Remark { get; set; }

        public int Status { get; set; }

        public virtual List<Target> Targets { get; set; }
        public virtual List<Surveying> Surveyings { get; set; }
    }
}
