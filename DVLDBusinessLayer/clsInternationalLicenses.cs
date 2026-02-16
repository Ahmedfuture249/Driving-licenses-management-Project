using DTO;
using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
   public class clsInternationalLicenses
    {
        public int InternationalLicenseID { get; set; }
        public int ApplicationID { get; set; }
        public clsApplication Application ;
        public int DriverID { get; set; }
        public clsDriver DriverInfo;
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }

        public clsInternationalLicenses(InternationalLicenseDTO InternationalLicense)
        {
            InternationalLicenseID = InternationalLicense.InternationalLicenseID;
            ApplicationID= InternationalLicense.ApplicationID;
            DriverID= InternationalLicense.DriverID;
            IssuedUsingLocalLicenseID = InternationalLicense.IssuedUsingLocalLicenseID;
            IssueDate = InternationalLicense.IssueDate;
            ExpirationDate = InternationalLicense.ExpirationDate;   
            IsActive = InternationalLicense.IsActive;   
            CreatedByUserID= InternationalLicense.CreatedByUserID;
            Application=clsApplication.FindBaseApplication(ApplicationID);  
            DriverInfo=clsDriver.Find(DriverID);    

        }
        public clsInternationalLicenses()
        {
            InternationalLicenseID = -1;
            ApplicationID = -1;
            DriverID =-1;
            IssuedUsingLocalLicenseID =-1;
            ExpirationDate = DateTime.Now;
            IsActive = false;
            CreatedByUserID = -1;
            

        }
        public static clsInternationalLicenses Find(int InternationalLicenseByID)
        {
            clsInternationalLicenses internationalLicenses;
            internationalLicenses = InternationalLicensesData.GetInternationalLicenseByID(InternationalLicenseByID);
        }
    }
}
