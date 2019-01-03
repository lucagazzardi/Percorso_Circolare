using BL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices.Interfaces
{
    public interface IClassroomAppService
    {
        Classroom GetClassroomById(int id);
        List<ClassroomDto> GetClassrooms();
    }
}
