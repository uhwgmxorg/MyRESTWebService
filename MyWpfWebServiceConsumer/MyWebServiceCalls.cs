using System;
using System.Diagnostics;

namespace MyWpfWebServiceConsumer
{
    class MyWebServiceCalls
    {
        /// <summary>
        /// GetDataFromWebService
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string GetDataFromWebService(string url)
        {
            string result;

            // Request the service
            try
            {
                System.Net.HttpWebRequest myRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
                myRequest.Method = "GET";
                System.Net.WebResponse myResponse = myRequest.GetResponse();
                System.IO.StreamReader sr = new System.IO.StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
                result = sr.ReadToEnd();
                System.Diagnostics.Debug.WriteLine(result);
                result = result.Replace('\n', ' ');
                sr.Close();
                myResponse.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return ex.ToString();
            }

            return result;
        }
    }
}
