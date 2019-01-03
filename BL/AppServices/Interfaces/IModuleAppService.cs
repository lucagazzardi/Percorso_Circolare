using BL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices.Interfaces
{
    public interface IModuleAppService
    {
        ModuleDto GetModuleById(int id);
        List<ModuleDto> GetModules();
        void Insert(ModuleDto module);
    }
}
