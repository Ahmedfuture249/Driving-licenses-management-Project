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
 public    class clsDetainedLicenses
    {
        
            public int DetainID { get; set; } 
            public int LicenseID { get; set; }
           public clsLicense License { get; set; }
            public DateTime DetainDate { get; set; }
            public decimal FineFees { get; set; }
            public int CreatedByUserID { get; set; }
            
            public bool IsReleased { get; set; }
            public DateTime ReleaseDate { get; set; }
            public int ReleasedByUserID { get; set; }
            public int ReleaseApplicationID { get; set; }
           public clsApplication ReleaseApplication { get; set; }



        public clsDetainedLicenses()
        {
            DetainID = -1;   
            LicenseID = -1;
            ReleaseDate = DateTime.MaxValue;
            ReleasedByUserID = -1;
            ReleaseApplicationID = -1;
            CreatedByUserID = -1;   
            FineFees = 0;
            IsReleased = false;
            DetainDate = DateTime.MaxValue;
            

        }
        public clsDetainedLicenses(DetainLicenseDTO DetainedLicenese)
        {
            DetainID = DetainedLicenese.DetainID;
            LicenseID =DetainedLicenese.LicenseID;
            ReleaseDate = DetainedLicenese.ReleaseDate;
            ReleasedByUserID = DetainedLicenese.ReleasedByUserID;
            ReleaseApplicationID =DetainedLicenese.ReleaseApplicationID;
            CreatedByUserID = DetainedLicenese.CreatedByUserID;
            FineFees = DetainedLicenese.FineFees;
            IsReleased = DetainedLicenese.IsReleased;
            DetainDate = DetainedLicenese.DetainDate;
            ReleaseApplication = clsApplication.FindBaseApplication(ReleaseApplicationID);
            License=clsLicense.Find(LicenseID);

        }
        public static clsDetainedLicenses Find(int LicenseID)
        {
            DetainLicenseDTO DetainedLicense=DetainLicensesData.GetDetainByLicenseID(LicenseID);
           if(DetainedLicense==null)
            {
                return null;
                
            }
                return new clsDetainedLicenses(DetainedLicense);
            
        }
        public static DataTable ListDetainedLicenses()
        {
            return DetainLicensesData.GetAllDetainedLicenses();
        }
        public bool IsLicenseDetained()
        {
            return DetainLicensesData.IsLicenseDetained(this.LicenseID);

        }
        public static bool IsLicenseDetained(int LicenseID)
        {
            return DetainLicensesData.IsLicenseDetained(LicenseID);

        }
        public bool DetainLicense()
        {
            DetainLicenseDTO DetainedLicense = new DetainLicenseDTO
            {
                LicenseID = this.LicenseID,
               
                ReleaseDate = this.ReleaseDate,
                ReleasedByUserID = this.ReleasedByUserID,
                ReleaseApplicationID = this.ReleaseApplicationID,
                CreatedByUserID = this.CreatedByUserID,
                FineFees = this.FineFees,
                IsReleased = this.IsReleased,
                DetainDate = this.DetainDate

            };
            this.DetainID = -1;
            this.DetainID= DetainLicensesData.AddNewDetain(DetainedLicense);
            return (this.DetainID != -1);
        }

        public bool ReleaseLicense()
        {
            clsApplication Application = new clsApplication();
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
            this.ReleaseApplicationID = Application.ApplicationID;
            this.ReleaseDate = DateTime.Now;
            this.ReleasedByUserID = CreatedByUserID;
            this.IsReleased = true;
           
            return DetainLicensesData.ReleaseDetainedLicense(this.LicenseID,this.ReleaseDate,
                this.ReleasedByUserID,this.ReleaseApplicationID);

        }


    }
}
