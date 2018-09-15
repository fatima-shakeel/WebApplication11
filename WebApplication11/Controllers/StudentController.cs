using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication11.Models;

namespace WebApplication11.Controllers
{
    public class StudentController : Controller
    {


        StudentContext _ORM = null;
        public StudentController(StudentContext ORM)
        {
            _ORM = ORM;
        }
        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(Student S)
        {
            _ORM.Student.Add(S);
            _ORM.SaveChanges();
            ViewBag.Message="DOne succesfully";
           
            
            return View(S);
        }

        [HttpGet]
        public IActionResult AllStudents()
        {
            IList<Student> AllStudents = _ORM.Student.ToList<Student>();

            return View(AllStudents);
        }

        [HttpPost]
        public IActionResult AllStudents(string SearchByName, string SearchByClass, string SearchByRollNo, string SearchByPhoneNo, string SearchByFatherName, string SearchByAddress, string SearchByEmail, string SearchBySubject)
        {
            IList<Student> AllStudents = _ORM.Student.Where(m => m.Name.Contains(SearchByName) || m.Class.Contains(SearchByClass) || m.Name.Contains(SearchByRollNo) || m.Name.Contains(SearchByPhoneNo) || m.Name.Contains(SearchByFatherName) || m.Name.Contains(SearchByAddress) || m.Name.Contains(SearchByEmail) || m.Name.Contains(SearchBySubject)).ToList<Student>();

            return View(AllStudents);
        }

        public IActionResult DeleteStudent(Student S)
        {
            // Student S =  ORM.Student.Where(a => a.Id == Id).FirstOrDefault<Student>();
            _ORM.Student.Remove(S);
            _ORM.SaveChanges();
            ViewBag.Message = "Deleted Successfully";
            //return View("AllStudents");
            return RedirectToAction("AllStudents");
        }

        public IActionResult StudentDetail(int Id)
        {
            Student S = _ORM.Student.Where(m => m.Id == Id).FirstOrDefault<Student>();
            return View(S);
        }


        [HttpGet]
        public IActionResult EditStudent(int Id)
        {

            Student S = _ORM.Student.Where(m => m.Id == Id).FirstOrDefault<Student>();
            return View(S);
        }
        [HttpPost]
        public IActionResult EditStudent(Student S)
        {
            _ORM.Student.Update(S);
            _ORM.SaveChanges();
            //Student S = ORM.Student.Where(m => m.Id == Id).FirstOrDefault<Student>();
            return RedirectToAction("AllStudents");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}