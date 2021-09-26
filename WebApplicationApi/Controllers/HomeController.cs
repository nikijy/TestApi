using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplicationApi.Model;

namespace WebApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("charppolicy")]
    public class UserController : ControllerBase
    {
        // GET api/values  
        [HttpGet("{s}/{st}/{id}")]
        public ActionResult<IEnumerable<string>> Get(string s, string st = "", int id = 0)
        {
            return Ok(JsonConvert.SerializeObject(GetAllUser(s, st, id), Formatting.Indented));
        }

        public List<User> GetAllUser(string s, string st = "", int id = 0)
        {
            List<User> Author = new List<User>();
            
            Author.Add(new User
            {
                Id = 1,
                role = "Admin",
                biodata = "C# Corner, Mindcracker",
                intro = "Startup Advisor, Speaker, Author, Architecture, Innovation",
                joineddate = "Oct 29 2004",
                location = "Philadelphia USA",
                name = "Mahesh Chand",
                profilelink = "https://www.c-sharpcorner.com/members/mahesh-chand",
                profilepicture = "https://csharpcorner-mindcrackerinc.netdna-ssl.com/UploadFile/AuthorImage/mahesh20160308020632.png"
            });
            Author.Add(new User
            {
                Id = 2,
                role = "Admin",
                biodata = "C# Corner Chief Editor and 3-times Microsoft MVP. I hold Masters degree in Computer Science and Applications and Bachelor’s degree in Mathematics. I am responsible for content publishing, product development, and migration of existing contents. I am also responsible for hiring new team members and managing the existing team",
                intro = "Not Available",
                joineddate = "May 16 2005",
                location = "Noida India",
                name = "Praveen Moosad",
                profilelink = "https://www.c-sharpcorner.com/members/praveen-moosad",
                profilepicture = "https://csharpcorner-mindcrackerinc.netdna-ssl.com/UploadFile/AuthorImage/prvn_13197120160516052234.jpg"
            });
            Author.Add(new User
            {
                Id = 3,
                role = "Editor",
                biodata = "Not Available",
                intro = "Editing and writing",
                joineddate = "Dec 30 2015",
                location = "USA",
                name = "TRIX MIDDLEKAUFF",
                profilelink = "https://www.c-sharpcorner.com/members/trix-middlekauff",
                profilepicture = "https://csharpcorner-mindcrackerinc.netdna-ssl.com/UploadFile/AuthorImage/26e38620180810040748.jpg"
            });

            if (s == null && id == 0)
                return Author;

            if (!string.IsNullOrEmpty(s))
                Author = Author.Where(a => a.name.ToLower().Contains(s.ToLower())).ToList();

            if (!string.IsNullOrEmpty(st))
                Author = Author.Where(a => a.role.Contains(st)).ToList();

            if (id != 0)
                Author = Author.Where(a => a.Id == id).ToList();

            return Author;

        }
    }
}