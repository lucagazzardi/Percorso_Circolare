using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.Repository
{
    public interface IResourceRepository : IRepository<Resource>
    {
        Resource GetResourceById(int id);
    }

    public class ResourceRepository : Repository<Resource>, IResourceRepository
    {
        private readonly PercorsoCircolareEntities Context;

        public ResourceRepository(PercorsoCircolareEntities context) : base(context)
        {
            Context = context;
        }

        public Resource GetResourceById(int id)
        {
            return Context.Resource
                .SingleOrDefault(c => c.Id == id);
        }
    }
}
