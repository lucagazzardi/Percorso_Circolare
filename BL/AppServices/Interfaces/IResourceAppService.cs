using BL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices.Interfaces
{
    public interface IResourceAppService
    {
        ResourceDto GetResourceById(int resourceId);
        List<ResourceDto> GetResources();
        void Insert(ResourceDto resource);

    }
}
