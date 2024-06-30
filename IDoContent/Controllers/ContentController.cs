using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IDoContent.Models;
using IDoContent.Data;

namespace IDoContent.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContentController : ControllerBase
    {

        private readonly APIContext _context;

        public ContentController(APIContext context)
        {
            _context = context;
        }

        // Create/Edit
        [HttpPost]
        public JsonResult CreateEdit(ContentModel content)
        {
            if(content.Id == 0) 
            {
                _context.Contents.Add(content);
            }
            else 
            {
                var contentInDB = _context.Contents.Find(content.Id);
                if(contentInDB == null)
                    return new JsonResult(NotFound());

                    contentInDB = content;
                
            }

            _context.SaveChanges();
            return new JsonResult(Ok(content));
        }

        [HttpGet]
        public JsonResult Get(int id) 
        {
        var result = _context.Contents.Find(id);
            if(result==null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        [HttpDelete]

        public JsonResult Delete(int id)
        {
            var result = _context.Contents.Find(id);
            if (result == null)
                return new JsonResult(NotFound());

            _context.Contents.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());  
        }

        //Get All

        [HttpGet()]
        public JsonResult GetAll() {

            var result = _context.Contents.ToList();
            return new JsonResult(Ok(result));
        }
        [HttpGet()]
        public JsonResult GetFiltered()
        {

            var result = _context.Contents.ToList().Where(f=>f.ContentCategory== "Yazılım");
            return new JsonResult(Ok(result));
        }
    }
}
