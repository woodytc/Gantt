using System; 
using System.Collections.Generic; 
using System.Text; 
using KTBLeasing.Domain;


namespace KTBLeasing.Domain {
    
    
    [DataContract(Name="TasksData" , Namespace="")]
    public class TasksData {
        
        [DataMember()]
        public virtual Int32 Id {
            get;
            set;
        }
        
        [DataMember()]
        public virtual String Text {
            get;
            set;
        }
        
        [DataMember()]
        public virtual DateTime Startdate {
            get;
            set;
        }
        
        [DataMember()]
        public virtual Int32 Duration {
            get;
            set;
        }
        
        [DataMember()]
        public virtual Int32 Order {
            get;
            set;
        }
        
        [DataMember()]
        public virtual Single Progress {
            get;
            set;
        }
        
        [DataMember()]
        public virtual Int32 Parent {
            get;
            set;
        }
        
        [DataMember()]
        public virtual String Type {
            get;
            set;
        }
    }
}
