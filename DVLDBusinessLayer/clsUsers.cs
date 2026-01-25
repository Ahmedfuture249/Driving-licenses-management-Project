using DVLDDataAccessLayer;
using System.Data;
using static DVLDBusinessLayer.clsPeople;

namespace DVLDBusinessLayer
{

   public class clsUsers
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        int _UserID;
        int _PersonID;
        string _UserPassword;
        string _UserName;
        clsPeople _Person;
        bool _IsActive;

        public clsUsers (int UserID ,int PersonID,string UserName,bool IsActive )
        {
            _UserID = UserID;
            _PersonID = PersonID;
            _Person = clsPeople.Find(_PersonID);
            _UserName = UserName;
            _IsActive = IsActive;
        }
        public clsUsers()
        {
            _UserID = -1;
            _PersonID = -1;
            //_Person = clsPeople.Find(_PersonID);
            _UserName = "";
            _IsActive = false;
        }
        public int UserID
        {
            set { _UserID = value; }
            get { return _UserID; }
        }
        public int PersonID
        {
            set { _PersonID = value; }
            get { return _PersonID; }
        }
        public string UserPassword
        {
            set { _UserPassword = value; }
            get { return _UserPassword; }
        }
        public string UserName
        {
              set { _UserName = value; }
            get { return _UserName; }
        }
        public bool IsActive
        {
            set { _IsActive = value; }
            get { return _IsActive; }
        }
        public clsPeople Person
        {
            set { _Person = value; }
            get { return _Person; }
        }
        public static clsUsers Find(int UserID)
        {
            int PersonID = -1;
            string UserName = "";
            bool IsActive=false;
            if (UsersData.GetUser(UserID, ref UserName, ref PersonID, ref IsActive))
                return new clsUsers(UserID, PersonID, UserName, IsActive);
            else
                return null;

        }
        public static DataTable GetAllUsers()
        {
            return UsersData.GetAllUsers();
        }
        private bool _AddNewUser()
        {
            //call DataAccess Layer 

            this.UserID = UsersData.AddNewUser(this.UserName,this.UserPassword,this.IsActive,this.PersonID);

            return (this.UserID != -1);
        }

        private bool _UpdateUser()
        {
            //call DataAccess Layer 

            return UsersData.UpdateUser(this.UserID,this.UserName, this.UserPassword, this.IsActive, this.PersonID);

        }
        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateUser();

            }




            return false;
        }

    }
}
