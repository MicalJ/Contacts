using System;
using System.Collections.Generic;
using Contacts.Filters;
using Contacts.Infrastructure;
using Contacts.Interfaces;
using Contacts.Models;
using ContactsContext.DbModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Contacts.Controllers
{
    [Produces("application/json")]
    [Route("api/Contact")]
    public class ContactController : Controller
    {
        private readonly IPersonService _personService;
        private readonly ISortService _sortService;
        private readonly IMemoryCache _cache;

        public ContactController(IPersonService personService, ISortService sortService, IMemoryCache memoryCache)
        {
            _personService = personService;
            _sortService = sortService;
            _cache = memoryCache;
        }

        [HttpGet(template: "[action]")]
        public IActionResult GetAll()
        {
            List<PersonResponse> persons;

            if (_cache.TryGetValue(Consts.contactsCacheKey,out List<PersonResponse> contacts))
            {
                persons = _cache.Get(Consts.contactsCacheKey) as List<PersonResponse>;
            }
            else
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(60));
                persons = AutoMapper.Mapper.Map<List<PersonResponse>>(_personService.GetAllContacts());
                _cache.Set(Consts.contactsCacheKey, persons, cacheEntryOptions);
            }

            return new JsonResult(persons);
        }

        [HttpGet(template: "[action]/{contactId}")]
        public IActionResult GetById(int contactId)
        {
            var contact = AutoMapper.Mapper.Map<PersonResponse>(_personService.GetByIdContact(contactId));
            if (contact == null)
            {
                return NotFound();
            }

            return new JsonResult(contact);
        }

        [HttpPost(template: "[action]")]
        [ModelValidation]
        public IActionResult PostContact([FromBody]PersonRequest personRequest)
        {
            if (personRequest == null)
            {
                return BadRequest();
            }
            
            return new JsonResult(_personService.AddContact(AutoMapper.Mapper.Map<Person>(personRequest)));
        }

        [HttpPut(template: "[action]/{contactId}")]
        [ModelValidation]
        public IActionResult PutContact(int contactId, [FromBody]PersonRequest personRequest)
        {
            var contactToUpdate = AutoMapper.Mapper.Map<Person>(personRequest);
            contactToUpdate.PersonId = contactId;

            if (personRequest == null || !(_personService.UpdateContact(contactToUpdate)))
            {
                return BadRequest();
            }

            return new JsonResult(contactId);
        }

        [HttpDelete(template: "[action]/{contactId}")]
        public IActionResult DeleteContact(int? contactId)
        {
            if (contactId == null)
            {
                return BadRequest();
            }

            _personService.RemoveContact(contactId);

            return new JsonResult(contactId);
        }

        [HttpPatch(template: "[action]/{search}")]
        public IActionResult Search(string search = null)
        {
            return new JsonResult(AutoMapper.Mapper.Map<List<PersonResponse>>(_personService.Searching(search)));
        }

        [HttpGet(template: "[action]/{choice}")]
        public IActionResult FilterCategory(int? choice)
        {
            return new JsonResult(AutoMapper.Mapper.Map<List<PersonResponse>>(_personService.FilterCategory(choice)));
        }

        [HttpGet(template: "[action]/{choice}")]
        public IActionResult Sort(string choice)
        {
            return new JsonResult(AutoMapper.Mapper.Map<List<PersonResponse>>(_sortService.SortAfterFirstNameOrLastName(choice)));
        }
    }
}