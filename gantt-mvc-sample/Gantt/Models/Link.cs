using System.ComponentModel.DataAnnotations;

namespace Gantt.Models
{
    public class Link
    {
        public int Id { get; set; }
        [MaxLength(1)]
        public string Type { get; set; }
        public int SourceTaskId { get; set; }
        public int TargetTaskId { get; set; }
    }
}