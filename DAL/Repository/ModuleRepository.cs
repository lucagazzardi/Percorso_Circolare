using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.Repository
{
    public interface IModuleRepository : IRepository<Module>
    {
        Module GetModuleById(int id);
    }

    public class ModuleRepository : Repository<Module>, IModuleRepository
    {
        private readonly PercorsoCircolareEntities Context;

        public ModuleRepository(PercorsoCircolareEntities context) : base(context)
        {
            Context = context;
        }

        //Get by ID with foreign keys included
        public Module GetModuleById(int id)
        {
            return Context.Module
                .Include(r => r.Course)
                .SingleOrDefault(c => c.Id == id);
        }
    }
}
