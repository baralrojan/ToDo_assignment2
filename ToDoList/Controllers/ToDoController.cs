using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ToDoController : Controller
    {
       // public ToDoLists ToDoList = new ToDoLists() { ToDoValue = "Read 2 hours daily" };

        public ToDoContext _db;

        public ToDoController(ToDoContext ctx)
        {
            _db = ctx;
        }

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

        [HttpPost]
        public RedirectResult Create(ToDoLists ToDo)
        {
            if(ModelState.IsValid)
            {
                _db.ToDoList.Add(ToDo);
                _db.SaveChanges();
            }
            return Redirect("Index");

        }

       
        
      
       
        



    }
}
