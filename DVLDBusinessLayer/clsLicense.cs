using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLDBusinessLayer.clsLicense;
using static System.Net.Mime.MediaTypeNames;

namespace DVLDBusinessLayer
{
     public  class clsLicense
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode =enMode.AddNew;  
        public enum enIssueReason { FirstTime=1, Renew=2, ReplacementforDamaged=3,  ReplacementforLost=4 };
        public int LicenseID {  get; set; }
        public int ApplicationID { get; set; }
        public clsLDLApplication LDLApplication { get; set; }
        public int DriverID { get; set; }
        public int LicenseClassID { get; set; }
        public clsLicenseClasses LicenseClassInfo { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public enIssueReason IssueReason { get; set; }
        public int CreatedByUserID { get; set; }

        public clsLicense(int licenseID, int applicationID, clsLDLApplication lDLApplication, int driverID, int licenseClassID, clsLicenseClasses licenseClassInfo, DateTime issueDate, DateTime expirationDate, string notes, decimal paidFees, bool isActive, enIssueReason issueReason, int createdByUserID)
        {
            LicenseID = licenseID;
            ApplicationID = applicationID;
            LDLApplication = clsLDLApplication.FindLocalDrivingLicenseApplication(ApplicationID); 
            DriverID = driverID;
            LicenseClassID = licenseClassID;
            LicenseClassInfo = clsLicenseClasses.Find(licenseID);
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            Notes = notes;
            PaidFees = paidFees;
            IsActive = isActive;
            IssueReason = issueReason;
            CreatedByUserID = createdByUserID;
            Mode=enMode.Update;
            
        }
        public clsLicense() 
        {
            LicenseID = -1;
            ApplicationID = -1;
           
            DriverID = -1;
            LicenseClassID = -1;
            
            IssueDate = DateTime.Now;
            ExpirationDate =DateTime.Now;
            Notes = "";
            PaidFees = 0;
            IsActive = false;
            IssueReason = 0;
            CreatedByUserID = -1;
            Mode = enMode.AddNew;
        }

    }
}
