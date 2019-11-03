using System;
using System.Collections.Generic;
using System.Net;
using CsQuery;
using System.Net.Http;
using System.Linq;
using System.IO;

namespace CheckLinks
{
    class Program
    {
        private static readonly Uri urlConst = new Uri("http://52.136.215.164/broken-links/");

        public static bool InList(List<string> list, string element)
        {
            foreach (string elementInList in list)
            {
                if (elementInList == element)
                {
                    return true;
                }
            }
            return false;
        }

        public static void ParserPageToLinks(List<string> urls, Uri urlForParse, FileStream valid, FileStream error)
        {
            WebRequest request;
            request = WebRequest.Create(urlForParse);

            try
            {
                var status = (HttpWebResponse)request.GetResponse();
                var urlValidToString = urlForParse.ToString() + ' ' + (int)status.StatusCode + '\n';
                byte[] arrayValid = System.Text.Encoding.Default.GetBytes(urlValidToString);
                valid.Write(arrayValid, 0, arrayValid.Length);
                request.Abort();
            }
            catch (WebException exc)
            {
                var status = (HttpWebResponse)exc.Response;
                var urlErrorToString = urlForParse.ToString() + ' ' + (int)status.StatusCode + '\n';
                byte[] arrayError = System.Text.Encoding.Default.GetBytes(urlErrorToString);
                error.Write(arrayError, 0, arrayError.Length);
                request.Abort();

                return;
            }

            WebClient webClient = new WebClient();
            string html = webClient.DownloadString(urlForParse);
            CQ cq = CQ.Create(html);

            foreach (IDomObject obj in cq.Find("a"))
            {
                string tag = obj.GetAttribute("href");

                if (tag == null)
                {
                    continue;
                }
                else if (tag.Contains("https://"))
                {
                    continue;
                }
                else if (tag == "#")
                {
                    continue;
                }


                Uri nUrl = new Uri(urlConst + tag);
                string nUrlString = nUrl.ToString();
                if (!InList(urls, nUrlString))
                {
                    urls.Add(nUrlString);
                    ParserPageToLinks(urls, nUrl, valid, error);
                }
            }
        }

        static void Main(string[] args)
        {
            FileStream fileValid = File.OpenWrite("valid.txt");
            FileStream fileError = File.OpenWrite("error.txt");
            Uri urlKey = new Uri("http://52.136.215.164/broken-links/");
            List<string> urls = new List<string> { urlKey.ToString() };
            ParserPageToLinks(urls, urlKey, fileValid, fileError);
        }
    }
}
