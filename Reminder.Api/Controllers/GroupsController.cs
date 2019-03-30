using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.Dto;
using Microsoft.AspNetCore.Hosting.Internal;
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
        private IMapper _mapper;

        public GroupsController(IGroupService groupService, IMapper mapper)
        {
            _mapper = mapper;
            _groupService = groupService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Group> groups = _groupService.Get();

            if (groups == null)
            {
                return NotFound();
            }

            IEnumerable<GroupDto> groupsToReturn = _mapper.Map<IEnumerable<GroupDto>>(groups);

            return Ok(groupsToReturn);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            Group group = _groupService.GetById(id);

            if (group == null)
            {
                return NotFound();
            }

            GroupDto groupToReturn = _mapper.Map<GroupDto>(group);

            return Ok(groupToReturn);
        }

        [HttpPost]
        public IActionResult Post([FromBody] GroupDto groupDto)
        {
            Group group = _mapper.Map<Group>(groupDto);

            _groupService.Add(group);

            groupDto = _mapper.Map<GroupDto>(group);

            return Ok(groupDto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] GroupDto groupDto)
        {
            Group group = _mapper.Map<Group>(groupDto);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _groupService.Update(id, group);

            groupDto = _mapper.Map<GroupDto>(group);

            return Ok(groupDto);
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