using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using GanttRepository.Domain;

namespace GanttRepository.Mapping{
    
    
    public class TasksMap : ClassMap<Tasks> {
        
        public TasksMap() {
			Table("Tasks");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity().Column("Id");
			Map(x => x.Text).Column("Text");
			Map(x => x.StartDate).Column("StartDate");
			Map(x => x.Duration).Column("Duration");
            Map(x => x.SortOrder).Column("SortOrder");
			Map(x => x.Progress).Column("Progress");
            Map(x => x.ParentId).Column("ParentId");
			Map(x => x.Type).Column("Type");
        }
    }
}
