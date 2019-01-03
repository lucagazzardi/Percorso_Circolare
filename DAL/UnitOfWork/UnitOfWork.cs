using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUnitOfWork
    {
        void Save();  
        
    }

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private PercorsoCircolareEntities Context = new PercorsoCircolareEntities();
        private ICourseRepository courseRepository;
        private ILessonRepository lessonRepository;
        private IModuleRepository moduleRepository;
        private IResourceRepository resourceRepository;
        private IClassroomRepository classroomRepository;

        private bool disposed = false;

        public UnitOfWork()
        {
            Context.Configuration.LazyLoadingEnabled = false;
        }

        #region Getters

        public ICourseRepository CourseRepository
        {
            get
            {
                if(courseRepository == null)
                {
                    this.courseRepository = new CourseRepository(Context);
                }
                return this.courseRepository;
            }
        }

        public ILessonRepository LessonRepository
        {
            get
            {
                if (courseRepository == null)
                {
                    this.lessonRepository = new LessonRepository(Context);
                }
                return this.lessonRepository;
            }
        }

        public IModuleRepository ModuleRepository
        {
            get
            {
                if (courseRepository == null)
                {
                    this.moduleRepository = new ModuleRepository(Context);
                }
                return this.moduleRepository;
            }
        }

        public IResourceRepository ResourceRepository
        {
            get
            {
                if (courseRepository == null)
                {
                    this.resourceRepository = new ResourceRepository(Context);
                }
                return this.resourceRepository;
            }
        }

        public IClassroomRepository ClassroomRepository
        {
            get
            {
                if (classroomRepository == null)
                {
                    this.classroomRepository = new ClassroomRepository(Context);
                }
                return this.classroomRepository;
            }
        }

        #endregion Getters

        public void Save()
        {
            Context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
