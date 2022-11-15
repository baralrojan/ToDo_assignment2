using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ToDoController : Controller
    {

        public ToDoContext _db;

        public ToDoController(ToDoContext ctx)
        {
            _db = ctx;//initialize ToDoContext to _db
        }

        //get all TodoList from databse and return it to index
        public IActionResult Index()
        {
            var TodoList = _db.ToDoList.ToList();
            return View(TodoList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //save user entered Todo to the database
        [HttpPost]
        public RedirectResult Create(ToDoLists ToDo)
        {
            if(ModelState.IsValid)
            {
                _db.ToDoList.Add(ToDo);
                _db.SaveChanges();
            }
            //redirect result to the index page
            return Redirect("Index");

        }

       
        
      
       
        



    }
}
