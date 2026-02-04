using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
public class clsTestAppointment
    {
        public enum enMode { AddNew=0,Update=1};
        public enMode Mode = enMode.AddNew;
        public int TestAppointmentID { set; get; }
        public int TestTypeID { set; get; }
       public clsTestTypes TestType { set; get; }
        public int LocalDrivingLicenseApplicationID { set; get; }
       public clsLDLApplication LocalDrivingLicenseApplication { set; get; }
        public DateTime AppointmentDate { set; get; }
        public decimal PaidFees { set; get; }
        public int CreatedByUserID { set; get; }
       public bool IsLocked { set; get; }
        public int RetakeTestApplicationID { set; get; }

        clsTestAppointment(int TestAppointmentID,int TestTypeID,int LocalDrivingLicenseApplicationID
            ,DateTime AppointmentDate,decimal PaidFees,int CreatedByUserID,bool IsLocked,
            int RetakeTestApplicatonID)
        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.TestType = clsTestTypes.Find(TestTypeID);
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.LocalDrivingLicenseApplication = clsLDLApplication.FindLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID);
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
            this.RetakeTestApplicationID = RetakeTestApplicatonID;
            Mode = enMode.Update;
        }
        public clsTestAppointment()
        {
            this.TestAppointmentID = -1;
            this.TestTypeID = -1;
            this.LocalDrivingLicenseApplicationID = -1;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = -1;
            this.CreatedByUserID = -1;
            this.IsLocked = false;
            this.RetakeTestApplicationID = -1;
            Mode = enMode.AddNew;
        }
        public static clsTestAppointment Find(int TestAppointmentID)
        {
            
            int TestTypeID = -1;
            int LocalDrivingLicenseApplicationID = -1;
            DateTime AppointmentDate = DateTime.MinValue;
            decimal PaidFees = -1;
            int CreatedByUserID = -1;
            bool IsLocked = false;
            int RetakeTestApplicatonID = -1;
            if (TestAppointmentsData.GetTestAppointment(TestAppointmentID, ref TestTypeID, ref LocalDrivingLicenseApplicationID,
                ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicatonID))
            {
                return new clsTestAppointment(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate,
                    PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicatonID);
            }
            else
                return null;

        }
        public static DataTable ListTestAppointments(int LocalDrivingLicenseApplicationID,int TestTypeID)
        {
            return TestAppointmentsData.GetAllTestAppointments(LocalDrivingLicenseApplicationID,TestTypeID);
        }
        private  bool _AddNewTestAppointment()
        {
            this.TestAppointmentID = TestAppointmentsData.AddTestAppointment(this.TestTypeID, this.LocalDrivingLicenseApplicationID,
                this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked, this.RetakeTestApplicationID);
            return (this.TestAppointmentID != -1);
        }
        private bool _UpdateTestAppointmentDate()
        {
            return TestAppointmentsData.UpdateTestAppointmentDate(this.TestAppointmentID, this.AppointmentDate);
        }
        public static bool IsApplicantAlreadySatForThisTestAndPass(int LDLApplicationID, int TestTypeID)
        {
            return TestAppointmentsData.IsApplicantAlreadySatForThisTestAndPass(LDLApplicationID, TestTypeID);
        }
        public static bool Delete(int ID)
        {
            return TestAppointmentsData.DeleteTestAppointment(ID);
        }
        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestAppointment())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateTestAppointmentDate();
                default:
                    return false;

            }

        }
      public static bool  IsApplicantHasAnActiveAppointmentForThisTest(int LDLApplicationID,int TestTypeID)
        {
            return TestAppointmentsData.IsApplicantHasAnActiveAppointmentForThisTest(LDLApplicationID, TestTypeID);
        }



    }
}
