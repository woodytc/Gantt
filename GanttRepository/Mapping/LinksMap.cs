using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using GanttRepository.Domain;

namespace GanttRepository.Mapping{
    
    
    public class LinksMap : ClassMap<Links> {
        
        public LinksMap() {
			Table("Links");
			LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("Id");
            Map(x => x.SourceTaskId).Column("SourceTaskId");
            Map(x => x.TargetTaskId).Column("TargetTaskId");
			Map(x => x.Type).Column("Type");
        }
    }
}
