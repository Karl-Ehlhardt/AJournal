using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJournalModel.Entries.Book
{
    public class BookDetails
    {
        [Display(Name = "Book Name")]
        public string BookName { get; set; }

        public string Author { get; set; }

        public int Rating { get; set; }

        [Display(Name = "Number of Times Read")]
        public int NumberOfTimesRead { get; set; }

        [Display(Name = "Last Time Read")]
        public DateTime LastTimeRead { get; set; }

        [Display(Name = "Personal Summary")]
        public string PersonalSummary { get; set; }

    }
}
