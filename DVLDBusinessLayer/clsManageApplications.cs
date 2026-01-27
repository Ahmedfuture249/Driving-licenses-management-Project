using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
   public class clsManageApplications
    {
       public int  ID { get; }
        public decimal Fees {set; get; }
        public string Title { set; get; }


        clsManageApplications(int iD, decimal fees, string title)
        {
            ID = iD;
            Fees = fees;
            Title = title;
        }
        public static clsManageApplications Find(int ID)
        {
            string Title = "";
            decimal Fees = 0;
            if (ManageApplicationsTypesData.GetCountryApplicationTypeByID(ID, ref Title, ref Fees))
            {
                return new clsManageApplications(ID, Fees, Title);

            }
            else
                return null;
        }
        public static DataTable ListApplicationTypes()
        {
            return ManageApplicationsTypesData.GetAllApplicationsTypes();
        }

        public bool UpdateApplicationType()
        {
            return ManageApplicationsTypesData.UpdateApplicationType( this.ID,this.Title,this.Fees);
        }
    }
    
}
