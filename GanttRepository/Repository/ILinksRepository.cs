using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GanttRepository.Domain;

namespace GanttRepository.Repository
{
    public interface ILinksRepository
    {
         void Insert(Links entity);
         void Update(Links entity);
         void SaveOrUpdate(Links entity);
        // List<Links> GetByID(int ids);
         void Delete(Links entity);

         List<Links> getAll();
    }
}
