using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reminder.BusinessLogicLayer.Services;
using Reminder.DataAccessLayer.DataModels;

namespace Reminder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDosController : ControllerBase
    {
        private readonly IToDoService _toDoService;
        private IMapper _mapper;

        public ToDosController(IToDoService toDoService, IMapper mapper)
        {
            _mapper = mapper;
            _toDoService = toDoService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            IEnumerable <ToDo> toDos = _toDoService.Get();

            IEnumerable<ToDoDto> toDosToReturn = _mapper.Map<IEnumerable<ToDoDto>>(toDos);

            return Ok(toDosToReturn);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {


            ToDo toDo = _toDoService.GetById(id);

            if (toDo == null)
            {
                return NotFound();
            }

            ToDoDto toDoDto = _mapper.Map<ToDoDto>(toDo);

            return Ok(toDoDto);

        }

        
        [HttpGet("group/{groupId}")]
        public IActionResult GetByGroup(long groupId)
        {
            IEnumerable<ToDo> toDos = _toDoService.GetByGroup(groupId);

            if (toDos == null)
            {
                return NotFound();
            }

            IEnumerable<ToDoDto> toDosToReturn = _mapper.Map<IEnumerable<ToDoDto>>(toDos);

            return Ok(toDosToReturn);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] ToDoDto toDo)
        {
            ToDo toAdd = _mapper.Map<ToDo>(toDo);

            _toDoService.Add(toAdd);

            toDo = _mapper.Map<ToDoDto>(toAdd);

            return Ok(toDo.ToDoId);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] ToDoDto value)
        {

            ToDo toUpdate = _mapper.Map<ToDo>(value);

            _toDoService.Update(id, toUpdate);

            value = _mapper.Map<ToDoDto>(toUpdate);

            return Ok(value);
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
