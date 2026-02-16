using DTO;
using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
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
        public clsLicense License;
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
            License = clsLicense.Find(IssuedUsingLocalLicenseID);

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
            InternationalLicenseDTO internationalLicenses;
            internationalLicenses = InternationalLicensesData.GetInternationalLicenseByID(InternationalLicenseByID);
            if (internationalLicenses == null)
            {
                return null;
            }
            return new clsInternationalLicenses(internationalLicenses);
        }
        public static DataTable List()
        {
            return InternationalLicensesData.GetAllInternationalLicenses();
        }
        public  bool IssueInternatonalLicense()
        {
            clsApplication Application =new clsApplication();
            Application.ApplicationStatus = clsApplication.enApplicationStatus.New;
            Application.ApplicationTypeID = (int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicens;
            Application.ApplicantPersonlID = this.License.LDLApplication.ApplicantPersonlID;
            Application.ApplicationDate = DateTime.Now;
            Application.PaidFees = clsManageApplications.Find((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicens).Fees;
            Application.CreatedByUserID = CreatedByUserID;
            Application.ApplicationLastStatusDate = DateTime.Now;

            if (!Application.Save())
            {
                return false;
            }

            this.InternationalLicenseID = -1;

            InternationalLicenseDTO internationalLicenses=new InternationalLicenseDTO    
            {

              
               ApplicationID = Application.ApplicationID,
               DriverID = this.DriverID,
               IssuedUsingLocalLicenseID = this.IssuedUsingLocalLicenseID,
               IssueDate = this.IssueDate,
               ExpirationDate = this.ExpirationDate,
               IsActive = this.IsActive,
               CreatedByUserID = this.CreatedByUserID
            }
            ;
            this.InternationalLicenseID = InternationalLicensesData.AddNewInternationalLicense(internationalLicenses);

            return this.InternationalLicenseID != -1;
        }
    }
}
