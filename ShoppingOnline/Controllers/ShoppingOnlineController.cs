using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingOnline.Models;

namespace ShoppingOnline.Controllers
{
    public class ShoppingOnlineController : Controller
    {
        //
        // GET: /ShoppingOnline/
        DAO.ShoppingOnlineDAO dao = new DAO.ShoppingOnlineDAO();
  
        public ActionResult Login()
        {
            Session["CustomerID"] = null;
            Session["ContactName"] = null;
            Session["Status"] = null;
            return View();
        }
        [HttpPost]
        public ActionResult Login(Customers memb)
        {
            MCVEntityes entity = new MCVEntityes();
            var chk = entity.Customers.Where(x => x.ContactName == memb.ContactName && x.Password == memb.Password).FirstOrDefault();
            if (chk != null)
            {
                Session["CustomerID"] = chk.CustomerID.ToString();
                Session["ContactName"] = chk.ContactName.ToString();
                Session["Status"] = chk.Status;
                return RedirectToAction("Index");
            }
            return View(memb);
        }
      

        [HttpPost]
        public ActionResult insertProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult insertProduct(Models.Products why)
        {
            dao.insertProduct(why);
            return RedirectToAction("Index", "ShoppingOnline");
        }

        public ActionResult Index()
        {
            return View(dao.Showcategories());
        }
        [HttpGet]
        public ActionResult regiters()
        {
            return View();
        }
        [HttpPost]
        public ActionResult regiters(Models.Customers memb)
        {
            dao.save(memb);
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult deleteporduct(int id)
        {
            dao.Deleteproducts(id);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult deleteProduct(int id)
        {
            dao.Deletewhey(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult deletemem(int id)
        {
            dao.Deletemember(id);
            return RedirectToAction("showmember");
        }
        public ActionResult deleteOrder(int id) {
            dao.DeleteOrder(id);
            return RedirectToAction("showorders");
        }

        public ActionResult deleteOrders(int id) {
            dao.DeleteOrders(id);
            return RedirectToAction("showorders2");
        }



        [HttpGet]
        public ActionResult editporduct(int id)
        {
            ViewBag.list = Selectcategorise();
            Models.Products prod = dao.Getproduct(id);
            return View(prod);

        }

        [HttpPost]
        public ActionResult editporduct(Models.Products prod)
        {
            dao.Update(prod);
            return RedirectToAction("Index", "ShoppingOnline");
        }


        [HttpGet]
        public ActionResult editwhey(int id)
        {

            Models.Products why = dao.GetProducts(id);
            return View(why);

        }

        [HttpPost]
        public ActionResult editwhey(Models.Products why)
        {
            dao.UpdatProduct(why);
            return RedirectToAction("showwhey", "ShoppingOnline");
        }




        [HttpGet]
        public ActionResult editmem(int id)
        {

            Models.Customers why = dao.Getmember(id);
            return View(why);

        }
        [HttpPost]
        public ActionResult editmem(Models.Customers mem)
        {
            dao.Updatemem(mem);
            return RedirectToAction("showmember", "ShoppingOnline");
        }

        [HttpGet]
        public ActionResult editbay(int id)
        {
            dao.Updatebay(id);
            return RedirectToAction("showorders2");
        }







        public ActionResult insertproduct()
        {
            ViewBag.list = Selectcategorise();
            return View();
        }
        [HttpPost]
        public ActionResult insertproduct(Models.Products prod)
        {
            dao.insertProduct(prod);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult showproducts(int id)
        {
            return View(dao.Showproducts(id));
        }

        public ActionResult showcategorise()
        {
            return View(dao.Showcategories());
        }

        public ActionResult showwhey(int id)
        {
            return View(dao.Showwheyprotein(id));
        }

        public ActionResult showmember()
        {
            return View(dao.Showmember());
        }

        public ActionResult showorders()
        {
            return View(dao.Showorders());
        }

        public ActionResult showorders2()
        {
            return View(dao.Showorders2());
        }

        [HttpPost]
        public ActionResult showwhey(Models.Orders bays)
        {
            dao.insertbay(bays);
            return RedirectToAction("Index");
        }

        public List<SelectListItem> Selectcategorise()
        {
            List<SelectListItem> listCategory = new List<SelectListItem>();
            List<Categorys> list = dao.Getcategories();
            foreach (Categorys cd in list)
            {
                SelectListItem item = new SelectListItem();
                item.Text = cd.CategoryName;
                item.Value = cd.CategoryID.ToString();
                listCategory.Add(item);
            }
            return listCategory;
        }
	}
}