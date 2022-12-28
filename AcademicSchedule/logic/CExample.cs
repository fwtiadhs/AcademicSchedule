using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicSchedule.logic
{
    public class CExample
    {
        // ....................................................................
        public string Code { get; set; }
        // ....................................................................
        public string Description { get; set; }
        // ....................................................................

        public DateTime EntryTime { get; set; }
        // ....................................................................

        public double  Amount { get; set; }
        // ....................................................................
        public int ValueInteger { get; set; }
        // ....................................................................

        public bool IsActive { get; set; }
        // ....................................................................

        public string CSSClass
        { 
            get
            {
                // [PANTELIS]: We can implement some logic here, like the decision 

                string sResult = String.Empty;

                if (!this.IsActive)
                    sResult = "text-muted";
                else
                { 
                    if (ValueInteger >= 1000)
                        sResult = "text-success";
                }
                return sResult;
            }
        }
        // ....................................................................
    }

}
