using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.Repository
{
    public interface ICourseRepository : IRepository<Course>
    {
        Course GetCourseById(int id);
    }

    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private readonly PercorsoCircolareEntities Context;

        public CourseRepository(PercorsoCircolareEntities context) : base(context)
        {
            Context = context;
        }  
        
        //Get by ID with foreign keys included
        public Course GetCourseById(int id)
        {
            return Context.Course
                .Include(r => r.Resource)
                .SingleOrDefault(c => c.Id == id);                
        }

    }
}
