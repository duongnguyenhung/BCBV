using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace HISSMS
{
    class clsSMSConfig
    {
        private string _sms_agentid = "258";
        private string _sms_labelid = "59349";
        private string _sms_templateid = "234992";
        private string _sms_istelcosub = "0";
        private string _sms_contracttypeid = "1";
        private string _sms_apiuser = "sovhttdl";
        private string _sms_apipass = "Vnpt@123456";
        private string _sms_username = "STG_CS";
        private string _sms_contractid = "5688";


        public clsSMSConfig()
	    {
	    }

        public string sms_agentid 
        {
            get { return _sms_agentid; }
            set { _sms_agentid = value; }
        }

        public string sms_labelid
        {
            get { return _sms_labelid; }
            set { _sms_labelid = value; }
        }

        public string sms_templateid
        {
            get { return _sms_templateid; }
            set { _sms_templateid = value; }
        }

        public string sms_istelcosub
        {
            get { return _sms_istelcosub; }
            set { _sms_istelcosub = value; }
        }

        public string sms_contracttypeid
        {
            get { return _sms_contracttypeid; }
            set { _sms_contracttypeid = value; }
        }

        public string sms_apiuser
        {
            get { return _sms_apiuser; }
            set { _sms_apiuser = value; }
        }

        public string sms_apipass
        {
            get { return _sms_apipass; }
            set { _sms_apipass = value; }
        }

        public string sms_username
        {
            get { return _sms_username; }
            set { _sms_username = value; }
        }

        public string sms_contractid
        {
            get { return _sms_contractid; }
            set { _sms_contractid = value; }
        }
    }
}
