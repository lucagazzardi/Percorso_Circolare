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
    public class ClassroomAppService : IClassroomAppService
    {

        private readonly IClassroomRepository _classroomRepository;

        public ClassroomAppService()
        {
            _classroomRepository = new UnitOfWork().ClassroomRepository;
        }

        public Classroom GetClassroomById(int courseId)
        {
            return _classroomRepository.GetById(courseId);
        }

        public List<ClassroomDto> GetClassrooms()
        {
            return _classroomRepository.GetAll().AsQueryable()
                .Select(x => new ClassroomDto()
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToList();
        }

    }
}
