using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Reminder.BusinessLogicLayer.Services;
using Reminder.DataAccessLayer.DataModels;

namespace Reminder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _toDoService;

        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_toDoService.Get());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {


            ToDo toDo = _toDoService.GetById(id);

            if (toDo == null)
            {
                return NotFound();
            }

            return Ok(toDo);

        }

        
        [HttpGet("Group/{groupid}")]
        public IActionResult GetByGroup(long groupId)
        {
            IEnumerable<ToDo> toDosByGroup = _toDoService.GetByGroup(groupId);

            if (toDosByGroup == null)
            {
                return NotFound();
            }

            return Ok(toDosByGroup);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] ToDo toDo)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _toDoService.Add(toDo);
            return Ok(toDo);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] ToDo value)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _toDoService.Update(id, value);
            return Ok();
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            ToDo toDelete =_toDoService.GetById(id);
            _toDoService.Delete(toDelete);
            
            return Ok();
        }
    }
}
