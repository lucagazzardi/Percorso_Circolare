using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IClassroomRepository : IRepository<Classroom>
    {

    }

    public class ClassroomRepository : Repository<Classroom>, IClassroomRepository
    {

        private readonly PercorsoCircolareEntities Context;

        public ClassroomRepository(PercorsoCircolareEntities context) : base(context)
        {
            Context = context;
        }

    }
}
