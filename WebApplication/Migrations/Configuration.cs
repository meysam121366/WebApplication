namespace WebApplication.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApplication.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication.DAL.WorkContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApplication.DAL.WorkContext context)
        {
            var employees = new List<Employee>
            {
             new Employee{FirstName="Carson",LastName="Alexander", Contract = Contract.B2B, Location=Location.Kraków, },
            new Employee{FirstName="Meredith",LastName="Alonso", Contract = Contract.B2B, Location=Location.Warszawa},
            new Employee{FirstName="Arturo",LastName="Anand", Contract = Contract.UoP, Location=Location.Warszawa },
            new Employee{FirstName="Gytis",LastName="Barzdukas", Contract = Contract.UZ, Location=Location.Kraków},
            new Employee{FirstName="Yan",LastName="Li", Contract = Contract.UZ, Location=Location.Wrocław},
            new Employee{FirstName="Peggy",LastName="Justice",Contract = Contract.UoP, Location=Location.Wrocław},
            new Employee{FirstName="Laura",LastName="Norman", Contract = Contract.B2B, Location=Location.Wrocław},
            new Employee{FirstName="Nino",LastName="Olivetto", Contract = Contract.B2B, Location=Location.Kraków}
            };
            employees.ForEach(s => context.Employees.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var projects = new List<Project>
            {
            new Project{ProjectID=1,Name="Chemistry",
                Description="Chemistry is the scientific discipline involved with elements and compounds composed of atoms, molecules and ions: their composition, structure, properties, behavior and the changes they undergo during a reaction with other substances.In the scope of its subject, chemistry occupies an intermediate position between physics and biology.[5] It is sometimes called the central science because it provides a foundation for understanding both basic and applied scientific disciplines at a fundamental level.[6] For example, chemistry explains aspects of plant chemistry(botany), the formation of igneous rocks(geology), how atmospheric ozone is formed and how environmental pollutants are degraded(ecology), the properties of the soil on the moon(cosmochemistry), how medications work(pharmacology), and how to collect DNA evidence at a crime scene(forensics).",
                Employees = new List<Employee>()},
            new Project{ProjectID=2,Name="Microeconomics",
                Description="Microeconomics is the study of individuals, households and firms' behavior in decision making and allocation of resources. It generally applies to markets of goods and services and deals with individual and economic issues.Description: Microeconomic study deals with what choices people make, what factors influence their choices and how their decisions affect the goods markets by affecting the price, the supply and demand.",
                Employees = new List<Employee>()},
            new Project{ProjectID=3,Name="Macroeconomics",
                Description = "Macroeconomics (from the Greek prefix makro- meaning large + economics) is a branch of economics dealing with the performance, structure, behavior, and decision-making of an economy as a whole. For example, using interest rates, taxes and government spending to regulate an economy's growth and stability.",
                Employees = new List<Employee>()},
            new Project{ProjectID=4,Name="Calculus",
                Description="Calculus, originally called infinitesimal calculus or the calculus of infinitesimals, is the mathematical study of continuous change, in the same way that geometry is the study of shape and algebra is the study of generalizations of arithmetic operations.It has two major branches, differential calculus and integral calculus; the former concerns instantaneous rates of change, and the slopes of curves, while integral calculus concerns accumulation of quantities, and areas under or between curves. These two branches are related to each other by the fundamental theorem of calculus, and they make use of the fundamental notions of convergence of infinite sequences and infinite series to a well-defined limit.[1]",
                Employees = new List<Employee>()},

            };
            projects.ForEach(s => context.Projects.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var steps = new List<Step>
            {
                new Step {StepID=1, Name="The classic latin passage that just never gets old, enjoy as much (or as little) lorem ipsum as you can handle with our easy to use filler text generator.", Info="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                    ProjectID = projects.Single(i=> i.Name == "Chemistry").ProjectID },
                new Step {StepID=2, Name="The classic latin passage that just never gets old, enjoy as much (or as little) lorem ipsum as you can handle with our easy to use filler text generator.", Info="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                    ProjectID = projects.Single(i=> i.Name == "Chemistry").ProjectID },
                new Step {StepID=3, Name="The classic latin passage that just never gets old, enjoy as much (or as little) lorem ipsum as you can handle with our easy to use filler text generator.", Info="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                    ProjectID = projects.Single(i=> i.Name == "Chemistry").ProjectID },
                new Step {StepID=4, Name="The classic latin passage that just never gets old, enjoy as much (or as little) lorem ipsum as you can handle with our easy to use filler text generator.", Info="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                    ProjectID = projects.Single(i=> i.Name == "Chemistry").ProjectID },
                new Step {StepID=5, Name="The classic latin passage that just never gets old, enjoy as much (or as little) lorem ipsum as you can handle with our easy to use filler text generator.", Info="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                    ProjectID = projects.Single(i=> i.Name == "Chemistry").ProjectID },
                new Step {StepID=6, Name="The classic latin passage that just never gets old, enjoy as much (or as little) lorem ipsum as you can handle with our easy to use filler text generator.", Info="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                    ProjectID = projects.Single(i=> i.Name == "Chemistry").ProjectID },
                new Step {StepID=7, Name="The classic latin passage that just never gets old, enjoy as much (or as little) lorem ipsum as you can handle with our easy to use filler text generator.", Info="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                    ProjectID = projects.Single(i=> i.Name == "Chemistry").ProjectID },
                new Step {StepID=8, Name="The classic latin passage that just never gets old, enjoy as much (or as little) lorem ipsum as you can handle with our easy to use filler text generator.", Info="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                    ProjectID = projects.Single(i=> i.Name == "Microeconomics").ProjectID },
                new Step {StepID=9, Name="The classic latin passage that just never gets old, enjoy as much (or as little) lorem ipsum as you can handle with our easy to use filler text generator.", Info="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                    ProjectID = projects.Single(i=> i.Name == "Microeconomics").ProjectID },
                new Step {StepID=10, Name="The classic latin passage that just never gets old, enjoy as much (or as little) lorem ipsum as you can handle with our easy to use filler text generator.", Info="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                    ProjectID = projects.Single(i=> i.Name == "Microeconomics").ProjectID },
                new Step {StepID=11, Name="The classic latin passage that just never gets old, enjoy as much (or as little) lorem ipsum as you can handle with our easy to use filler text generator.", Info="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                    ProjectID = projects.Single(i=> i.Name == "Microeconomics").ProjectID },
                new Step {StepID=12, Name="The classic latin passage that just never gets old, enjoy as much (or as little) lorem ipsum as you can handle with our easy to use filler text generator.", Info="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                    ProjectID = projects.Single(i=> i.Name == "Macroeconomics").ProjectID },
                new Step {StepID=13, Name="The classic latin passage that just never gets old, enjoy as much (or as little) lorem ipsum as you can handle with our easy to use filler text generator.", Info="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                    ProjectID = projects.Single(i=> i.Name == "Macroeconomics").ProjectID },
                new Step {StepID=14, Name="The classic latin passage that just never gets old, enjoy as much (or as little) lorem ipsum as you can handle with our easy to use filler text generator.", Info="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                    ProjectID = projects.Single(i=> i.Name == "Macroeconomics").ProjectID },
                new Step {StepID=15, Name="The classic latin passage that just never gets old, enjoy as much (or as little) lorem ipsum as you can handle with our easy to use filler text generator.", Info="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                    ProjectID = projects.Single(i=> i.Name == "Macroeconomics").ProjectID },
                new Step {StepID=16, Name="The classic latin passage that just never gets old, enjoy as much (or as little) lorem ipsum as you can handle with our easy to use filler text generator.", Info="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                    ProjectID = projects.Single(i=> i.Name == "Macroeconomics").ProjectID },
                new Step {StepID=17, Name="The classic latin passage that just never gets old, enjoy as much (or as little) lorem ipsum as you can handle with our easy to use filler text generator.", Info="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                    ProjectID = projects.Single(i=> i.Name == "Calculus").ProjectID },
                new Step {StepID=18, Name="The classic latin passage that just never gets old, enjoy as much (or as little) lorem ipsum as you can handle with our easy to use filler text generator.", Info="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                    ProjectID = projects.Single(i=> i.Name == "Calculus").ProjectID },
                new Step {StepID=19, Name="The classic latin passage that just never gets old, enjoy as much (or as little) lorem ipsum as you can handle with our easy to use filler text generator.", Info="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                    ProjectID = projects.Single(i=> i.Name == "Calculus").ProjectID },
                new Step {StepID=20, Name="The classic latin passage that just never gets old, enjoy as much (or as little) lorem ipsum as you can handle with our easy to use filler text generator.", Info="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                    ProjectID = projects.Single(i=> i.Name == "Calculus").ProjectID },
                new Step {StepID=21, Name="The classic latin passage that just never gets old, enjoy as much (or as little) lorem ipsum as you can handle with our easy to use filler text generator.", Info="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                    ProjectID = projects.Single(i=> i.Name == "Calculus").ProjectID },
                new Step {StepID=22, Name="The classic latin passage that just never gets old, enjoy as much (or as little) lorem ipsum as you can handle with our easy to use filler text generator.", Info="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                    ProjectID = projects.Single(i=> i.Name == "Calculus").ProjectID },
                new Step {StepID=23, Name="The classic latin passage that just never gets old, enjoy as much (or as little) lorem ipsum as you can handle with our easy to use filler text generator.", Info="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                    ProjectID = projects.Single(i=> i.Name == "Calculus").ProjectID }


            };
            steps.ForEach(s => context.Steps.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var assignments = new List<Assignment>
            {
            new Assignment{EmployeeID=employees.Single(s => s.LastName == "Alexander").ID,
                ProjectID=projects.Single(c => c.Name == "Chemistry" ).ProjectID},
            new Assignment{EmployeeID=employees.Single(s => s.LastName == "Alexander").ID,
                ProjectID=projects.Single(c => c.Name == "Microeconomics" ).ProjectID},
            new Assignment{EmployeeID=employees.Single(s => s.LastName == "Alexander").ID,
                ProjectID=projects.Single(c => c.Name == "Macroeconomics" ).ProjectID},
            new Assignment{EmployeeID=employees.Single(s => s.LastName == "Alonso").ID,
                ProjectID=projects.Single(c => c.Name == "Calculus" ).ProjectID},
            new Assignment{EmployeeID=employees.Single(s => s.LastName == "Alonso").ID,
                ProjectID=projects.Single(c => c.Name == "Chemistry" ).ProjectID},
            new Assignment{EmployeeID=employees.Single(s => s.LastName == "Alonso").ID,
                ProjectID=projects.Single(c => c.Name == "Macroeconomics" ).ProjectID},
            new Assignment{EmployeeID=employees.Single(s => s.LastName == "Anand").ID,
                ProjectID=projects.Single(c => c.Name == "Microeconomics" ).ProjectID},
            new Assignment{EmployeeID=employees.Single(s => s.LastName == "Anand").ID,
                ProjectID=projects.Single(c => c.Name == "Calculus" ).ProjectID},
            new Assignment{EmployeeID=employees.Single(s => s.LastName == "Barzdukas").ID,
                ProjectID=projects.Single(c => c.Name == "Chemistry" ).ProjectID},
            new Assignment{EmployeeID=employees.Single(s => s.LastName == "Li").ID,
                ProjectID=projects.Single(c => c.Name == "Chemistry" ).ProjectID},
            new Assignment{EmployeeID=employees.Single(s => s.LastName == "Justice").ID,
                ProjectID=projects.Single(c => c.Name == "Calculus" ).ProjectID},
            new Assignment{EmployeeID=employees.Single(s => s.LastName == "Justice").ID,
                ProjectID=projects.Single(c => c.Name == "Microeconomics" ).ProjectID},
            };
            foreach (Assignment e in assignments)
            {
                var assignmentInDataBase = context.Assignments.Where(
                    s =>
                         s.Employee.ID == e.EmployeeID &&
                         s.Project.ProjectID == e.ProjectID).SingleOrDefault();
                if (assignmentInDataBase == null)
                {
                    context.Assignments.Add(e);
                }
            }
            context.SaveChanges();

        }
    }
}
