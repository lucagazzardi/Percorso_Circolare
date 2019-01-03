using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.AppServices.Interfaces;
using BL.Models;
using DAL;
using DAL.Repository;

namespace BL.AppServices
{  
    public class CourseAppService : ICourseAppService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseAppService()
        {            
            _courseRepository = new UnitOfWork().CourseRepository;
        }

        public CourseDto GetCourseById(int courseId)
        {
            Course course = _courseRepository.GetCourseById(courseId);

            return new CourseDto()
            {
                Id = course.Id,
                Description = course.Description,
                Year = course.Year,
                BeginDate = course.BeginDate,
                EndDate = course.EndDate,
                ResourceId = course.ResourceId,
                ResourceName = course.Resource.FirstName + " " + course.Resource.LastName
            };
        }

        public List<CourseDto> GetCourses()
        {
            return _courseRepository.GetAll().AsQueryable()
                .Select(x => new CourseDto()
                {
                    Id = x.Id,
                    Description = x.Description,
                    Year = x.Year,
                    BeginDate = x.BeginDate,
                    EndDate = x.EndDate,
                    ResourceId = x.ResourceId,
                    ResourceName = x.Resource.FirstName + " " + x.Resource.LastName
                })
                .ToList();
        }

        public void Insert(CourseDto course)
        {
            Course newItem = new Course()
            {
                Description = course.Description,
                Year = course.Year,
                BeginDate = course.BeginDate,
                EndDate = course.EndDate,
                ResourceId = course.ResourceId
            };

            _courseRepository.Insert(newItem);
        }
    }
}
