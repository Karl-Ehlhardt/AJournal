using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJournalModel.Entries.Book
{
    public class BookEdit
    {
        [Required]
        [Display(Name = "Book Name")]
        public string BookName { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public int Rating { get; set; }//Dropdown HERDCODE VALUES  https://www.tutorialsteacher.com/mvc/htmlhelper-dropdownlist-dropdownlistfor

        [Required]
        [Display(Name = "Number of Times Read")]
        public int NumberOfTimesRead { get; set; }//Can be incrimented by 1

        [Required]
        [Display(Name = "Last Time Read")]
        public DateTime LastTimeRead { get; set; }

        [Required]
        [Display(Name = "Personal Summary")]
        public string PersonalSummary { get; set; }

    }
}
