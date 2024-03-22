using AC.Domain.Enitites;
using CA.Application.Services;
using CA.Domain.Enitites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Security.Policy;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CAWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        //Filtro por nombre del producto
        [HttpGet]   
        public async Task<IActionResult> GetAll(string? filter = null) 
        {
            var products = await _productService.GetAllAsync(filter);
            return Ok(products);
        }


        //Devuelve los detalles de un producto específico por su ID.
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetByIdAsync(int id)
        {
            var products = await _productService.GetByIdAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }


        //Recibe los detalles del producto a crear en el cuerpo del request.
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            var createdBlog = await _productService.CreateAsync(product);

            return CreatedAtAction("GetByIdAsync", new { id = createdBlog.Id }, createdBlog);
          
        }

        //Recibe los detalles actualizados del producto en el cuerpo del request y el ID del producto en la URL.
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Product product)
        {
            int okProduct = await _productService.UpdateAsync(id, product);
            if (okProduct == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }

        //Recibe el ID del producto a eliminar en la URL.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int product = await _productService.DeleteAsync(id); 
            if(product == 0)
            {
                return NotFound();
            }
            return NoContent();
        }

       
    }
}
