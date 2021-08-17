using MVCCRUD_Training.Service;
using MVCCRUD_Training.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MVCCRUD_Training.Controllers
{
    public class AnswerController : Controller
    {
        StudentDataService service = new StudentDataService();
        // GET: Answer
        public ActionResult Index()
        {
            var answer = new ViewModel.AnswerViewModel
            {
                AccessID = "1232",
                AnswerName = "Dot net",
                AnswerValue = ".net",
                FormTypeId = 1
            };
            service.AddAnswer(answer);

            service.UpdateAnswer(new ViewModel.AnswerViewModel
            {
                Id = 1,
                AnswerValue = "abcd",
                AnswerName = "HTML"
            });

            var answerList = service.GetAnswerList();
            var answerDto = service.GetAnswer(2);
            return View();
        }

        [HttpPost]
        public JsonResult PostAnswer(AnswerViewModel model)
        {
            var result = service.AddAnswer(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateAnswer(AnswerViewModel model)
        {
            var result = service.UpdateAnswer(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetAllAnswers()
        {
            var result = service.GetAnswerList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetAnswer(int answerId)
        {
            var result = service.GetAnswer(answerId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult DeleteAsnwer(int answerId)
        {
            var result = service.DeleteAnswer(answerId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}