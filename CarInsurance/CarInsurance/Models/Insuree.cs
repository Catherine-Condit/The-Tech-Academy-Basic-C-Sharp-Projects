using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;


namespace CarInsurance.Models
{
    public class Insuree
    {
        public required int Id { get; set; }

        [Display(Name = "First Name")]
        public required string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public required string LastName { get; set; }

        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public required string EmailAddress { get; set; }

        [Display(Name = "Date Of Birth")]
        [CustomValidation(typeof(Insuree), nameof(ValidateBirthDate))]
        public required DateTime DateOfBirth { get; set; }
        public static ValidationResult? ValidateBirthDate(DateTime dob, ValidationContext context)
        {
            int age = DateTime.Now.Year - dob.Year;

            if (dob > DateTime.Now)
            {
                return new ValidationResult("Date of birth cannot be in the future.");
            }
            if (age < 18)
            {
                return new ValidationResult("Insurees must be at least 18 years old.");
            }
            if (age > 110)
            {
                return new ValidationResult("Age exceeds realistic limits.");
            }

            return ValidationResult.Success;
        }

        [Display(Name = "Car Year")]
        [CustomValidation(typeof(Insuree), nameof(ValidateCarYear))]
        public required int CarYear { get; set; }

        public static ValidationResult? ValidateCarYear(int year, ValidationContext context)
        {
            int currentYear = DateTime.Now.Year;

            if (year < 1886 || year > currentYear)
            {
                return new ValidationResult($"Car Year must be between 1886 and {currentYear}.");
            }

            return ValidationResult.Success;
        }


        [Display(Name = "Car Make")]
        public required string CarMake { get; set; }

        [Display(Name = "Car Model")]
        public required string CarModel { get; set; }

        [Display(Name = "Has DUI?")]
        public required bool HasDui { get; set; }

        [Range(0, 100, ErrorMessage = "Speeding Tickets must be 0 or more")]
        [Display(Name = "Speeding Tickets")]
        public required int SpeedingTickets { get; set; }

        [Display(Name = "Full Coverage?")]
        public required bool FullCoverage { get; set; } // true = full, false = liability

        [Precision(18, 2)]
        public decimal Quote { get; set; }
    }
}
