using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Web;

namespace HISSMS
{
    public class clsSMS
    {
        static string SEND_URL = "http://113.185.0.35:8888/smsmarketing/api";
        // static string SEND_URL = "http://10.149.56.145:8888/smsmarketing/api";

        public clsSMS()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //REQID	Request ID
        //LABELID	ID của nhãn
        //TEMPLATEID	ID của mẫu tin nhắn
        //ISTELCOSUB	Sử dụng nhóm thuê bao của nhà mạng. Giá trị 0 hoặc 1
        //PARAMS.NUM	Số thứ tự của tham số truyền vào mẫu bản tin
        //PARAMS.CONTENT	Nội dung của tham số tương ứng
        //CONTRACTTYPEID	Tin nhắn QC = 2, tin nhắn CSKH = 1
        //SCHEDULETIME	Đặt lịch gửi tin. Cấu trúc là : dd/MM/yyyy hh24:mi, ví dụ : 08/05/2012 16:30
        //MOBILELIST	Danh sách các số thuê bao cần gửi, các thuê bao phân cách bởi dấu phẩy , và không có khoảng trắng
        //AGENTID	ID của nhà đại lý (Vinaphone cấp)
        //APIUSER	Username của API (Vinaphone cấp)
        //APIPASS	Password của API (Vinaphone cấp)
        //USERNAME	User đăng nhập của Agent
        //CONTRACTID	ID của hợp đồng
        public string sendByList(string REQID, string LABELID, string TEMPLATEID, string ISTELCOSUB, string CONTRACTTYPEID, string SCHEDULETIME, string MOBILELIST, string AGENTID, string APIUSER, string APIPASS, string USERNAME, string CONTRACTID, string[] PARAMS)
        {
            string req = buildSendByListReq(REQID, LABELID, TEMPLATEID, ISTELCOSUB, CONTRACTTYPEID, SCHEDULETIME, MOBILELIST, AGENTID, APIUSER, APIPASS, USERNAME, CONTRACTID, PARAMS);
            string resp = "";
            try
            {
                resp = PostVer2(SEND_URL, req);
            }
            catch (Exception)
            {
                return null;
            }
            return resp;
        }

        public static string buildSendByListReq(string REQID, string LABELID, string TEMPLATEID, string ISTELCOSUB, string CONTRACTTYPEID, string SCHEDULETIME, string MOBILELIST, string AGENTID, string APIUSER, string APIPASS, string USERNAME, string CONTRACTID, string[] PARAMS)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<RQST name=\"send_sms_list\">");
            sb.Append("<REQID>").Append(REQID).Append("</REQID>");
            sb.Append("<LABELID>").Append(LABELID).Append("</LABELID>");
            sb.Append("<TEMPLATEID>").Append(TEMPLATEID).Append("</TEMPLATEID>");
            sb.Append("<ISTELCOSUB>").Append(ISTELCOSUB).Append("</ISTELCOSUB>");
            sb.Append("<CONTRACTTYPEID>").Append(CONTRACTTYPEID).Append("</CONTRACTTYPEID>");
            sb.Append("<SCHEDULETIME>").Append(SCHEDULETIME).Append("</SCHEDULETIME>");
            sb.Append("<MOBILELIST>").Append(MOBILELIST).Append("</MOBILELIST>");
            sb.Append("<AGENTID>").Append(AGENTID).Append("</AGENTID>");
            sb.Append("<APIUSER>").Append(APIUSER).Append("</APIUSER>");
            sb.Append("<APIPASS>").Append(APIPASS).Append("</APIPASS>");
            sb.Append("<USERNAME>").Append(USERNAME).Append("</USERNAME>");
            sb.Append("<CONTRACTID>").Append(CONTRACTID).Append("</CONTRACTID>");
            if (PARAMS != null && PARAMS.Length > 0)
            {
                for (int j = 0; j < PARAMS.Length; j++)
                {
                    sb.Append("<PARAMS>");
                    sb.Append("<NUM>").Append(j + 1).Append("</NUM><CONTENT>").Append(PARAMS[j]).Append("</CONTENT>");
                    sb.Append("</PARAMS>");
                }
            }
            sb.Append("</RQST>");
            return sb.ToString();
        }

        public static string PostVer2(string url, string data)
        {
            Object o = new Object();
            lock (o)
            {
                string vystup = null;
                try
                {
                    //Our postvars
                    byte[] buffer = Encoding.UTF8.GetBytes(data);
                    //Initialisation, we use localhost, change if appliable
                    HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(url);
                    //Our method is post, otherwise the buffer (postvars) would be useless
                    WebReq.Method = "POST";
                    //We use form contentType, for the postvars.
                    WebReq.ContentType = "text/xml;charset=utf-8";
                    //The length of the buffer (postvars) is used as contentlength.
                    WebReq.ContentLength = buffer.Length;
                    // time out to MIM
                    WebReq.Timeout = 30000;
                    //We open a stream for writing the postvars
                    Stream PostData = WebReq.GetRequestStream();
                    //Now we write, and afterwards, we close. Closing is always important!
                    PostData.Write(buffer, 0, buffer.Length);
                    PostData.Close();
                    //Get the response handle, we have no true response yet!
                    HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();
                    //Let's show some information about the response
                    //Console.WriteLine(WebResp.StatusCode);
                    //Console.WriteLine(WebResp.Server);

                    //Now, we read the response (the string), and output it.
                    Stream Answer = WebResp.GetResponseStream();
                    StreamReader _Answer = new StreamReader(Answer);
                    vystup = _Answer.ReadToEnd();
                    //Congratulations, you just requested your first POST page, you
                    //can now start logging into most login forms, with your application
                    //Or other examples.
                    try
                    {
                        WebResp.Close();
                        Answer.Close();
                        _Answer.Close();
                    }
                    catch
                    {
                    }
                }
                catch (Exception)
                {
                }
                if (vystup != null)
                {
                    return vystup.Trim() + "\n";
                }
                else
                {
                    return "" + "\n";
                }
            }
        }

        public string getValue(String xml, String openTag, String closeTag)
        {
            try
            {
                int idx_open = xml.IndexOf(openTag);
                int len = openTag.Length;
                int start = idx_open + len;
                int idx_close = xml.IndexOf(closeTag);
                return xml.Substring(start, idx_close - start);
            }
            catch
            {
                return "";
            }
        }

        public string EscapeXML(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;

            string returnString = s;
            returnString = returnString.Replace("'", "&apos;");
            returnString = returnString.Replace("\"", "&quot;");
            returnString = returnString.Replace(">", "&gt;");
            returnString = returnString.Replace("<", "&lt;");
            returnString = returnString.Replace("&", "&amp;");

            return returnString;
        }
    }
}

