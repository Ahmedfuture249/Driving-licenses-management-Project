using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
   public class clsApplication
    {
       public int ApplicationID { set; get; }
        public int ApplicantPersonlID { set; get; }
        public DateTime ApplicationDate { set; get; }
        public int ApplicationTypeID { set; get; }
        public int ApplicationStatus { set; get; }
        public DateTime ApplicationLastStatusDate { set; get; }
        public decimal PaidFees { set; get; }
        int CreatedByUserID { set; get; }
    }
   
   
}
