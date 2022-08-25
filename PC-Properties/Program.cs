using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PC_Properties
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine($"MAC Address: {GetMACAddress()}");
            Console.WriteLine($"Host Name: {GetHostName()}");
            Console.WriteLine($"IP Address: {GetIpAddress()}");
            Console.ReadLine();
        }
        private static string GetMACAddress()
        {
            return NetworkInterface
                .GetAllNetworkInterfaces()
                .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                .Select(nic => nic.GetPhysicalAddress().ToString())
                .FirstOrDefault();
        }

        private static string GetHostName()
        {
            return Dns.GetHostName();
        }

        private static string GetIpAddress()
        {
            string HostName = Dns.GetHostName();
            IPAddress[] ipaddress = Dns.GetHostAddresses(HostName);

            return ipaddress.Where(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).FirstOrDefault().ToString();
        }

    }
}
