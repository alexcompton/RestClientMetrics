using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Management.Instrumentation;
using System.Net;
using System.Net.Http;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args) {
            var list = CommercialCustomers().Result;
            Console.WriteLine("\n\nAll Test Completed");
            Console.ReadKey();
        }

        private static async Task<List<string>> CommercialCustomers() {
            var tls = new List<Task<string>>();

            // Local
            tls.Add(MakeRequest("http://localhost/WebAPI/customer/commercial"));
            tls.Add(MakeRequest("http://localhost/WebAPI/customer/commercial/130007565"));
            tls.Add(MakeRequest("http://localhost/WebAPI/customer/commercial/130007565/billing"));
            tls.Add(MakeRequest("http://localhost/WebAPI/customer/commercial/130007565/invoices"));
            tls.Add(MakeRequest("http://localhost/WebAPI/customer/commercial/130007565/invoices"));
            tls.Add(MakeRequest("http://localhost/WebAPI/customer/commercial/130007565/orders"));
            tls.Add(MakeRequest("http://localhost/WebAPI/customer/commercial/130007565/orders/203140"));
            tls.Add(MakeRequest("http://localhost/WebAPI/customer/commercial/130007565/quotes"));
            tls.Add(MakeRequest("http://localhost/WebAPI/customer/commercial/130007565/quotes"));
            tls.Add(MakeRequest("http://localhost/WebAPI/customer/commercial/130007565/contacts"));
            tls.Add(MakeRequest("http://localhost/WebAPI/customer/commercial/accounts"));
            tls.Add(MakeRequest("http://localhost/WebAPI/customer/api/Customers"));

            // IN
            tls.Add(MakeRequest("http://clwinvwapi01/customer/commercial"));
            tls.Add(MakeRequest("http://clwinvwapi01/customer/commercial/130007565"));
            tls.Add(MakeRequest("http://clwinvwapi01/customer/commercial/130007565/billing"));
            tls.Add(MakeRequest("http://clwinvwapi01/customer/commercial/130007565/invoices"));
            tls.Add(MakeRequest("http://clwinvwapi01/customer/commercial/130007565/invoices"));
            tls.Add(MakeRequest("http://clwinvwapi01/customer/commercial/130007565/orders"));
            tls.Add(MakeRequest("http://clwinvwapi01/customer/commercial/130007565/orders/203140"));
            tls.Add(MakeRequest("http://clwinvwapi01/customer/commercial/130007565/quotes"));
            tls.Add(MakeRequest("http://clwinvwapi01/customer/commercial/130007565/quotes"));
            tls.Add(MakeRequest("http://clwinvwapi01/customer/commercial/130007565/contacts"));
            tls.Add(MakeRequest("http://clwinvwapi01/customer/commercial/accounts"));
            tls.Add(MakeRequest("http://clwinvwapi01/customer/api/Customers"));

            var ls = await Task.WhenAll(tls.ToArray());
            return ls.ToList();
        }

        private static async Task<string> MakeRequest(string v)
        {
            var client = new HttpClient();

            var watch = new Stopwatch();
            watch.Start();

            var resp = await client.GetAsync(v);
            var status = resp.StatusCode;

            watch.Stop();
            var str = v + " : " + watch.ElapsedMilliseconds + " ms.";

            Console.WriteLine(str);
            return str;
        }
    }
}
