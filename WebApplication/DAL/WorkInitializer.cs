using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.DAL
{
    public class WorkInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<WorkContext>
    {
        protected override void Seed(WorkContext context)
        {
            var employees = new List<Employee>
            {
           new Employee{FirstName="Carson",LastName="Alexander", Contract = Contract.B2B, Location=Location.Kraków},
            new Employee{FirstName="Meredith",LastName="Alonso", Contract = Contract.B2B, Location=Location.Warszawa},
            new Employee{FirstName="Arturo",LastName="Anand", Contract = Contract.UoP, Location=Location.Warszawa },
            new Employee{FirstName="Gytis",LastName="Barzdukas", Contract = Contract.UZ, Location=Location.Kraków},
            new Employee{FirstName="Yan",LastName="Li", Contract = Contract.UZ, Location=Location.Wrocław},
            new Employee{FirstName="Peggy",LastName="Justice",Contract = Contract.UoP, Location=Location.Wrocław},
            new Employee{FirstName="Laura",LastName="Norman", Contract = Contract.B2B, Location=Location.Wrocław},
            new Employee{FirstName="Nino",LastName="Olivetto", Contract = Contract.B2B, Location=Location.Kraków}
            };

            employees.ForEach(s => context.Employees.Add(s));
            context.SaveChanges();
            var projects = new List<Project>
            {
            new Project{ProjectID=1,Name="Chemistry", Description="Chemistry is the scientific discipline involved with elements and compounds composed of atoms, molecules and ions: their composition, structure, properties, behavior and the changes they undergo during a reaction with other substances.In the scope of its subject, chemistry occupies an intermediate position between physics and biology.[5] It is sometimes called the central science because it provides a foundation for understanding both basic and applied scientific disciplines at a fundamental level.[6] For example, chemistry explains aspects of plant chemistry(botany), the formation of igneous rocks(geology), how atmospheric ozone is formed and how environmental pollutants are degraded(ecology), the properties of the soil on the moon(cosmochemistry), how medications work(pharmacology), and how to collect DNA evidence at a crime scene(forensics)."},
            new Project{ProjectID=2,Name="Microeconomics",Description="Microeconomics is the study of individuals, households and firms' behavior in decision making and allocation of resources. It generally applies to markets of goods and services and deals with individual and economic issues.Description: Microeconomic study deals with what choices people make, what factors influence their choices and how their decisions affect the goods markets by affecting the price, the supply and demand."},
            new Project{ProjectID=3,Name="Macroeconomics", Description = "Macroeconomics (from the Greek prefix makro- meaning large + economics) is a branch of economics dealing with the performance, structure, behavior, and decision-making of an economy as a whole. For example, using interest rates, taxes and government spending to regulate an economy's growth and stability."},
            new Project{ProjectID=4,Name="Calculus", Description="Calculus, originally called infinitesimal calculus or the calculus of infinitesimals, is the mathematical study of continuous change, in the same way that geometry is the study of shape and algebra is the study of generalizations of arithmetic operations.It has two major branches, differential calculus and integral calculus; the former concerns instantaneous rates of change, and the slopes of curves, while integral calculus concerns accumulation of quantities, and areas under or between curves. These two branches are related to each other by the fundamental theorem of calculus, and they make use of the fundamental notions of convergence of infinite sequences and infinite series to a well-defined limit.[1]"},

            };
            projects.ForEach(s => context.Projects.Add(s));
            context.SaveChanges();
            var assignments = new List<Assignment>
            {
            new Assignment{EmployeeID=1,ProjectID=1},
            new Assignment{EmployeeID=1,ProjectID=4},
            new Assignment{EmployeeID=1, ProjectID=3},
            new Assignment{EmployeeID=2,ProjectID=1},
            new Assignment{EmployeeID=2,ProjectID=2},
            new Assignment{EmployeeID=2,ProjectID=4},
            new Assignment{EmployeeID=3,ProjectID=3},
            new Assignment{EmployeeID=4,ProjectID=1},
            new Assignment{EmployeeID=4,ProjectID=4},
            new Assignment{EmployeeID=5,ProjectID=4},
            new Assignment{EmployeeID=6,ProjectID=1},
            new Assignment{EmployeeID=7,ProjectID=3},
            };
            assignments.ForEach(s => context.Assignments.Add(s));
            context.SaveChanges();
        }
    }
}
