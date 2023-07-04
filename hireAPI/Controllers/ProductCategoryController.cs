using hireAPI.Models;
using hireAPI.Models.AppContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hireAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly ToDoListContext _context;
        public ProductCategoryController(ToDoListContext context)
        {
            _context = context;
        }
        // GET: api/<ProductCategoryController>

        // GET: ProductCategories/Details/5
        [HttpGet("api/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductsCategories == null)
            {
                return NotFound();
            }

            var productCategory = await _context.ProductsCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productCategory == null)
            {
                return NotFound();
            }

            return Ok(productCategory);
        }



        // POST: ProductCategories/Create

        [HttpPost]
        public async Task<IActionResult> Create(ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productCategory);
                await _context.SaveChangesAsync();
            }
            return Ok(productCategory);
        }



        // GET: ProductCategories/Edit/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductsCategories == null)
            {
                return NotFound();
            }

            var productCategory = await _context.ProductsCategories.FindAsync(id);
            if (productCategory == null)
            {
                return NotFound();
            }
            return Ok(productCategory);
        }

        // POST: ProductCategories/Edit/5

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(int id, ProductCategory productCategory)
        {
            if (id != productCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductCategoryExists(productCategory.Id))
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
            return Ok(productCategory);
        }



        // GET: ProductCategories/Delete/5
        [HttpGet("api/api/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductsCategories == null)
            {
                return NotFound();
            }

            var productCategory = await _context.ProductsCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productCategory == null)
            {
                return NotFound();
            }

            return Ok(productCategory);
        }

        // POST: ProductCategories/Delete/5
        [HttpDelete, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductsCategories == null)
            {
                return Problem("Entity set 'ToDoListContext.ProductsCategories'  is null.");
            }
            var productCategory = await _context.ProductsCategories.FindAsync(id);
            if (productCategory != null)
            {
                _context.ProductsCategories.Remove(productCategory);
            }

            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool ProductCategoryExists(int id)
        {
            return (_context.ProductsCategories?.Any(e => e.Id == id)).GetValueOrDefault();






            //[HttpGet]
            //public IEnumerable<string> Get()
            //{
            //    return new string[] { "value1", "value2" };
            //}

            //// GET api/<ProductCategoryController>/5
            //[HttpGet("{id}")]
            //public string Get(int id)
            //{
            //    return "value";
            //}

            //// POST api/<ProductCategoryController>
            //[HttpPost]
            //public void Post([FromBody] string value)
            //{
            //}

            //// PUT api/<ProductCategoryController>/5
            //[HttpPut("{id}")]
            //public void Put(int id, [FromBody] string value)
            //{
            //}

            //// DELETE api/<ProductCategoryController>/5
            //[HttpDelete("{id}")]
            //public void Delete(int id)
            //{
            //}
        }
    }
}

