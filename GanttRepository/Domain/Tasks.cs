using System;
using System.Text;
using System.Collections.Generic;


namespace GanttRepository.Domain{
    
    public class Tasks {
        public virtual int Id { get; set; }
        public virtual string Text { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual int? Duration { get; set; }
        public virtual int? SortOrder { get; set; }
        public virtual Decimal? Progress { get; set; }
        public virtual int? ParentId { get; set; }
        public virtual string Type { get; set; }
    }
}
