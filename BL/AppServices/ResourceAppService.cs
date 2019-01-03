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
    public class ResourceAppService : IResourceAppService
    {
        private readonly IResourceRepository _resourceRepository;

        public ResourceAppService()
        {
            _resourceRepository = new UnitOfWork().ResourceRepository;
        }

        public ResourceDto GetResourceById(int resourceId)
        {
            Resource resource = _resourceRepository.GetResourceById(resourceId);

            return new ResourceDto()
            {
                Id = resource.Id,
                Username = resource.Username,
                FirstName = resource.FirstName,
                LastName = resource.LastName,
                StatusId = resource.StatusId
            };
        }

        public List<ResourceDto> GetResources()
        {
            return _resourceRepository.GetAll().AsQueryable()
                .Select(x => new ResourceDto()
                {
                    Id = x.Id,
                    Username = x.Username,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    StatusId = x.StatusId
                })
                .ToList();
        }

        public void Insert(ResourceDto resource)
        {
            Resource newItem = new Resource()
            {
                Id = resource.Id,
                Username = resource.Username,
                FirstName = resource.FirstName,
                LastName = resource.LastName,
                StatusId = resource.StatusId
            };

            _resourceRepository.Insert(newItem);
        }
    }
}
