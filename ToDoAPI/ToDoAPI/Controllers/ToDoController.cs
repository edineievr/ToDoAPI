using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Models;

namespace ToDoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]   
    
    public class ToDoController : ControllerBase
    {
        private readonly ToDoList _todolist = new ToDoList();

        [HttpGet]
        public ActionResult<List<ToDoTask>> GetAll()
        {
            var task = _todolist.GetAllTasks();
            return Ok(task);

        }

        [HttpGet("{id}")]
        public ActionResult<List<ToDoTask>> GetById(int id)
        {
            var task = _todolist.GetById(id);
            return Ok(task);
        }
    }
}
