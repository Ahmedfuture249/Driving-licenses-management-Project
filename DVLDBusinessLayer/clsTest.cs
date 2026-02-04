using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
    public class clsTest
    {
        public int TestID { set; get; }
        public int TestAppointmentID { set; get; }
        public clsTestAppointment TestAppointment;
        public bool TestResult { set; get; }
        public string Notes { set; get; }
        public int CreatedByUserID { set; get; }
        clsUsers CreatedByUserInfo;

        public clsTest(int testID, int testAppointmentID,  bool testResult, string notes, int createdByUserID)
        {
            TestID = testID;
            TestAppointmentID = testAppointmentID;
            TestAppointment =clsTestAppointment.Find(TestAppointmentID);
            TestResult = testResult;
            Notes = notes;
            CreatedByUserID = createdByUserID;
            CreatedByUserInfo = clsUsers.Find(CreatedByUserID);
        }

        public clsTest()
        {
            TestID =-1;
            TestAppointmentID = -1;
            
            TestResult = false;
            Notes = "";
            CreatedByUserID = -1;
            
        }
        private bool _TakeTest()
        {
            this.TestID = TestsData.TakeTest(this.TestAppointmentID, TestResult, Notes, CreatedByUserID);
            return this.TestID != -1;
        }
        public bool TakeTest()
        {
            return _TakeTest();
        }

    }
}
