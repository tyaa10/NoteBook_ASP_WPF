using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NoteBook.Domain.Abstract;
using NoteBook.Domain.Entity;

namespace NoteBook.Web.Controllers
{
    public class StatesController : Controller
    {
        //
        // GET: /States/
        private IRepository mRepository;
        public StatesController(IRepository _projectRepository)
        {
            mRepository = _projectRepository;
        }


        public ViewResult Index()
        {
            return View();
        }
        [HttpPost]
        //[HttpGet]
        public JsonResult DoAction()
        {
            dynamic result = new { };
            if (Request["action"] != null)
            {
                String actionString = Request["action"];
                switch (actionString)
                {
                    case "state-add":
                        {
                            State state = new State()
                            {

                                name = Request["name"],


                            };
                            try
                            {
                                mRepository.addState(state);
                                result = new { add = "ok" };
                            }
                            catch (Exception ex)
                            {
                                result = new { error = ex.InnerException.InnerException.Message };
                            }
                        }
                        break;
                    case "states":
                        {
                            try
                            {

                                result =
                                    new
                                    {
                                        pagesData = mRepository.States.ToArray()
                                    };
                            }
                            catch (Exception ex)
                            {

                                result = new { error = ex.Message };
                            }
                            break;
                        }

                    ///////////////////////////////////////////////////////////////////////////EndState
                    default:
                        break;
                }
            }
            return Json(result);
            //return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
