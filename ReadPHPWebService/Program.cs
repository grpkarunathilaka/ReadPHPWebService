using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace ReadPHPWebService
{
    class Program
    {
        static void Main(string[] args)
        {
            WebService ws = new WebService("service Url", "integrator_get_results");
            ws.Params.Add("start_date_time", "2014-05-05");
            ws.Params.Add("end_date_time", "2014-05-06");
            ws.Invoke();
            // string serviceOut = ws.ResultString;

            //XDocument output = ws.ResultXML;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(ws.ResultString);

            XmlNamespaceManager mgr = new XmlNamespaceManager(xmlDoc.NameTable);
            mgr.AddNamespace("SOAP-ENV", "http://schemas.xmlsoap.org/soap/envelope/");
            mgr.AddNamespace("ns1", "nameSpace");
            XmlNodeList examNodes = xmlDoc.SelectNodes("/SOAP-ENV:Envelope/SOAP-ENV:Body/ns1:integrator_get_resultsResponse/return/item", mgr);

            List<ContactResult> list = new List<ContactResult>();
            foreach (XmlNode exam in examNodes)
            {
                ContactResult result = new ContactResult();
                var nodes = exam.SelectNodes("item");
                foreach (XmlNode item in nodes)
                {
                    switch (item.SelectSingleNode("key").InnerText)
                        {
                            case "userid":
                                result.UserID = Convert.ToInt32(item.SelectSingleNode("value").InnerText);
                                break;
                            case "course_idnumber":
                                result.CourseCode = item.SelectSingleNode("value").InnerText;
                                break;
                            case "username":
                                result.UniqueID = Convert.ToInt32(item.SelectSingleNode("value").InnerText);
                                break;
                            case "firstname":
                                result.FirstName = item.SelectSingleNode("value").InnerText;
                                break;
                            case "lastname":
                                result.LastName = item.SelectSingleNode("value").InnerText;
                                break;
                            case "result_type":
                                result.ResultType = item.SelectSingleNode("value").InnerText;
                                break;
                            case "timefinish":
                                result.TimeFinish = Convert.ToDateTime(item.SelectSingleNode("value").InnerText);
                                break;
                            case "finalgrade":
                                result.FinalGrade = item.SelectSingleNode("value").InnerText;
                                break;
                            default:
                                break;
                        }
                }
                list.Add(result);
            }          

        }
    }
}
