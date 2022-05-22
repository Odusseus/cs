using System.ComponentModel.DataAnnotations;

namespace pyli.Models
{
    public class AgeViewModel
    {
        public int Age { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Range(1, 31, ErrorMessage = "Value must be between 1 and 31")]
        public int Day { get; set; }

        [Range(1, 12, ErrorMessage = "Value must be between 1 and 12")]
        public int Mounth { get; set; }

        [Range(1800, 2100, ErrorMessage = "Value must be between 1800 and 2100")]
        public int Year { get; set; }

        public string? ErrorMessage { get; set; }


    }
}