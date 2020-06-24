using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PhoneBookApi.Models;
using PhoneBookApi.Services;

namespace PhoneBookApi.Controllers
{
    [Route("api/phonebook")]
    [ApiController]
    public class PhoneBookController : ControllerBase
    {
        private readonly PhoneBookService _phoneBookService;

        public PhoneBookController(PhoneBookService phoneBookService)
        {
            _phoneBookService = phoneBookService;
        }

        /// <summary>
        /// General Get request returning all phone book entries
        /// </summary>
        /// <returns>A list of all phone book entries</returns>
        [HttpGet]
        public ActionResult<List<PhoneBook>> Get() => _phoneBookService.Get();

        /// <summary>
        /// General Get request returning the phone book identified by the name parameter
        /// </summary>
        /// <param name="name">Phone book to retrieve</param>
        /// <returns>A specific phone book entry based on the name</returns>
        [HttpGet("{name}", Name = "GetPhoneBook")]
        public ActionResult<PhoneBook> Get(string name)
        {
            var book = _phoneBookService.Get(name);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        /// <summary>
        /// Add name and number to a specific phone book
        /// </summary>
        /// <param name="entry">Phone Book name and number entry/param>
        /// <returns>Object representing the added entry/returns>
        [HttpPut]
        public ActionResult<PhoneBookEntry> addEntry(AddEntry entry)
        {

            _phoneBookService.addEntry(entry);

            return Ok(entry);
        }

        /// <summary>
        /// Create a phone book entry
        /// </summary>
        /// <param name="book">Phone Book to create/param>
        /// <returns>Phone book created</returns>
        [HttpPost]
        public ActionResult<PhoneBook> Create(PhoneBook book)
        {
            _phoneBookService.Create(book);

            return CreatedAtRoute("GetPhoneBook", new { id = book.Id.ToString() }, book);
        }
    }
}
