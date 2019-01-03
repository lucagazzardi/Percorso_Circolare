using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    /// <summary>
    /// Represents a Course
    /// </summary>
    public class CourseDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? Year { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? ResourceId { get; set; }
        public string ResourceName { get; set; }

    }
}
