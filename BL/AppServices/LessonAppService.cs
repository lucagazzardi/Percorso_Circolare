using BL.AppServices.Interfaces;
using BL.Models;
using DAL;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    public class LessonAppService : ILessonAppService
    {
        private readonly ILessonRepository _lessonRepository;

        public LessonAppService()
        {
            _lessonRepository = new UnitOfWork().LessonRepository;
        }

        public LessonDto GetLessonById(int lessonId)
        {
            Lesson lesson = _lessonRepository.GetLessonById(lessonId);

            return new LessonDto()
            {
                Id = lesson.Id,
                Description = lesson.Description,
                Module = lesson.Module.Name,
                Course = lesson.Course.Description,
                LectureDate = lesson.LectureDate,
                Teacher = lesson.Teacher.FirstName + " " + lesson.Teacher.LastName,
                Backup = lesson.Backup.FirstName + " " + lesson.Backup.LastName,
                Classroom = lesson.Classroom.Name
            };
        }

        public List<LessonDto> GetLessons()
        {
            return _lessonRepository.GetAll().AsQueryable()
                .Select(x => new LessonDto()
                {
                    Id = x.Id,
                    Description = x.Description,
                    Course = x.Course.Description,
                    Module = x.Module.Description,
                    LectureDate = x.LectureDate,
                    ClassroomId = x.ClassroomId,
                    Classroom = x.Classroom.Name,
                    Teacher = x.Teacher.FirstName + " " + x.Teacher.LastName,
                    Backup = x.Backup.FirstName + " " + x.Backup.LastName,
                })
                .ToList();
        }

        public void Insert(LessonDto lesson)
        {
            Lesson newItem = new Lesson()
            {
                Description = lesson.Description,
                ModuleId = lesson.ModuleId,
                CourseId = lesson.CourseId,
                LectureDate = lesson.LectureDate,
                TeacherResourceId = lesson.TeacherId,
                BackupResourceId = lesson.BackupId,
                ClassroomId = lesson.ClassroomId                

            };

            _lessonRepository.Insert(newItem);
        }

        public void DeleteLesson(int lessonId)
        {
            _lessonRepository.Delete(lessonId);
        }
    }
}
