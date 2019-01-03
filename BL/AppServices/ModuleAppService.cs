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
    public class ModuleAppService : IModuleAppService
    {
        private readonly IModuleRepository _moduleRepository;

        public ModuleAppService()        
        {
            _moduleRepository = new UnitOfWork().ModuleRepository;
        }

        public ModuleDto GetModuleById(int moduleId)
        {
            Module module = _moduleRepository.GetModuleById(moduleId);

            return new ModuleDto()
            {
                Id = module.Id,
                Name = module.Name,
                Description = module.Description,
                CourseId = module.CourseId,
                Course = module.Course.Description,
                Credits = module.Credits,
                LessonNumber = module.LessonsNumber
            };
        }

        public List<ModuleDto> GetModules()
        {
            return _moduleRepository.GetAll().AsQueryable()
                .Select(x => new ModuleDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    CourseId = x.CourseId,
                    Course = x.Course.Description,
                    Credits = x.Credits,
                    LessonNumber = x.LessonsNumber
                })
                .ToList();
        }

        public void Insert(ModuleDto module)
        {
            Module newItem = new Module()
            {
                Name = module.Name,
                Description = module.Description,
                CourseId = module.CourseId,
                Credits = module.Credits,
                LessonsNumber = (short)module.LessonNumber
            };

            _moduleRepository.Insert(newItem);
        }
    }
}
