using System.ComponentModel.DataAnnotations.Schema;

namespace EasySale.Data.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime Created_Time { get; set; } = DateTime.Now;
        public int Department_Id { get; set; }
    }
}
