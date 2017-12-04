using System;
namespace TodoApp.Models
{
    public class Todo
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public bool IsImportant { get; set; }
        public bool IsDone { get; set; }
        public bool IsArchive { get; set; }
        public int DaysRemaining { get; set; }
        public DateTime DueDate { get; set; }

        public void UpdateDaysRemaining()
        {
            DaysRemaining = DueDate.Subtract(DateTime.Today).Days;
        }
    }
}
