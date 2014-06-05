using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReadPHPWebService
{
    public class ContactResult
    {
        public int UserID { get; set; }

        public string FinalGrade { get; set; }

        public string CourseCode { get; set; }

        public int UniqueID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ResultType { get; set; }

        public DateTime TimeFinish { get; set; }
    }
}
