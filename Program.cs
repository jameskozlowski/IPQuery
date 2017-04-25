// *************************************************
// A Simple API for using http://ip-api.com/
// AUTHOR: James Kozlowski
// INFO: https://github.com/jameskozlowski/IPQuery
//
// *************************************************

using System;
using System.Threading.Tasks;

namespace iplookup
{
    class Program
    {
        static void Main(string[] args)
        {
            //print out the help msg
            if (args.Length == 1 && args[0] == "help")
            {
                Console.WriteLine("\nPlease specify an IP address in the form of x.x.x.x, a host name, or leave blank to use your IP\n");
                return;
            }

            //print out  please wait msg
            Console.WriteLine();
            Console.Write("Please wait...");

            string ip = "";

            //if a IP was supplied set IP to that IP
            if (args.Length == 1)
                ip = args[0];

            //get the IP data
            Task<IPQuery> t = IPQuery.IPLookupAsync(ip);

            //display a progress while we wait
            while (!t.IsCompleted)
            {
                Console.Write(".");
                System.Threading.Thread.Sleep(500);
            }

            //Add some blank lines
            Console.WriteLine();
            Console.WriteLine();

            //get results
            IPQuery data = t.Result;

            //print out the results
            if (data.Status == "success")
                Console.WriteLine(data);
            //there was a error    
            else
            {
                Console.WriteLine("Error: {0}", data.Error);
                Console.WriteLine("Please specify an IP address in the form of x.x.x.x, a host name, or leave blank to use your IP");
            }
            
            //add a blank line for easy reading
            Console.WriteLine();
        }
    }
}
