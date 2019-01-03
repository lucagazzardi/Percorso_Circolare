using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class LessonDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Module { get; set; }
        public int ModuleId { get; set; }
        public string Course { get; set; }
        public int CourseId { get; set; }
        public DateTime? LectureDate { get; set; }
        public int? ClassroomId { get; set; }
        public string Classroom { get; set; }
        public string Teacher { get; set; }
        public int TeacherId { get; set; }
        public string Backup { get; set; }
        public int BackupId { get; set; }
    }
}
