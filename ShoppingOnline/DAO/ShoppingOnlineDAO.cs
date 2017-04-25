using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingOnline.Models;

namespace ShoppingOnline.DAO
{
   
    public class ShoppingOnlineDAO
    {
        Models.MCVEntityes entity = new Models.MCVEntityes();

        public void save(Models.Customers customer) {
            entity.Customers.Add(customer);
            entity.SaveChanges();
        }
        public void insertbay(Models.Orders bays)
        {
            entity.Orders.Add(bays);
            entity.SaveChanges();
        }

        public void insertProduct(Models.Products why)
        {
            entity.Products.Add(why);
            entity.SaveChanges();
        }

        public List<Categorys> Getcategories()
        {
            List<Categorys> list = new List<Categorys>();
            list = entity.Categorys.ToList();
            return list;
        }

        public List<Categorys> Showcategories()
        {
            List<Categorys> list = new List<Categorys>();
            list = entity.Categorys.ToList();
            return list;
        }

        public List<Products> Showwheyprotein(int id)
        {
            List<Products> list = new List<Products>();
            list = entity.Products.Where(x => x.CategoryID == id).ToList();
            return list;
        }

        public List<Customers> Showmember()
        {
            List<Customers> list = new List<Customers>();
            list = entity.Customers.ToList();
            return list;
        }


        public List<Products> Showproducts(int id)
        {
            List<Products> list = new List<Products>();
            list = entity.Products.Where(x => x.CategoryID == id).ToList();
            return list;
        }

        public List<Orders> Showorders()
        {
            List<Orders> list = new List<Orders>();
            list = entity.Orders.Where(x => x.status_bay == 0).ToList();
            return list;
        }

        public List<Orders> Showorders2()
        {
            List<Orders> list = new List<Orders>();
            list = entity.Orders.Where(x => x.status_bay == 1).ToList();
            return list;
        }
        

        public void Deleteproducts(int id)
        {
            var del = entity.Products.Where(x => x.ProductID == id).FirstOrDefault();
            entity.Entry(del).State = System.Data.EntityState.Deleted;
            entity.SaveChanges();
        }

        public void Deletewhey(int id)
        {
            var del = entity.Products.Where(x => x.ProductID == id).FirstOrDefault();
            entity.Entry(del).State = System.Data.EntityState.Deleted;
            entity.SaveChanges();
        }
        public void DeleteOrders(int id) {
            var delete = entity.Orders.Where(x => x.OrderID == id).FirstOrDefault();
            entity.Entry(delete).State = System.Data.EntityState.Deleted;
            entity.SaveChanges();
        }
        public void Updatebay(int id)
        {
            var userDB = entity.Orders.Where(x => x.OrderID == id).FirstOrDefault();
            userDB.status_bay = 1;

            entity.Entry(userDB).State = System.Data.EntityState.Modified;
            entity.SaveChanges();
        }
       

        public void Deletemember(int id)
        {
            var del = entity.Customers.Where(x => x.CustomerID == id).FirstOrDefault();
            entity.Entry(del).State = System.Data.EntityState.Deleted;
            entity.SaveChanges();
        }

        public void DeleteOrder(int id) {
            var dels = entity.Orders.Where(x => x.OrderID == id).FirstOrDefault();
            entity.Entry(dels).State = System.Data.EntityState.Deleted;
            entity.SaveChanges();
        }

        public Models.Products Getproduct(int id)
        {
            return entity.Products.Where(x => x.ProductID == id).FirstOrDefault();
        }

        public Models.Customers Getmember(int id)
        {
            return entity.Customers.Where(x => x.CustomerID == id).FirstOrDefault();
        }

       

        public Models.Products GetProducts(int id)
        {
            return entity.Products.Where(x => x.ProductID == id).FirstOrDefault();
        }

        public void Update(Models.Products prod)
        {
            var userDB = entity.Products.Where(x => x.ProductID == prod.ProductID).FirstOrDefault();
            userDB.CategoryID = prod.CategoryID;
            userDB.ProductName = prod.ProductName;
            userDB.Stock = prod.Stock;
            userDB.Price = prod.Price;
            userDB.Details = prod.Details;

            entity.Entry(userDB).State = System.Data.EntityState.Modified;
            entity.SaveChanges();
        }

       

        public void UpdatProduct(Models.Products why)
        {
            var userDB = entity.Products.Where(x => x.ProductID == why.ProductID).FirstOrDefault();
            userDB.ProductName = why.ProductName;
            userDB.Price = why.Price;
            userDB.Stock = why.Stock;

            entity.Entry(userDB).State = System.Data.EntityState.Modified;
            entity.SaveChanges();
        }
        public void Updatemem(Models.Customers mem)
        {
            var userDB = entity.Customers.Where(x => x.CustomerID == mem.CustomerID).FirstOrDefault();
            userDB.ContactName = mem.ContactName;
            userDB.Password = mem.Password;
            userDB.Phone = mem.Phone;
            userDB.Address = mem.Address;
           
            entity.Entry(userDB).State = System.Data.EntityState.Modified;
            entity.SaveChanges();
        }

        
    }
}