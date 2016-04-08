using System;
using System.IO;
using System.Net;
using System.Security;
using System.Security.Permissions;
using System.Text;

namespace WebLinkChecker
{
    static class WebLinkCheckerHelper
    {
        public static bool TryAccessWebLink(string pageURL, out object result)
        {
            if (string.IsNullOrEmpty(pageURL))
                throw new ArgumentNullException("pageURL");

            return TryGetWebLinkResponse((HttpWebRequest)HttpWebRequest.Create(ConvertToUri(pageURL)), out result);
        }

        public static bool TryAccessWebLink(string pageURL, string userName, string password, string domain, out object result)
        {
            if (string.IsNullOrEmpty(pageURL))
                throw new ArgumentNullException("pageURL");
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException("userName");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException("password");
            if (string.IsNullOrEmpty(domain))
                throw new ArgumentNullException("domain");

            Uri uri = ConvertToUri(pageURL);
            HttpWebRequest objRequest = (HttpWebRequest)HttpWebRequest.Create(uri);
            CredentialCache cc = new CredentialCache();
            cc.Add(uri, "Basic", new NetworkCredential(userName, password, domain));
            objRequest.Credentials = cc;
            objRequest.PreAuthenticate = true;
            objRequest.AllowAutoRedirect = true;
            objRequest.Proxy = null;  
            return TryGetWebLinkResponse(objRequest, out result);
        }

        public static string AccessWebLink(string pageURL)
        {
            if (string.IsNullOrEmpty(pageURL))
                throw new ArgumentNullException("pageURL");

            return GetWebLinkResponse((HttpWebRequest)HttpWebRequest.Create(ConvertToUri(pageURL)));
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public static string AccessWebLink(string pageURL, string userName, string password, string domain)
        {
            if (string.IsNullOrEmpty(pageURL))
                throw new ArgumentNullException("pageURL");
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException("userName");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException("password");
            if (string.IsNullOrEmpty(domain))
                throw new ArgumentNullException("domain");

            Uri uri = ConvertToUri(pageURL);
            HttpWebRequest objRequest = (HttpWebRequest)HttpWebRequest.Create(uri);
            CredentialCache cc = new CredentialCache();
            cc.Add(uri, "NTLM", new NetworkCredential(userName, password, domain));
            cc.Add(uri, "Basic", new NetworkCredential(userName, password, domain));
            objRequest.Credentials = cc;
            objRequest.PreAuthenticate = true;
            objRequest.AllowAutoRedirect = true;
            objRequest.Proxy = null;  
            return GetWebLinkResponse(objRequest);
        }

        private static bool TryGetWebLinkResponse(HttpWebRequest objRequest, out object result)
        {
            try
            {
                result = GetWebLinkResponse(objRequest);
                return true;
            }
            catch (Exception ex)
            {
                result = ex;
                return false;
            }
        }

        private static Uri ConvertToUri(string pageURL)
        {
            if (pageURL.IndexOf("://") <= 0)
                return new Uri(string.Format("http://{0}", pageURL), UriKind.RelativeOrAbsolute);
            else
                return new Uri(pageURL, UriKind.RelativeOrAbsolute);
        }

        private static string GetWebLinkResponse(HttpWebRequest objRequest)
        {
            objRequest.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)";
            objRequest.ContentType = "application/x-www-form-urlencoded";
            objRequest.Timeout = 10000;
            objRequest.ServicePoint.ConnectionLeaseTimeout = 10000;
            objRequest.ServicePoint.MaxIdleTime = 10000;
            objRequest.ReadWriteTimeout = 10000;
            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            if (objResponse.StatusCode == HttpStatusCode.OK)
            {
                Stream responseStream = objResponse.GetResponseStream();
                StreamReader objSR = null;
                if (string.IsNullOrEmpty(objResponse.CharacterSet))
                    objSR = new StreamReader(responseStream);
                else
                    objSR = new StreamReader(responseStream, Encoding.GetEncoding(objResponse.CharacterSet));
                string result = objSR.ReadToEnd();
                objSR.Close();
                objResponse.Close();
                return result;
            }
            return null;
        }
    }
}
