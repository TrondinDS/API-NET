using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NET.Domain;
using NET.Model;
using NET.Repository;

namespace NET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ICabinetRepository _cabinetRepository;

        public UserController(IUserRepository userRepository, ICabinetRepository cabinetRepository)
        {
            _userRepository = userRepository;
            _cabinetRepository = cabinetRepository;
        }

        [HttpPost]
        [Route("add_user")]
        public ActionResult AddUser(User value)
        {
            if (value == null)
                return Ok(null);
            else
            {
                return Ok(_userRepository.AddUser(value));
            }
        }

        [HttpPost]
        [Route("del_user")]
        public ActionResult DeletUser(idJSON id)
        {
            if (id == null || id.id <= 0)
                return Ok(null);
            else
            {
                _userRepository.DeleteUser(id.id);
                return Ok(true);
            }
        }

        [HttpPost]
        [Route("update_user")]
        public ActionResult UppUser(User value)
        {
            if (value == null)
                return Ok(null);
            else
            {
                _userRepository.UpdateUser(value);
                return Ok(true);
            }
        }

        [HttpPost]
        [Route("get_users")]
        public ActionResult GetUsers()
        {
            return Ok(_userRepository.GetAllUsers());
        }

        [HttpPost]
        [Route("select_user")]
        public ActionResult SelUser(idJSON value)
        {
            if (value == null)
                return Ok(null);
            else
            {
                return Ok(_userRepository.SelectUserWhereId(value.id));
            }
        }





        [HttpPost]
        [Route("add_cabinet")]
        public ActionResult AddCabinet(Cabinet value)
        {
            if (value == null)
                return Ok(null);
            else
            {
                return Ok(_cabinetRepository.AddCabinet(value));
            }
        }

        [HttpPost]
        [Route("del_cabinet")]
        public ActionResult DeletCabinet(idJSON id)
        {
            if (id == null || id.id <= 0)
                return Ok(null);
            else
            {
                _cabinetRepository.DeleteCabinet(id.id);
                return Ok(true);
            }
        }

        [HttpPost]
        [Route("update_cabinet")]
        public ActionResult UppCabinet(Cabinet value)
        {
            if (value == null)
                return Ok(null);
            else
            {
                _cabinetRepository.UpdateCabinet(value);
                return Ok(true);
            }
        }

        [HttpPost]
        [Route("get_cabinet")]
        public ActionResult GetCabinet()
        {
            return Ok(_cabinetRepository.GetAllCabinets());
        }

        [HttpPost]
        [Route("select_cabinet")]
        public ActionResult SelCabinet(idJSON value)
        {
            if (value == null)
                return Ok(null);
            else
            {
                return Ok(_cabinetRepository.SelectCabinetWhereId(value.id));
            }
        }
    }
}

