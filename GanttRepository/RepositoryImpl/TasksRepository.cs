using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GanttRepository.Repository;
using GanttRepository.Domain;

namespace GanttRepository.RepositoryImpl
{
    public class TasksRepository : NhRepository, ITasksRepository
    {
        public void Insert(Tasks entity)
        {
            Insert<Tasks>(entity);
        }

        public void Update(Tasks entity)
        {
            Update<Tasks>(entity);
        }

        public void SaveOrUpdate(Tasks entity)
        {
            SaveOrUpdate<Tasks>(entity);
        }

        //public List<Tasks> GetByID()
        //{
        //    using (var session = SessionFactory.OpenStatelessSession())
        //    {
        //        var result = session.QueryOver<Tasks>().List() as List<Tasks>;
        //        return result;
        //    }
        //}

        public void Delete(Tasks entity)
        {
            try
            {
                Delete<Tasks>(entity);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }

        }

        public List<Tasks> GetAll()
        {
            using (var session = SessionFactory.OpenStatelessSession())
            {
                var result = session.QueryOver<Tasks>();

                return result.List<Tasks>() as List<Tasks>;
            }
        }
    }
}
