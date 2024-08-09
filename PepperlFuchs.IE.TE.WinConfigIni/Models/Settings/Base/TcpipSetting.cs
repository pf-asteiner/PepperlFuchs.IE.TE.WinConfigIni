using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PepperlFuchs.IE.TE.WinConfigIni.Models.Settings.Base;

public class TcpipSetting
{
    [Parameter ("IP_ADDRESS", "IP Address of device")]
    public IPAddress IpAddress { get; set; } = IPAddress.Parse("000.000.000.000");
    [Parameter("IP_ADDRESS_PC", "IP address of PC")]
    public IPAddress IpAddressPc { get; set; } = IPAddress.Parse("000.000.000.000");
    [Parameter("IP_SUBNETMASK_PC", "Sub net mask")]
    public IPAddress IpSubnetmaskPc { get; set; } = IPAddress.Parse("255.255.255.000");
    [Parameter("TCP_PORT", "Port number")]
    public UInt32 TcpPort { get; set; } = 0;
}
