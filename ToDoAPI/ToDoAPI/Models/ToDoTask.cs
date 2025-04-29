using ToDoAPI.Models.Exceptions;

namespace ToDoAPI.Models
{
    public class ToDoTask
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        public DateTime CreationDate  { get; set; }
        public DateTime EndDate { get; set; }

        public bool IsCompleted { get; set; }

        public ToDoTask()
        {
            
        }

        public ToDoTask(int id,string title, string description, DateTime creationDate)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException("title cannot be empty");
            }

            if (creationDate > DateTime.Now)
            {
                throw new DomainException("End date cannot be in the future!");
            }
                        
            Id = id;
            Title = title;
            Description = description;
            CreationDate = creationDate;
            IsCompleted = false;            
        }

        public void Update(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public void SetAsCompleted(DateTime endDate)
        {
            EndDate = endDate;
            IsCompleted = true;
        }



    }
}
