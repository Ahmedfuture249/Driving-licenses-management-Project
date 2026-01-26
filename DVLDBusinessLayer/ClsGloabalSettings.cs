using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
    public class ClsGloabalSettings
    {
        private static clsUsers _CurrentUser; 
        public static clsUsers CurrentUser
        {
            set { _CurrentUser = value; }
            get { return _CurrentUser ; }
        }
    }
}
