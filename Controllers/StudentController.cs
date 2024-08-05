using DotNet5Crud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet5Crud.Controllers
{
    public class StudentController : Controller
    {
        private readonly CompanyDBContext _context;

        public StudentController(CompanyDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var student = await _context.Students.ToListAsync();
            return View(student);
        }

        public IActionResult BookskyIndex()
        {
            return View();
        }

        //AddOrEdit Get Method
        public async Task<IActionResult> AddOrEdit(int? studentId)
        {
            ViewBag.PageName = studentId == null ? "Create Student" : "Edit Student";
            ViewBag.IsEdit = studentId == null ? false : true;
            if (studentId == null)
            {
                return View();
            }
            else
            {
                var student = await _context.Students.FindAsync(studentId);

                if (student == null)
                {
                    return NotFound();
                }
                return View(student);
            }        
        }

        //AddOrEdit Post Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int studentId, [Bind("studentId,Name,Age,Gender,Phone,Email,Course,JoiningDate")]
        Student studentData)
        {
            bool IsStudentExist = false;

            Student student = await _context.Students.FindAsync(studentId);

            if (student != null)
            {
                IsStudentExist = true;
            }
            else
            {
                student = new Student();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    student.Name = studentData.Name;
                    student.Age = studentData.Age;
                    student.Gender = studentData.Gender;
                    student.Phone = studentData.Phone;
                    student.Email = studentData.Email;
                    student.Course = studentData.Course;
                    student.JoiningDate = studentData.JoiningDate;

                   if(IsStudentExist)
                    {
                        _context.Update(student);
                    }
                    else
                    {
                        _context.Add(student);
                    }                   
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(studentData);
        }

        // Employee Details
        public async Task<IActionResult> Details(int? studentId)
        {
            if (studentId == null)
            {
                return NotFound();
            }
            var student = await _context.Students.FirstOrDefaultAsync(m => m.StudentId == studentId);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // GET: Employees/Delete/1
        public async Task<IActionResult> Delete(int? studentId)
        {
            if (studentId == null)
            {
                return NotFound();
            }
            var student = await _context.Students.FirstOrDefaultAsync(m => m.StudentId == studentId);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Employees/Delete/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int studentId)
        {
            var student = await _context.Students.FindAsync(studentId);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
