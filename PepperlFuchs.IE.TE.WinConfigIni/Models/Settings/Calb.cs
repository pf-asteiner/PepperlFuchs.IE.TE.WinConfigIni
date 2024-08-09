using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PepperlFuchs.IE.TE.WinConfigIni.Models.Settings.Base;
using PepperlFuchs.IE.TE.IniFile;


namespace PepperlFuchs.IE.TE.WinConfigIni.Models.Settings;

internal class Calb
{
    [Base.Parameter("ITEM", "")]
    public uint Item { get; init; }
    ///// <summary>
    ///// Settings for communicate over a serial com port
    ///// </summary>
    [Parameter("Com port", "communication over a Com Port")]
    public ComSetting Com { get; set; } = new ComSetting();
    [Base.Parameter("PASSWORD", "")]
    public string Password { get; set; } = string.Empty;

    ///// <summary>
    ///// Settings for communicate over a TCP IP port
    ///// </summary>
    [Parameter("IpSetting", "communication over a IP connection")]
    public TcpipSetting TcpIp { get; set; } = new TcpipSetting();

    public Calb(Section section)
    {
        Item = Base.Tools.GetItem(section.SectionName);
        if (section == null) throw new ArgumentNullException(nameof(section));
        Type classType = typeof(Calb);
        if (classType is not null)
        {
            Base.Tools.ReadInProperties(this, classType, section.ParameterList);
        }

    }
    public override string ToString()
    {
        Type type = typeof(Calb);
        return Base.Tools.SerialisationToIni(type);
    }
}
