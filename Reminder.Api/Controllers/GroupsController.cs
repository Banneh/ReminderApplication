using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reminder.BusinessLogicLayer.Services;
using Reminder.DataAccessLayer.DataModels;

namespace Reminder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {

        private readonly IGroupService _groupService;

        public GroupsController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Group> groupsToReturn = _groupService.Get();

            if (groupsToReturn == null)
            {
                return NotFound();
            }

            return Ok(groupsToReturn);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            Group groupToReturn = _groupService.GetById(id);

            if (groupToReturn == null)
            {
                return NotFound();
            }

            return Ok(groupToReturn);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Group group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _groupService.Add(group);

            return Ok(group);
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Group group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _groupService.Update(id, group);

            return Ok(group);
        }

        [HttpDelete]
        public IActionResult Delete(long id)
        {
            Group groupToDelete =_groupService.GetById(id);

            if (groupToDelete == null)
            {
                return NotFound();
            }

            _groupService.Delete(groupToDelete);

            return Ok();
        }

    }
}