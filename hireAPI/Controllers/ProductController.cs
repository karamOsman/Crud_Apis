using hireAPI.Models;
using hireAPI.Models.AppContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hireAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ToDoListContext _context;
        public ProductController(ToDoListContext context)
        {
            _context = context;
        }

        // GET: Product/Create
        [HttpGet]
        public IActionResult Create()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Products product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

        // GET: Product/Edit/5
        [HttpGet("api/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }
            return Ok();

        }

        // POST: Product/Edit/5

        [HttpPut]
        public async Task<IActionResult> Edit_Product(int id, Products products)
        {
            if (id != products.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(products);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(products.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return NotFound();
            }
            return Ok();
        }




        // GET: Product/Delete/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }
            var product = await _context.Products.FirstOrDefaultAsync(e => e.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok();
        }


        // POST: Product/Delete/5
        [HttpDelete, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity Set 'ToDoList.Products' is Null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            await _context.SaveChangesAsync();
            return Ok();
        }


        private bool ProductExists(int id)
        {
            return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpGet("{search}")]
        public async Task<IActionResult> Search(int? id = null,string? name=null)
        {
            var  Products =await _context.Products.ToListAsync();
            if (id == null && name == null)
            {
                return Ok(Products);
            }
            if(id !=null)
            {
                Products=Products.Where(p => p.CategoryId == id).ToList();
            }
            if(name != null)
            {
                Products = Products.Where(p => p.English_Name.Contains(name)).ToList();

            }
            return Ok(Products);
        }




        //// GET: api/<ProductController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<ProductController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<ProductController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ProductController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ProductController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

    }
}











