using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronicsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ElectronicsdbContext _context;

        public ValuesController(ElectronicsdbContext context)
        {
            _context = context;
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> PostElectronics([FromBody] Electronics value)
        {
            _context.Electronics.Add(value);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetElectronics", new { id = value.Id }, value);
        }

        // GET api/values
        /*
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
           public ActionResult<string> Get(int id)
           {
               return "value";
           }

          

           // PUT api/values/5
           [HttpPut("{id}")]
           public void Put(int id, [FromBody] string value)
           {
           }

           // DELETE api/values/5
           [HttpDelete("{id}")]
           public void Delete(int id)
           {
           }
          */


        //============================================================================
        /*
        private readonly IElectronicsService _bookChaptersService;
        public ValuesController(IElectronicsService bookChaptersService)
        {
            _bookChaptersService = bookChaptersService;
        }

        // GET: api/bookchapters
        [HttpGet()]
        [Route("allchapters")]
        [ProducesResponseType(typeof(IEnumerable<Electronics>), 200)]
        public Task<IEnumerable<Electronics>> GetBookChaptersAsync() => _bookChaptersService.GetAllAsync();

        // GET api/bookchapters/guid
        [HttpGet("{id}", Name = nameof(GetBookChapterByIdAsync))]
        [ProducesResponseType(typeof(Electronics), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetBookChapterByIdAsync(Guid id)
        {
            Electronics chapter = await _bookChaptersService.FindAsync(id);
            if (chapter == null)
            {
                return NotFound();
            }
            else
            {
                return new ObjectResult(chapter);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Electronics), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostBookChapterAsync([FromBody]Electronics chapter)
        {
            if (chapter == null)
            {
                return BadRequest();
            }
            await _bookChaptersService.AddAsync(chapter);
            return CreatedAtRoute(nameof(GetBookChapterByIdAsync),
              new { id = chapter.Id }, chapter);
        }

        // PUT api/bookchapters/guid
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PutBookChapterAsync(Guid id, [FromBody]Electronics chapter)
        {
            if (chapter == null || id != chapter.Id)
            {
                return BadRequest();
            }
            if (await _bookChaptersService.FindAsync(id) == null)
            {
                return NotFound();
            }
            await _bookChaptersService.UpdateAsync(chapter);
            return new NoContentResult();
        }

        // DELETE api/bookchapters/guid
        [HttpDelete("{id}")]
        public async Task DeleteAsync(Guid id) => await _bookChaptersService.RemoveAsync(id);
        */
    }
}
