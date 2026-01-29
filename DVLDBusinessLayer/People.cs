using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
    public class clsPeople
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int    PersonID                           { set; get; }
        public string FirstName                            { set; get; }
        public string SecondName                     { set; get; }
        public string ThirdName                     { set; get; }
        public string LastName { set; get; }
        public int    NationalityCountryID  { set; get; }
        public string NationalNo            { set; get; }
        public int     Gendor                 { set; get; }
        public string Email                 { set; get; }
        public string Phone                    { set; get; }
        public string Address                  { set; get; }
      public DateTime DateOfBirth              { set; get; }
          
        private string _ImagePath ;
        public string FullName { get { return FirstName + " " + SecondName + " " + ThirdName + " " + LastName; } }
        public string ImagePath
        {
            get { return _ImagePath; }
            set { _ImagePath = value; }
        }

        public clsCountries CountryInfo;

        public clsPeople()

        {
            this.PersonID = -1;
            this.FirstName = "";
            this.LastName = "";
            this.ThirdName = "";
            this.NationalNo = "";
            this.NationalityCountryID = -1;
            this.Gendor = -1;
            this.Email = "";
            this.Phone = "";
            this.Address = "";
            this.DateOfBirth = DateTime.Now;
            this.CountryInfo = new clsCountries();
            this.ImagePath = "";
            this.SecondName = "";

            Mode = enMode.AddNew;

        }

        private clsPeople(int ID, string FirstName, string SecondName,string ThirdName,
            int NationalityCountryID, string NationalNo ,int Gendor,
        string Email, string Phone, string Address, DateTime DateOfBirth,
            string ImagePath,string LastName)

        {
            this.PersonID = ID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            this.DateOfBirth = DateOfBirth;
           // this.CountryInfo =CountryInfo ;
            this.ImagePath = ImagePath;
            this.NationalityCountryID = NationalityCountryID;
            this.NationalNo = NationalNo;
            this.Gendor = Gendor;
            this.ThirdName = ThirdName;
            this.SecondName = SecondName;

            Mode = enMode.Update;

        }

        private bool _AddNewPerson()
        {
            //call DataAccess Layer 

            this.PersonID = PeopleDataAccess.AddNewPerson(this.FirstName,this.SecondName,this.ThirdName ,this.NationalityCountryID
              ,this.NationalNo,this.Gendor,   this.Email, this.Phone,
                this.Address, this.DateOfBirth, this.ImagePath, this.LastName);

            return (this.PersonID != -1);
        }

        private bool _UpdatePerson()
        {
            //call DataAccess Layer 

            return PeopleDataAccess.UpdatePerson(this.PersonID, this.FirstName, this.SecondName, this.ThirdName, this.NationalityCountryID
              , this.NationalNo, this.Gendor, this.Email, this.Phone,
                this.Address, this.DateOfBirth,  this.ImagePath, this.LastName);

        }

        public static clsPeople Find(int ID)
        {

            string FirstName = "", SecondName = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int CountryID = -1;
            string ThirdName = "";
            string NationalNo = "";
            int Gendor = 0;
            int NationalityCountryID = 0;
            string LastName = "";

            if (PeopleDataAccess.GetPerson(ID, ref FirstName, ref SecondName, ref ThirdName, ref NationalityCountryID
                , ref NationalNo,
                          ref Email, ref Address, ref Gendor, ref CountryID, ref ImagePath, ref DateOfBirth,
                          ref Phone,ref LastName))
            {
                return new clsPeople(ID, FirstName, SecondName, ThirdName,
             NationalityCountryID, NationalNo, Gendor,
         Email, Phone, Address, DateOfBirth,
             ImagePath,LastName);
            }

            else
                return null;
        }
        public static clsPeople Find(string NationalNo)
        {

            string FirstName = "", SecondName = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int CountryID = -1;
            string ThirdName = "";
            //string NationalNo = "";
            int Gendor = 0;
            int NationalityCountryID = 0;
            string LastName = "";
            int ID = -1;

            if (PeopleDataAccess.GetPersonNationalNo(ref ID, ref FirstName, ref SecondName, ref ThirdName, ref NationalityCountryID
                ,  NationalNo,
                          ref Email, ref Address, ref Gendor, ref CountryID, ref ImagePath, ref DateOfBirth,
                          ref Phone, ref LastName))
            {
                return new clsPeople(ID, FirstName, SecondName, ThirdName,
             NationalityCountryID, NationalNo, Gendor,
         Email, Phone, Address, DateOfBirth,
             ImagePath, LastName);
            }

            else
                return null;
        }
        //}

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdatePerson();

            }




            return false;
        }

        public static DataTable GetAllPeople()
        {
            return PeopleDataAccess.GetAllPeople();

        }

        public static bool DeletePerson(int ID)
        {
            return PeopleDataAccess.DeletePerson(ID);
        }

        public static bool isPersonExist(int ID)
        {
            return PeopleDataAccess.IsPersonExist(ID);
        }


        public static bool isPersonExist(string NationalNO)
        {
            return PeopleDataAccess.IsPersonExist(NationalNO);
        }


    }
}
