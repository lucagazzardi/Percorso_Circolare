using BL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices.Interfaces
{
    public interface ICourseAppService
    {
        CourseDto GetCourseById(int courseId);
        List<CourseDto> GetCourses();
        void Insert(CourseDto course);
    }
}
