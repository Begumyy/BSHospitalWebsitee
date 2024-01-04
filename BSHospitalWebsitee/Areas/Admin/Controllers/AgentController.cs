using BSHospital.Models;
using BSHospital.Repository.Shared.Abstract;
using BSHospital.Repository.Shared.Concrete;
using CineScore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BSHospital.Websitee.Areas.Admin.Controllers
{
    public class AgentController : ControllerBase1
    {
        private readonly IUnitOfWork _unitOfWork;
        public AgentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AppUser user)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Email", "E-posta adresi doğru formatta değil");
                // Eğer modelin doğruluğu sağlanmıyorsa, hataları inceleyebilir veya uygun bir şekilde işleyebilirsiniz
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                // Hataları inceleyip uygun bir şekilde cevap verebilirsiniz

                return BadRequest(new { message = "E-posta adresi doğru formatta değil", errors = ModelState });
            }

            // Eğer model doğruluğu sağlanıyorsa, işlemlerinizi gerçekleştirirsiniz
            _unitOfWork.Users.Add(user);
            _unitOfWork.Save();
            return Ok(); // Başarılı yanıt dönebilirsiniz
        }


        public IActionResult GetAll()
        {

            return Json(_unitOfWork.Users.GetAll().Include(u => u.UserType).ToList());
        }

        public IActionResult GetAllRoles()
        {

            return Json(_unitOfWork.UserTypes.GetAll().ToList());
        }
        [HttpPost]
        public IActionResult DeleteById(int id)
        {
            _unitOfWork.Users.DeleteById(id);
            _unitOfWork.Save();
            return Ok(id);
        }
        [HttpPost]
        public IActionResult Update(AppUser appuser)
        {
            _unitOfWork.Users.Update(appuser);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
