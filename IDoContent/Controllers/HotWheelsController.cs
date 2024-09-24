using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IDoContent.Data;
using IDoContent.Data.Entity;

namespace IDoContent.Controllers
{

    public class HotWheelsController(APIContext context) : BaseController
    {
         
        private readonly APIContext _context = context;

        // Create/Edit
        [HttpPost]
        public JsonResult CreateEdit(Content content)
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

            return new JsonResult(Ok());  
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
