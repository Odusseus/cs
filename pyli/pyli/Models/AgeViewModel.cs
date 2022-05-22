using System.ComponentModel.DataAnnotations;

namespace pyli.Models
{
    public class AgeViewModel
    {
        public int Age { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "1/1/1800", "1/1/2100")]
        public DateTime DateOfBirth { get; set; }

        [Range(1, 31)]
        public int Day { get; set; }

        [Range(1, 12)]
        public int Mounth { get; set; }

        [Range(1800, 2100)]
        public int Year { get; set; }

        public string ErrorMessage { get; set; }


    }
}