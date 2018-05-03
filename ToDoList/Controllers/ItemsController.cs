using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using ToDoList.Models;
using System;

namespace ToDoList.Controllers
{
    public class ItemsController : Controller
    {
       [HttpGet("/categories/{categoryId}/items/new")]
       public ActionResult CreateForm(int categoryId)
       {
          Dictionary<string, object> model = new Dictionary<string, object>();
          Category category = Category.Find(categoryId);
          return View(category);
       }

       [HttpGet("/categories/{categoryId}/items/{itemId}")]
       public ActionResult Details(int categoryId, int itemId)
       {
          Item item = Item.Find(itemId);
          Dictionary<string, object> model = new Dictionary<string, object>();
          Category category = Category.Find(categoryId);
          model.Add("item", item);
          model.Add("category", category);
          return View(item);
       }

       [HttpGet("/items/{id}/update")]
        public ActionResult UpdateForm(int id)
        {
            Item thisItem = Item.Find(id);
            return View(thisItem);
        }

        [HttpGet("/items/{id}/delete")]
         public ActionResult DeleteItem(int id)
         {
             Item.DeleteItem(id);
             return RedirectToAction("Details", "Categories", new { id = id });
         }
    }
}
