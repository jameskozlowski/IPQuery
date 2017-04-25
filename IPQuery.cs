// *************************************************
// A Simple API for using http://ip-api.com/
// AUTHOR: James Kozlowski
// INFO: https://github.com/jameskozlowski/IPQuery
//
// *************************************************

using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace iplookup
{
    /// <summary>
    /// A Simple API for using http://ip-api.com/
    /// 
    /// 
    /// RETURNED DATA
    /// name	        description	        example	                type
    /// -----------------------------------------------------------------------
    /// status	        Success/fail	    success	                string 
    /// message         Error Message       invalid query           string
    /// country	        country	United      States	                string
    /// countryCode	    country short	    US	                    string
    /// region	        region/state 	    CA or 10	            string
    /// regionName	    region/state	    California	            string
    /// city	        city	            Mountain View	        string
    /// zip	            zip code	        94043	                string
    /// lat	            latitude	        37.4192	                float
    /// lon	            longitude	        -122.0574	            float
    /// timezone	    city timezone	    America/Los_Angeles	    string
    /// isp	            ISP name	        Google	                string
    /// org	            Organization name	Google	                string
    /// as	            AS number and name	AS15169 Google Inc.	    string
    /// reverse	        Reverse DNS 	    wi-in-f94.1e100.net	    string
    /// mobile	        mobile (cellular)   true	                bool
    /// proxy	        proxy (anonymous)	true	                bool
    /// query	        IP                  173.194.67.94	        string
    /// 
    /// </summary>
    [XmlRoot("query")]
    public class IPQuery
    {
        [XmlElement("status")]
        public string Status { get; set; }

        [XmlElement("message")]
        public string Error { get; set; }

        [XmlElement("country")]
        public string Country { get; set; }

        [XmlElement("countryCode")]
        public string CountryCode { get; set; }

        [XmlElement("region")]
        public string Region { get; set; }

        [XmlElement("regionName")]
        public string RegionName { get; set; }

        [XmlElement("city")]
        public string City { get; set; }

        [XmlElement("zip")]
        public string Zip { get; set; }

        [XmlElement("lat")]
        public double Latitude { get; set; }

        [XmlElement("lon")]
        public double Longitude { get; set; }

        [XmlElement("timezone")]
        public string Timezone { get; set; }

        [XmlElement("isp")]
        public string ISP { get; set; }

        [XmlElement("org")]
        public string Organization { get; set; }

        [XmlElement("as")]
        public string ASNumber { get; set; }

        [XmlElement("reverse")]
        public string Reverse { get; set; }

        [XmlElement("mobile")]
        public bool Mobile { get; set; }

        [XmlElement("proxy")]
        public bool Proxy { get; set; }

        [XmlElement("query")]
        public string Query { get; set; }

        /// <summary>
        /// Performes a query on the provided IP address
        /// 
        /// If there is no internet connectio or any other error an exception will be thrown.
        /// This exception will need to be handeled by the application
        /// </summary>
        /// <param name="ip">IP address to look up in the form x.x.x.x or host name</param>
        /// <returns>A IPQuery object of the results</returns>
        public static async Task<IPQuery> IPLookupAsync(string ip)
        {
            //create a clinet and set the base IP
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://ip-api.com/xml/");
            client.DefaultRequestHeaders.Accept.Clear();

            //call the request with the supplied IP with all fields
            HttpResponseMessage response = await client.GetAsync(ip + "?fields=262143");

            //read the response as a string
            string data = await response.Content.ReadAsStringAsync();

            //convert the XML to a IPQuery object
            XmlSerializer serializer = new XmlSerializer(typeof(IPQuery));
            using (TextReader reader = new StringReader(data))
            {
                IPQuery result = (IPQuery) serializer.Deserialize(reader);

                //return the result
                return result;
            }
        }

        /// <summary>
        /// Generates a string of the object
        /// </summary>
        /// <returns>A string of the object</returns>
        public override string ToString()
        {
            return  "Status:      \t" + this.Status + "\n" +
                    "Message:     \t" + this.Error + "\n" +
                    "Country:     \t" + this.Country + "\n" +
                    "Country Code:\t" + this.CountryCode + "\n" +
                    "Region:      \t" + this.Region + "\n" +
                    "Region Name: \t" + this.RegionName + "\n" +
                    "City:        \t" + this.City + "\n" +
                    "Zip:         \t" + this.Zip + "\n" +
                    "Latitude:    \t" + this.Latitude + "\n" +
                    "Longitude:   \t" + this.Longitude + "\n" +
                    "Timezone:    \t" + this.Timezone + "\n" + 
                    "ISP:         \t" + this.ISP + "\n" + 
                    "Organization:\t" + this.Organization + "\n" + 
                    "AS Number:   \t" + this.ASNumber + "\n" +
                    "Reverse:     \t" + this.Reverse + "\n" +
                    "Mobile:      \t" + this.Mobile + "\n" +
                    "Proxy:       \t" + this.Proxy + "\n" +
                    "Query:       \t" + this.Query;
        }

    }
}

