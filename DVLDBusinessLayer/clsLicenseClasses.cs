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
        public int DefaultValdityLength { set; get; }

        clsLicenseClasses(int LicenseClassID, string ClassName, string ClassDescription, int MinimumAllowedAge, decimal ClassFees,int DefaultValdityLength)
        {
            this.LicenseClassID = LicenseClassID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.ClassFees = ClassFees;
            this.DefaultValdityLength = DefaultValdityLength;
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
			int DefaultValdityLength = 0;

			if (LicenseClassesData.GetLicensClassByLicensClassName(ref LicenseClassID, ClassName, ref ClassDescription, ref MinimumAllowedAge, ref ClassFees,ref DefaultValdityLength))
            {
                return new clsLicenseClasses(LicenseClassID, ClassName, ClassDescription, MinimumAllowedAge, ClassFees, DefaultValdityLength);
            }
            else
                return null;

        }
		public static clsLicenseClasses Find(int id)
		{
			string LicenseClassName = "";
			string ClassDescription = "";
			decimal ClassFees = 0;
            int DefaultValdityLength = 0;
			int MinimumAllowedAge = 0;
			if (LicenseClassesData.GetLicensClassByLicensClassID(id,ref LicenseClassName, ref ClassDescription, ref MinimumAllowedAge, ref ClassFees,ref DefaultValdityLength))
			{
				return new clsLicenseClasses(id, LicenseClassName, ClassDescription, MinimumAllowedAge, ClassFees, DefaultValdityLength);
			}
			else
				return null;

		}
	}
}
