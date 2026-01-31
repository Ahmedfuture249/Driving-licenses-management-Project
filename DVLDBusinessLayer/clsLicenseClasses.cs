using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
    public class clsLicenseClasses
    {
        public int LicenseClassID { set; get; }
        public string ClassName { set; get; }
        public string ClassDescription { set; get; }
        public decimal ClassFees { set; get; }
        public int MinimumAllowedAge { set; get; }

        clsLicenseClasses(int LicenseClassID, string ClassName, string ClassDescription, int MinimumAllowedAge, decimal ClassFees)
        {
            this.LicenseClassID = LicenseClassID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.ClassFees = ClassFees;
        }
        public static DataTable ListLicenseClasses()
        {
            return LicenseClassesData.GetAllLicenseClasses();
        }

        public static clsLicenseClasses Find(string ClassName)
        {
            int LicenseClassID = -1;
            string ClassDescription = "";
            decimal ClassFees = 0;
            int MinimumAllowedAge = 0;
            if (LicenseClassesData.GetUserByLicensClassName(ref LicenseClassID, ClassName, ref ClassDescription, ref MinimumAllowedAge, ref ClassFees))
            {
                return new clsLicenseClasses(LicenseClassID, ClassName, ClassDescription, MinimumAllowedAge, ClassFees);
            }
            else
                return null;

        }
    }
}
