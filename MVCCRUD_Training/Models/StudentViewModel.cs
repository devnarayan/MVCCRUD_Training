using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCRUD_Training.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RollName { get; set; }
    }

    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RollName { get; set; }
    }
}