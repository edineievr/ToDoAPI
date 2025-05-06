using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Models;
using ToDoAPI.Models.Exceptions;

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
            try
            {
                var task = _todolist.GetById(id);
                return Ok(task);

            }
            catch (DomainException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<List<ToDoTask>> CreateTask(ToDoTask task)
        {
            try
            {
                _todolist.AddTask(task);

                return Ok(task);
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public ActionResult<List<ToDoTask>> DeleteAll()
        {
            try
            {
                _todolist.RemoveAll();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<List<ToDoTask>> DeleteById(int id)
        {
            try
            {
                var t = _todolist.GetById(id);
                _todolist.RemoveTask(t);

                return Ok();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }           

        }
    }
}
