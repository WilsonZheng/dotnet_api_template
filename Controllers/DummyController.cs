using Microsoft.AspNetCore.Mvc;

namespace MyApiProject.Controllers
{
    [ApiController]
    [Route("v1/dummy")]
    public class DummyController : ControllerBase
    {

        [HttpGet]
        public Dummy Get()
        {
            return new Dummy { text = "HelloWorld" };
        }
    }
}
