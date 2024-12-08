using BlogApp.Data;
using BlogApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{  // localhost:xxxx/api/blog
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly ApplicationDbcontext dbcontext;

        public BlogController(ApplicationDbcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        [HttpGet]
        public IActionResult GetallBlogs()
        {
            var allBlogs = dbcontext.Blogs.ToList();
            return Ok(allBlogs);

        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult GetBlogById(int id)
        {
                            
      var Blog  =  dbcontext.Blogs.Find(id);            // blog is variable

            if (Blog is null) {

                return NotFound();
               
            }
            return Ok(Blog);
        
        }



        [HttpPost]
                                         // we created dto (data transfer object) from one operation to other
        public IActionResult AddBlog(AddBlogDto addBlogDto)
        {
            var BlogEntity = new Blog()
            {
                Title = addBlogDto.Title,
                Content = addBlogDto.Content,
                Author = addBlogDto.Author,
                Image = addBlogDto.Image,
                BlogDate = addBlogDto.BlogDate

            };

            dbcontext.Blogs.Add(BlogEntity);
            dbcontext.SaveChanges();
            return Ok(BlogEntity);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateBlog(int id, UpdateBlogDto updateBlogDto)
        {
            var Blog = dbcontext.Blogs.Find(id);

            if (Blog is null)
            {

                return NotFound();
            }
            Blog.Title = updateBlogDto.Title;
            Blog.Content = updateBlogDto.Content;
            Blog.Author = updateBlogDto.Author;
            Blog.Image = updateBlogDto.Image;
            Blog.BlogDate = updateBlogDto.BlogDate;
            dbcontext.SaveChanges();

            return Ok(Blog);

        }


        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            var Blog = dbcontext.Blogs.Find(id);
            if(Blog is null)
            {
                return NotFound();
            }
            dbcontext.Blogs.Remove(Blog);
            dbcontext.SaveChanges();
            return Ok(Blog);
        
        
        
        
        }



    }
}
