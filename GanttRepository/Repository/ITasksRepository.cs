using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GanttRepository.Domain;

namespace GanttRepository.Repository
{
    public interface ITasksRepository
    {
         void Insert(Tasks entity);
         void Update(Tasks entity);
         void SaveOrUpdate(Tasks entity);
        // List<Tasks> GetByID(int ids);
         void Delete(Tasks entity);

         List<Tasks> GetAll();
    }
}
