using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCRUD_Training.ViewModel
{
    public class AnswerViewModel
    {
        public int Id { get; set; }
        public string AccessID { get; set; }
        public string AnswerName { get; set; }
        public string AnswerValue { get; set; }
        public int FormTypeId { get; set; }
    }
}