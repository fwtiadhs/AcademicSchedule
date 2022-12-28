using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicSchedule.logic
{
    public class CEleni
    {
        public int Id { get; set; }   //id from the base

        public string Code { get; set; }  //code of lesson

        public string Lesson { get; set; }  //name of lesson

        public string CSSClassE
        {
            get
            {
                string sResult = "text-success";
                return sResult;
            }
        }
    }
}
