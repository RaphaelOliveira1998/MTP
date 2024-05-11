using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private static List<string> tasks = new List<string>();

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetTasks()
        {
            return tasks;
        }

        [HttpPost]
        public ActionResult AddTask([FromBody] string task)
        {
            tasks.Add(task);
            return Ok();
        }

        [HttpDelete("{index}")]
        public ActionResult DeleteTask(int index)
        {
            if (index >= 0 && index < tasks.Count)
            {
                tasks.RemoveAt(index);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
