using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
    public class clsDriver
    {
        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDateCreatedDate { get; set; }
        public clsPeople Person { get; set; }
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode=enMode.AddNew;


        public clsDriver(int DriverID,int PersonID,int CreatedByUserID,DateTime CreateTime)
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.CreatedDateCreatedDate = CreateTime;
            this.CreatedByUserID = CreatedByUserID;
            this.Person = clsPeople.Find(PersonID);
        }
        public clsDriver() 
        {
            this.DriverID = -1;
            this.PersonID = -1;
            this.CreatedDateCreatedDate = DateTime.Now;
            this.CreatedByUserID = -1;  
        }
        public static clsDriver Find(int DriverID)
        {
            
            int PersonID = -1;
            int CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;
            if(DriversData.GetDriver(DriverID,ref PersonID,ref CreatedByUserID,ref CreatedDate))
                return new clsDriver(DriverID,PersonID,CreatedByUserID,CreatedDate);
            else
                return null;

        }
        public static DataTable ListDrivers()
        {
            return DriversData.GetAllDrivers();
        }
        private bool _AddNewDrver()
        {
            this.DriverID = -1;
            this.DriverID = DriversData.AddNewDriver(this.PersonID, this.CreatedByUserID, this.CreatedDateCreatedDate);
            return this.DriverID != -1;
        }
        public static bool DeleteDriver(int ID)
        {
            return DriversData.DeleteDriver(ID);
        }
        private bool _UpdateDriver()
        {
            return DriversData.UpdateDriver(this.DriverID, this.PersonID, this.CreatedByUserID);
        }
        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDrver())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateDriver();
                default:
                    return false;

            }

        }


    }
}
