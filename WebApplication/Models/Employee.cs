using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public enum Location
    {
        Warszawa, Kraków, Wrocław
    }
    public enum Contract
    {
        UoP, B2B, UZ
    }
    public class Employee
    {
       public Employee()
        {
            this.Projects = new HashSet<Project>();
        }
        public int ID { get; set; }
        [Required(ErrorMessage = "Pole wymagane")]
        [DisplayName("Imię")]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Pole wymagane")]
        [DisplayName("Nazwisko")]
        [StringLength(20)]
        public string LastName { get; set; }
        [DisplayName("Lokalizacja")]
        public Location Location { get; set; }
        [DisplayName("Umowa")]
        public Contract Contract { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}