using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
   public class clsTestTypes
    {
        public int TestID { set; get; }
        public string TestTitle { set; get; }
        public decimal Fees { set; get; }
        public string TestDesctription { set; get; }


        clsTestTypes(int testID, string testTitle, decimal fees, string testDesctription)
        {
            TestID = testID;
            TestTitle = testTitle;
            Fees = fees;
            TestDesctription = testDesctription;
        }
        public static clsTestTypes Find(int ID)
        {
            string TestTitle = "";
           decimal Fees = 0;
           string  TestDesctription = "";
            if (TestTypesData.GetTestTypeByID(ID, ref TestTitle, ref TestDesctription, ref Fees))
                return new clsTestTypes(ID, TestTitle, Fees, TestDesctription);
            else
                return null;
          
        }
        public bool UpdatTestType()
        {
            return TestTypesData.UpdateTestTypes(this.TestID, this.TestDesctription, this.TestTitle, this.Fees);
        }
        public static DataTable ListTestTypes()
        {
            return TestTypesData.GetAllTestTypes();
        }
    }
}
