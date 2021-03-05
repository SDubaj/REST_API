using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTAPI.Models;


namespace RESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private readonly WordDBContext _context;

        public WordsController(WordDBContext context)
        {
            _context = context;
        }


        // GET: api/Words
        // Get all words 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Word>>> GetWords()
        {
            return await _context.Words.ToListAsync();
        }

        // GET: api/Words/5
        // Get word by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Word>> GetWord(int id)
        {
            var word = await _context.Words.FindAsync(id);

            if (word == null)
            {
                return NotFound();
            }

            return word;
        }

        

        // api/Words/TypeAnyWord
        // Get number of same words
        [HttpGet("name/{name}")]
        public async Task<int> GetNumberOfWords(string name)
        {
            var items = await _context.Words.Where(p => p.Name == name).ToListAsync();
            var itemsLength = items.Count();
            return itemsLength;
        }


        // api/Words/unique
        // Get distinct words
        [HttpGet("unique")]
        public async Task<IEnumerable<string>> GetDistinctWords()
        {
            
            var list = await _context.Words.Select(c => c.Name).ToListAsync();
            var distinctList = list.Distinct();

            return distinctList;
        }
        // PUT: api/Words/5
        // Update Word with ID = ...
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWord(int id, Word word)
        {
            if (id != word.Id)
            {
                return BadRequest();
            }

            _context.Entry(word).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WordExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Words
        // Add new word
        [HttpPost]
        public async Task<ActionResult<Word>> PostWord(Word word)
        {
            _context.Words.Add(word);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWord", new { id = word.Id }, word);
        }

        // DELETE: api/Words/5
        //Delete word with ID= ...
        [HttpDelete("{id}")]
        public async Task<ActionResult<Word>> DeleteWord(int id)
        {
            var word = await _context.Words.FindAsync(id);
            if (word == null)
            {
                return NotFound();
            }

            _context.Words.Remove(word);
            await _context.SaveChangesAsync();

            return word;
        }

        private bool WordExists(int id)
        {
            return _context.Words.Any(e => e.Id == id);
        }
    }
}
