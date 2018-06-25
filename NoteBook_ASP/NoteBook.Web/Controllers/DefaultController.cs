using NoteBook.Domain.Abstract;
using NoteBook.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace NoteBook.Web.Controllers
{
    public class DefaultController : Controller
    {
        private IRepository mRepository;
        public DefaultController(IRepository _projectRepository)
        {
            mRepository = _projectRepository;
            
        }

        // GET: Default
        public ViewResult Index()
        {
            //var x = mRepository.States;
            //var y = mRepository.Orders.Count();

            //var x1 = mRepository.Orders;
            //var y1 = mRepository.Orders.Count();
            //return View(x);
            return View();
        }

        [System.Web.Mvc.HttpPost]
        //[HttpGet]
        public JsonResult DoAction()
        {
            dynamic result = new { };
            if (Request["action"] != null)
            {
                String actionString = Request["action"];
                switch (actionString)
                {
                    case "test-param":
                        {
                            if (Request["state-id"] != null)
                            {
                                try
                                {
                                    result =
                                        mRepository.States.ToArray();
                                }
                                catch (Exception ex)
                                {

                                    result = new { error = ex.Message };
                                }
                            }
                            break;
                        }
                    case "orders":
                        {
                            try
                            {
                                /*result =
                                    mRepository.Orders.ToArray();*/
                                result =
                                    new
                                    {
                                        pagesData = mRepository.Orders.ToArray()
                                    };
                            }
                            catch (Exception ex)
                            {

                                result = new { error = ex.Message };
                            }
                            break;
                        }
                    case "order":
                        {
                            if (Request["id"] != null)
                            {
                                try
                                {
                                    int id = Int32.Parse(Request["id"]);
                                    AnOrder order =
                                        (from o in mRepository.Orders
                                            where o.id == id
                                            select o
                                        ).Single();
                                    result =
                                        new
                                        {
                                            id = order.id
                                            , descr = order.description
                                            , cust  = order.customer_name
                                        };
                                }
                                catch (Exception ex)
                                {

                                    result = new { error = ex.Message };
                                }
                            }
                            break;
                        }
                    case "order-edit":
                        {
                            if (Request["id"] != null)
                            {
                                try
                                {
                                    int selectedId = Int32.Parse(Request["id"]);

                                    /*AnOrder order =
                                        (from o in mRepository.Orders
                                         where o.id == id
                                         select o
                                        ).Single();*/

                                    //State state =
                                    //    (from s in mRepository.States
                                    //     where s.name == "created"
                                    //     select s
                                    //    ).Single();

                                    AnOrder order = new AnOrder()
                                    {
                                        id = selectedId,
                                        customer_name = Request["order-customer"],
                                        description = Request["order-description"],
                                        created_at = new DateTime(),
                                        //state_id = state.id,
                                        //State = state
                                    };

                                    result = mRepository.SaveOrder(order);

                                    /*result =
                                        new
                                        {
                                            id = order.id
                                            ,
                                            descr = order.description
                                            ,
                                            cust = order.customer_name
                                        };*/
                                }
                                catch (Exception ex)
                                {

                                    result = new { error = ex.Message };
                                }
                            }
                            break;
                        }
                    //////////////////////////////////////////////////////////////////////////////////////////////
                    case "order-add":
                        {
                            AnOrder order = new AnOrder()
                            {

                                customer_name = Request["order-customer"],
                                description = Request["order-description"],
                                state_id = 1,
                                created_at = new DateTime(),
                                //state_id = state.id,
                                //State = state

                            };
                        try
                        {
                            mRepository.AddOrder(order);
                            result = new { add = "ok" };
                        }
                        catch (Exception ex)
                        {
                            result = new { error = ex.InnerException.InnerException.Message };
                        }

                            //    }
                            //    catch (Exception ex)
                            //    {

                            //        result = new { error = ex.Message };
                            //    }
                            //}
                        }
                            break;
                    ///////////////////////////////////////////////////////////////////////////////////////////////////
                    case "login-add":
                        {
                            User users = new User()
                            {

                                login = Request["login"],
                                password = Request["password"],
                                user_type_id = 1,
                            };
                            try
                            {
                                mRepository.addLogin(users);
                                result = new { add = "ok" };
                            }
                            catch (Exception ex)
                            {
                                result = new { error = ex.InnerException.InnerException.Message };
                            }

                            //    }
                            //    catch (Exception ex)
                            //    {

                            //        result = new { error = ex.Message };
                            //    }
                            //}
                        }
                        break;
                    //////////////////////////////////////////////////////////////////////////////////////////////////
                    case "order-del":
                        {
                            if (Request["id"] != null)
                            {
                                try
                                {
                                    int selectedId = Int32.Parse(Request["id"]);
                                  
                                    mRepository.DelOrder(selectedId);
                                    result = new { deleted = "ok" };

                                }
                                catch (Exception ex)
                                {

                                    result = new { error = ex.Message };
                                }
                            }
                            break;
                        }
                    //////////////////////////////////////////////////////////////////// State
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
                    /*case "state-del":
                        {
                            if (Request["states"] != null)
                            {
                                try
                                {
                                    //int selectedId = Int32.Parse(Request["id"]);

                                    //mRepository.DelOrder(selectedId);
                                    //result = new { deleted = "ok" };
                                    result = new { deleted = Request["states"] };

                                }
                                catch (Exception ex)
                                {

                                    result = new { error = ex.Message };
                                }
                            }
                            break;
                        }*/
                    ///////////////////////////////////////////////////////////////////////////EndState
                    default:
                        break;
                }
            }
            return Json(result);
            //return Json(result, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Mvc.HttpPost]
        //[HttpGet]
        public JsonResult DoActionModel([FromUri] int[] states)
        {
            dynamic result = new { };
            if (Request["action"] != null)
            {
                String actionString = Request["action"];
                switch (actionString)
                {
                    case "state-del":
                        {
                            try
                            {
                                int[] deletedIds = new int[states.Length];
                                int i = 0;
                                foreach (var item in states)
                                {
                                    mRepository.DelState(item);
                                    deletedIds[i] = item;
                                        i++;
                                }
                                result = new { deleted = deletedIds };
                                //result = new { deleted = states };

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