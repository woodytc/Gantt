using System;
using System.Text;
using System.Collections.Generic;
//using NHibernate.Validator.Constraints;


namespace GanttRepository.Domain{
    
    public class Links {
        public virtual int Id { get; set; }
        public virtual int? SourceTaskId { get; set; }
        public virtual int? TargetTaskId { get; set; }
        public virtual string Type { get; set; }
    }
}
