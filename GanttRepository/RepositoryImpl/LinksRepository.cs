using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GanttRepository.Repository;
using GanttRepository.Domain;

namespace GanttRepository.RepositoryImpl
{
    public class LinksRepository : NhRepository, ILinksRepository
    {
        public void Insert(Links entity)
        {
            Insert<Links>(entity);
        }

        public void Update(Links entity)
        {
            Update<Links>(entity);
        }

        public void SaveOrUpdate(Links entity)
        {
            SaveOrUpdate<Links>(entity);
        }

        public Links GetByID(int ids)
        {
            using (var session = SessionFactory.OpenStatelessSession())
            {
                var result = session.Get<Links>(ids);
                return result;
            }
        }

        public void Delete(Links entity)
        {
            try
            {
                Delete<Links>(entity);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }

        }

        public List<Links> getAll()
        {
            using (var session = SessionFactory.OpenStatelessSession())
            {
                var result = session.QueryOver<Links>();

                return result.List() as List<Links>;
            }
        }
    }
}
