using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static DVLDBusinessLayer.clsApplication;
using static System.Net.Mime.MediaTypeNames;

namespace DVLDBusinessLayer
{
    public class clsLDLApplication :clsApplication
    {
        public enum enMode {AddNew=0,Update=1}
        public enMode Mode = enMode.AddNew;
        public int LocalDrivingLicensApplicationID { set; get; }
        public int LicenseClass { set; get; }
       public clsLicenseClasses LicenseClassInfo { set; get; }

		public string FullName
        {
            get { return base.personInfo.FullName; }
        }

        clsLDLApplication(int localDrivingLicensApplicationID, int applicationID, int licenseClass ,int applicantPersonlID,DateTime applicationDate,enApplicationType applicationTypeID,enApplicationStatus applicationStatus
            , DateTime applicationLastStatusDate, decimal paidFees ,int createdByUserID)
        {
            LocalDrivingLicensApplicationID = localDrivingLicensApplicationID;
            ApplicationID = applicationID;
            LicenseClass = licenseClass;
           LicenseClassInfo= clsLicenseClasses.Find(licenseClass);
            
            ApplicantPersonlID = applicantPersonlID;
            ApplicationDate = applicationDate;
            ApplicationTypeID = (int)applicationTypeID;
            ApplicationTypeInfo = clsManageApplications.Find(ApplicationTypeID);
            ApplicationStatus = applicationStatus;
            ApplicationLastStatusDate = applicationLastStatusDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
            CreatedByUserInfo = clsUsers.Find(CreatedByUserID);
            personInfo = clsPeople.Find(ApplicantPersonlID);
            Mode = enMode.Update;
        }
        public  clsLDLApplication()
        {
            LocalDrivingLicensApplicationID = -1;
            LicenseClass = -1;
            Mode = enMode.AddNew;
        }
        public static clsLDLApplication FindLocalDrivingLicenseApplication(int ID)
        {
            int ApplicationID = -1;
            int LicenseClass = -1;
            bool IsFound = false;
              IsFound = LDLApplicationsData.GetLDLApplicationsByID(ID, ref ApplicationID, ref LicenseClass);

            if (IsFound)
            {
                clsApplication Application = clsApplication.FindBaseApplication(ApplicationID);

                return new clsLDLApplication(ID, ApplicationID, LicenseClass, Application.ApplicantPersonlID,
                    Application.ApplicationDate,(enApplicationType) Application.ApplicationTypeID, Application.ApplicationStatus
                    , Application.ApplicationLastStatusDate, Application.PaidFees, Application.CreatedByUserID);
            }
            else
                return null;
        }
        private bool _AddNewLocalDrivingLicenseApplicaion()
        {
            this.LocalDrivingLicensApplicationID = LDLApplicationsData.AddNewLocalDrivingLicenseApplication(this.ApplicationID, this.LicenseClass);
            return this.LocalDrivingLicensApplicationID != -1;
        }
        private bool _UpdateLocalDrivingLicenseApplicaion()
        {
            return LDLApplicationsData.UpdateLocalDrivingLicenseApplicatioN(this.LocalDrivingLicensApplicationID, this.ApplicationID, this.LicenseClass);
         
        }
        public static bool DeleteLocalDrivingLicenseApplication(int ID)
        {
            return LDLApplicationsData.DeleteLocalDrivingLicenseApplication(ID);
        }

        public bool Save()
        {
            base.Mode= (clsApplication.enMode)Mode;
            if (!base.Save())
                return false;

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLocalDrivingLicenseApplicaion())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateLocalDrivingLicenseApplicaion();

            }
            return false;
        }
        public static DataTable ListApplications()
        {
            return LDLApplicationsData.GetAllTestLDLApplications();
        }
    }
    
}
