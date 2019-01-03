using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.Repository
{
    public interface ILessonRepository : IRepository<Lesson>
    {
        Lesson GetLessonById(int id);
    }

    public class LessonRepository : Repository<Lesson>, ILessonRepository
    {
        private readonly PercorsoCircolareEntities Context;

        public LessonRepository(PercorsoCircolareEntities context) : base(context)
        {
            Context = context;
        }

        //Get by ID with foreign keys included
        public Lesson GetLessonById(int id)
        {
            return Context.Lesson
                .Include(r => r.Module)
                .Include(r => r.Course)
                .Include(r => r.Teacher)
                .Include(r => r.Backup)
                .Include(r => r.Classroom)
                .SingleOrDefault(c => c.Id == id);
        }

    }
}
