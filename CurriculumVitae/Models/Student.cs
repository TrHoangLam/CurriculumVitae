using Humanizer.Localisation;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using CurriculumVitae.Data;

namespace CurriculumVitae.Models
{
   
    public class Student
    {
        [Required]
        public string? Id { get; set; }
        [Required]
        public string? Name { get; set; }

        [DataType(DataType.Date)] //<= Using Data Anotations
        public DateTime DOB { get; set; }
        [Required]
        public string? POB { get; set; }
        [Required]
        public genre Genre { get; set; }
        [Required]
        public string? Ethnic { get; set; }
        [Required]
        public string? Religion { get; set; }
        [Required]
        public string? Class { get; set; }
        [Required]
        public string? TeacherName { get; set; }
        [Required]

        public string? FatherName { get; set; }
        [Required]

        public string? FatherJob { get; set; }
        [Required]

        public string? MotherName { get; set; }
        [Required]
        public string? MotherJob { get; set; }
        [Required]
        public string? Policy { get; set; }
        [Required]
        public long? PhoneNo { get; set; }
    }
}
public enum genre { MALE, FEMALE }
