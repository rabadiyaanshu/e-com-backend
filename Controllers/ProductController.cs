using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebLoginRegisterApi.Data;
using WebLoginRegisterApi.Model;

namespace WebLoginRegisterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public ProductsController(ProductDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct([FromForm] string name,
                                                     [FromForm] string category,
                                                     [FromForm] decimal price,
                                                     [FromForm] string description,
                                                     [FromForm] IFormFile image)
        {
            if (image == null || image.Length == 0)
                return BadRequest("Image is required");

            string uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            var product = new Product
            {
                Name = name,
                Category = category,
                Price = price,
                Description = description,
                ImageUrl = "/uploads/" + uniqueFileName
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return Ok(product);
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }

        //[HttpGet("new-collections")]
        //public IActionResult GetNewCollections()
        //{
        //    List<object> products = new List<object>();

        //    using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefultConnection")))
        //    {
        //        string query = @"
        //                        SELECT TOP 8 Id, Name, Category, Price , ImgUrl 
        //                        FROM Products
        //                        ORDER BY Id DESC";

        //        SqlCommand cdm = new SqlCommand(query, conn);
        //        conn.Open();
        //        SqlDateReadre reader = cmd.ExecuteReader();
        //        While (reader.Read())
        //            {
        //            Product.Add(new
        //            {
        //                Id = Convert.ToInt32(reader["Id"]),
        //                Name = reader["Name"].ToString(),
        //                Category = reader["Category"].ToString(),
        //                Price = Convert.ToInt32(reader["Price"]),
        //                ImgUrl = reader["ImgUrl"].ToString()
        //            });
        //        }
        //    }
        //    return Ok(products);
        //}

        [HttpGet("newcollection")]
        public async Task<IActionResult> GetNewCollection()
        {
            var Products = await _context.Products
                .OrderByDescending(p => p.Id)
                .Take(4)
                .ToListAsync();

            return Ok(Products);
        }
    }

}
