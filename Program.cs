using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;

namespace WebhookDeleter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Webhook Spammer";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Webhook URL : ");
            string weburl = Console.ReadLine();
            Console.Clear();
            Console.Write("Message : ");
            string lastmsg = Console.ReadLine();
            Console.Clear();
            int CPM_aux = 0;
            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    webhookmsg(weburl, lastmsg);
                    Console.Title = "Webhook Spammer | Sended : " + CPM_aux++.ToString();
                    Console.WriteLine("[+] Succeful sended message");
                    
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[-] Rate limit");
                }
            

            }

        }

        private static void sendWebHook(string URL, string msg, string username)
        {
            Post(URL, new NameValueCollection()
        {
                {
                    "username", username
                },
                {
                    "content",  msg
                }
            });
        }
        private static byte[] Post(string uri, NameValueCollection pairs)
        {
            using (WebClient webclient = new WebClient())
                return webclient.UploadValues(uri, pairs);
        }
        public static void webhookmsg(string webhookurl, string msg)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            sendWebHook(webhookurl, msg, "Bye bye");
        }
    }
}
