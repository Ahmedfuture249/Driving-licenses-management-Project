using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLDBusinessLayer
{
    public class clsApplication
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };
        public enum enApplicationType
        {
            NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplacedLostDrivingLicense = 3
        , ReplaceDamgedDrivingLicense = 4, ReleaseDetainedDrivingLicens = 5, NewInternationalLicens = 6,
            RetakeTest = 7
        };
        public enMode Mode = enMode.AddNew;
        public int ApplicationID { set; get; }
        public int ApplicantPersonlID { set; get; }
        public DateTime ApplicationDate { set; get; }
        public int ApplicationTypeID { set; get; }
        public enApplicationStatus ApplicationStatus { set; get; }
        public string StatusText()
        {
            switch (ApplicationStatus)
            {
                case enApplicationStatus.New:
                    return "New";

                case enApplicationStatus.Cancelled:
                    return "Cancelled";

                case enApplicationStatus.Completed:
                    return "Completed";

                default:
                    return "Unknown";
            }
        }

        public clsManageApplications ApplicationTypeInfo;

        public clsUsers CreatedByUserInfo;
        public DateTime ApplicationLastStatusDate { set; get; }
        public decimal PaidFees { set; get; }
        public int CreatedByUserID { set; get; }
        public clsPeople personInfo;

       public clsApplication(int applicationID, int applicantPersonlID, DateTime applicationDate, int applicationTypeID, enApplicationStatus applicationStatus, DateTime applicationLastStatusDate, decimal paidFees, int createdByUserID)
        {
            ApplicationID = applicationID;
            ApplicantPersonlID = applicantPersonlID;
            ApplicationDate = applicationDate;
            ApplicationTypeID = applicationTypeID;
            ApplicationTypeInfo = clsManageApplications.Find(ApplicationTypeID);
            ApplicationStatus = applicationStatus;
            ApplicationLastStatusDate = applicationLastStatusDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
            CreatedByUserInfo = clsUsers.Find(CreatedByUserID);
            personInfo = clsPeople.Find(ApplicantPersonlID);
            Mode = enMode.Update;
        }
        public clsApplication()
        {
            ApplicationID = -1;
            ApplicantPersonlID = -1;
            ApplicationDate = DateTime.Now;
            ApplicationTypeID = -1;

            ApplicationStatus = enApplicationStatus.New;
            ApplicationLastStatusDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;

        }

        public static clsApplication FindBaseApplication(int ID)
        {
            byte status = 0;

            int ApplicantPersonlID = -1;
            DateTime ApplicationDate = DateTime.Now;
            int ApplicationTypeID = -1;

            enApplicationStatus ApplicationStatus = (enApplicationStatus)status;
            DateTime ApplicationLastStatusDate = DateTime.Now;
            decimal PaidFees = 0;
            int CreatedByUserID = -1;
            if (ApplicationsData.GetApplication(ID, ref ApplicantPersonlID, ref ApplicationDate, ref ApplicationTypeID,
                ref status, ref ApplicationLastStatusDate, ref PaidFees, ref CreatedByUserID))
            {
                return new clsApplication(ID, ApplicantPersonlID, ApplicationDate, ApplicationTypeID
                    , ApplicationStatus, ApplicationLastStatusDate, PaidFees, CreatedByUserID);

            }
            else
                return null;

        }
        private bool _AddNewApplication()
        {
            this.ApplicationID = ApplicationsData.AddNewApplication(this.ApplicantPersonlID, this.ApplicationDate, this.ApplicationTypeID
                     , (byte)this.ApplicationStatus, this.ApplicationLastStatusDate, this.PaidFees, this.CreatedByUserID);
            return this.ApplicationID != -1;
        }
        private bool _UpdateApplication()
        {
            return ApplicationsData.UpdateApplicaton(this.ApplicationID, this.ApplicantPersonlID, this.ApplicationDate, this.ApplicationTypeID
                    , (byte)this.ApplicationStatus, this.ApplicationLastStatusDate, this.PaidFees, this.CreatedByUserID);
        }

        public static int GetActiveApplicationForLicenseClass(int personID,enApplicationType ApplicAtionTypeID,int LicenseClassID)
        {
            int ActiveApplicationID = -1;
            ActiveApplicationID= ApplicationsData.GetActiveApplicationIDForLicenseClass(personID, (int)ApplicAtionTypeID, LicenseClassID);
            return ActiveApplicationID;
        }
        public bool Cancel()
        {
            return ApplicationsData.UpdateStatus(this.ApplicationID, 2);
        }

        public bool SetCompleted()
        {
            return ApplicationsData.UpdateStatus(this.ApplicationID, 3);
        }
        public static bool DeleteApplication(int ID)
        {
            return ApplicationsData.DeleteApplication(ID);
        }
        public static bool IsApplicationExist(int ID)
        {
            return ApplicationsData.IsApplicationExist(ID);
        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplication())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateApplication();
                default:
                    return false;

            }

        }



    }
}
