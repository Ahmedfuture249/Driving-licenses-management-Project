using DTO;
using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public clsApplication LDLApplication { get; set; }

        public int DriverID { get; set; }
        public int LicenseClassID { get; set; }
        public clsLicenseClasses LicenseClassInfo { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public enIssueReason IssueReason { get; set; }
        public int IssueReasonID { get; set; }
        public int CreatedByUserID { get; set; }

        public clsLicense(int licenseID, int applicationID, int driverID, int licenseClassID, DateTime issueDate, DateTime expirationDate, string notes, decimal paidFees, bool isActive, enIssueReason issueReason, int createdByUserID)
        {
            LicenseID = licenseID;
            ApplicationID = applicationID;
            LDLApplication = clsLDLApplication.FindLocalDrivingLicenseApplication(ApplicationID); 
            DriverID = driverID;
            LicenseClassID = licenseClassID;
            LicenseClassInfo = clsLicenseClasses.Find(LicenseClassID);
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            Notes = notes;
            PaidFees = paidFees;
            IsActive = isActive;
            IssueReason = issueReason;
            CreatedByUserID = createdByUserID;
            Mode=enMode.Update;
            
        }
        public clsLicense(LicenseDTO license)
        {
            LicenseID = license.LicenseID;
            ApplicationID = license.ApplicationID;
            LDLApplication = clsApplication.FindBaseApplication(ApplicationID);
            DriverID = license.DriverID;
            LicenseClassID = license.LicenseClassID;
            LicenseClassInfo = clsLicenseClasses.Find(LicenseClassID);
            IssueDate = license.IssueDate;
            ExpirationDate = license.ExpirationDate;
            Notes = license.Notes;
            PaidFees = license.PaidFees;
            IsActive = license.IsActive;
            IssueReason = (enIssueReason)license.IssueReason;
            CreatedByUserID = license.CreatedByUserID;
            Mode = enMode.Update;

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
        public static clsLicense Find(int LicenseID)
        {
            LicenseDTO license= LicenseData.GetLicenseByID(LicenseID);
            return new clsLicense(license);

        }
        public static clsLicense FindByApplicationID(int ApplicationID)
        {
            LicenseDTO license = LicenseData.GetLicenseByApplicationID(ApplicationID);
            return new clsLicense(license);

        }
        public static DataTable ListLicenses()
        {
            return LicenseData.GetAllLicenses();
        }
        private bool _AddNewLicense()
        {
          
            LicenseDTO license = new LicenseDTO
            {
                ApplicationID = this.ApplicationID,
                DriverID = this.DriverID,
                LicenseClassID = this.LicenseClassID,
                IssueDate = this.IssueDate,
                ExpirationDate = this.ExpirationDate,
                Notes = this.Notes,
                PaidFees = this.PaidFees,
                IsActive = this.IsActive,
                IssueReason = (int)this.IssueReason,
                CreatedByUserID = this.CreatedByUserID
            };

            this.LicenseID = -1;
            
            this.LicenseID = LicenseData.AddNewLicense(license);

            return this.DriverID != -1;
        }
        public static bool DeleteLicense(int ID)
        {
            return LicenseData.DeleteLicense(ID);
        }
        private bool _UpdateLicense()
        {
            LicenseDTO license = new LicenseDTO
            {
                LicenseID = this.LicenseID,
                ApplicationID = this.ApplicationID,
                DriverID = this.DriverID,
                LicenseClassID = this.LicenseClassID,
                IssueDate = this.IssueDate,
                ExpirationDate = this.ExpirationDate,
                Notes = this.Notes,
                PaidFees = this.PaidFees,
                IsActive = this.IsActive,
                IssueReason = (int)this.IssueReason,
                CreatedByUserID = this.CreatedByUserID
            };
            return LicenseData.UpdateLicense(license);
        }
        public int RenewLicense(string Notes, int CreatedByUserID)
        {
            
           clsApplication Application= new clsApplication();
           Application.ApplicationStatus = clsApplication.enApplicationStatus.New;
            Application.ApplicationTypeID = (int)clsApplication.enApplicationType.RenewDrivingLicense;
            Application.ApplicantPersonlID = this.LDLApplication.ApplicantPersonlID;
            Application.ApplicationDate = DateTime.Now;
            Application.PaidFees = clsManageApplications.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).Fees;
            Application.CreatedByUserID = CreatedByUserID;
            Application.ApplicationLastStatusDate = DateTime.Now;   
            if(!Application.Save())
            {
                return -1;
            }

            clsLicense NewLicense = new clsLicense();
            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClassID = this.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.LicenseClassInfo = clsLicenseClasses.Find(NewLicense.LicenseClassID);
            NewLicense.ExpirationDate = DateTime.Now.AddYears(LicenseClassInfo.DefaultValdityLength);
            NewLicense.Notes = Notes;
            NewLicense.PaidFees = this.LicenseClassInfo.ClassFees;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = clsLicense.enIssueReason.Renew;
            NewLicense.CreatedByUserID = CreatedByUserID;

            if (NewLicense.Save())
            {
                //now we should set the application status to complete.
                Application.SetCompleted();

                return NewLicense.LicenseID;
            }

            else
                return -1;
        }
        public int ReplaceForDamgedOrLost(clsApplication.enApplicationType enApplicationType)
        {

            clsApplication Application = new clsApplication();
            Application.ApplicationStatus = clsApplication.enApplicationStatus.New;

            if (enApplicationType == clsApplication.enApplicationType.ReplaceDamgedDrivingLicense)

            {
                Application.ApplicationTypeID = (int)clsApplication.enApplicationType.ReplaceDamgedDrivingLicense;
                Application.PaidFees = clsManageApplications.Find((int)clsApplication.enApplicationType.ReplaceDamgedDrivingLicense).Fees;
            }
            if (enApplicationType == clsApplication.enApplicationType.ReplacedLostDrivingLicense)

            {
                Application.ApplicationTypeID = (int)clsApplication.enApplicationType.ReplacedLostDrivingLicense;
                Application.PaidFees = clsManageApplications.Find((int)clsApplication.enApplicationType.ReplacedLostDrivingLicense).Fees;
            }


            Application.ApplicantPersonlID = this.LDLApplication.ApplicantPersonlID;
            Application.ApplicationDate = DateTime.Now;
          
            Application.CreatedByUserID = CreatedByUserID;
            Application.ApplicationLastStatusDate = DateTime.Now;
            if (!Application.Save())
            {
                return -1;
            }

            clsLicense ReplacementLicense = new clsLicense();
            ReplacementLicense.ApplicationID = Application.ApplicationID;
            ReplacementLicense.DriverID = this.DriverID;
            ReplacementLicense.LicenseClassID = this.LicenseClassID;
            ReplacementLicense.IssueDate = DateTime.Now;
            ReplacementLicense.LicenseClassInfo = clsLicenseClasses.Find(ReplacementLicense.LicenseClassID);
            ReplacementLicense.ExpirationDate = DateTime.Now.AddYears(LicenseClassInfo.DefaultValdityLength);
            ReplacementLicense.Notes = Notes;
            ReplacementLicense.PaidFees = this.LicenseClassInfo.ClassFees;
            ReplacementLicense.IsActive = true;
            if (enApplicationType == clsApplication.enApplicationType.ReplacedLostDrivingLicense)

            {
                ReplacementLicense.IssueReason = clsLicense.enIssueReason.ReplacementforLost;
            }
            if (enApplicationType == clsApplication.enApplicationType.ReplaceDamgedDrivingLicense)

            {
                ReplacementLicense.IssueReason = clsLicense.enIssueReason.ReplacementforDamaged;
            }
            ReplacementLicense.CreatedByUserID =ClsGloabalSettings.CurrentUser.UserID;

            if (ReplacementLicense.Save())
            {
                //now we should set the application status to complete.
                Application.SetCompleted();

                return ReplacementLicense.LicenseID;
            }

            else
                return -1;
        }
        public bool IsLicenseExpired()
        {
            return LicenseData.IsLicenseExpired(this.LicenseID);
        }
        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicense())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateLicense();
                default:
                    return false;

            }

        }

    }
}
