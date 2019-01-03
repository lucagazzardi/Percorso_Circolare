using BL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices.Interfaces
{
    public interface ILessonAppService
    {
        LessonDto GetLessonById(int lessonId);
        List<LessonDto> GetLessons();
        void Insert(LessonDto lesson);
        void DeleteLesson(int lessonId);
    }
}
