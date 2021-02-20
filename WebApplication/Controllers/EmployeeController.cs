using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.DAL;
using WebApplication.Models;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    public class EmployeeController : Controller
    {
        private WorkContext db = new WorkContext();

        // GET: Employee
        public ActionResult Index(string sortOrder, string searchString)
        {

            ViewBag.LastNameSortParm = String.IsNullOrEmpty(sortOrder) ? "lastname_desc" : "";
            ViewBag.LocationSortParm = String.IsNullOrEmpty(sortOrder) ? "location_desc" : "";
            var employees = from s in db.Employees
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));
            }
            switch (sortOrder)
            {

                case "lastname_desc":
                    employees = employees.OrderByDescending(s => s.LastName);
                    break;
                case "location_desc":
                    employees = employees.OrderByDescending(s => s.Location);
                    break;

                default:
                    employees = employees.OrderBy(s => s.LastName);
                    break;
            }
            return View(employees.ToList());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id, int? projectID)
        {


            if (id == null)
            {             

               return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees
                .Include(i=>i.Projects)
                .Where(i => i.ID == id)
                .Single();

            if (employee == null)
            {
                return HttpNotFound();
            }
         

            if (projectID != null)
            {
                ViewBag.EmployeeID = projectID.Value;
                employee.Assignments = employee.Projects.Where(
                    x => x.ProjectID == projectID).Single().Assignments;
            }
            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            var employee = new Employee();
            employee.Projects = new List<Project>();
            PopulateAssignedProjectData(employee);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName, LastName, Location")] Employee employee, string[] selectedProjects)
        {

            //try
            //{
            //    if (ModelState.IsValid)
            //    {
            //        db.Employees.Add(employee);
            //        db.SaveChanges();
            //        return RedirectToAction("Index");
            //    }
            //}
            //catch (DataException /* dex */)
            //{

            //    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            //}
            if (selectedProjects != null)
            {
                employee.Projects = new List<Project>();
                foreach (var project in selectedProjects)
                {
                    var projectToAdd = db.Projects.Find(int.Parse(project));
                    employee.Projects.Add(projectToAdd);
                }
            }
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateAssignedProjectData(employee);
            return View(employee);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees
                .Include(i => i.Projects)
                .Where(i => i.ID == id)
                .Single();
            PopulateAssignedProjectData(employee);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        private void PopulateAssignedProjectData(Employee employee)
        {
            var allProjects = db.Projects;
            var employeeProjects = new HashSet<int>(employee.Projects.Select(c => c.ProjectID));
            var viewModel = new List<AssignedProjectData>();
            foreach (var project in allProjects)
            {
                viewModel.Add(new AssignedProjectData
                {
                    ProjectID = project.ProjectID,
                    Name = project.Name,
                    Assigned = employeeProjects.Contains(project.ProjectID)
                });
            }
            ViewBag.Projects = viewModel;
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id, string[] selectedProjects)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employeeToUpdate = db.Employees
                .Include(i => i.Projects)
                .Where(i => i.ID == id)
                .Single();
            if (TryUpdateModel(employeeToUpdate, "",
               new string[] { "FirstName", "LastName", "Location" }))
            {
                try
                {
                    UpdateEmployeeProjects(selectedProjects, employeeToUpdate);

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            PopulateAssignedProjectData(employeeToUpdate);

            return View(employeeToUpdate);
        }

        private void UpdateEmployeeProjects(string[] selectedProjects, Employee employeeToUpdate)
        {
            if (selectedProjects == null)
            {
                employeeToUpdate.Projects = new List<Project>();
                return;
            }

            var selectedProjectsHS = new HashSet<string>(selectedProjects);
            var employeeProjects = new HashSet<int>
                (employeeToUpdate.Projects.Select(c => c.ProjectID));
            foreach (var project in db.Projects)
            {
                if (selectedProjectsHS.Contains(project.ProjectID.ToString()))
                {
                    if (!employeeProjects.Contains(project.ProjectID))
                    {
                        employeeToUpdate.Projects.Add(project);
                    }
                }
                else
                {
                    if (employeeProjects.Contains(project.ProjectID))
                    {
                        employeeToUpdate.Projects.Remove(project);
                    }
                }
            }
        }

        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Employee employee = db.Employees.Find(id);
                db.Employees.Remove(employee);
                db.SaveChanges();
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
