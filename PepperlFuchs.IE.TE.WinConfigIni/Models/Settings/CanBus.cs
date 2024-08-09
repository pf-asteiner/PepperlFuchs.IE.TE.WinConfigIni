using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PepperlFuchs.IE.TE.WinConfigIni.Models.Settings.Base;
using PepperlFuchs.IE.TE.IniFile;


namespace PepperlFuchs.IE.TE.WinConfigIni.Models.Settings;

internal class CanBus
{
    [Base.Parameter("ITEM", "")]
    public uint Item { get; init; }
    ///// <summary>
    ///// Settings for communicate over a TCP IP port
    ///// </summary>
    [Parameter("IpSetting", "communication over a IP connection")]
    public TcpipSetting TcpIp { get; set; } = new TcpipSetting();

    ///// <summary>
    ///// Settings for communicate over a TCP IP port
    ///// </summary>
    [Parameter("SPEED", "communication in kBits")]
    public int Speed { get; set; }

    public CanBus(Section section)
    {
        Item = Base.Tools.GetItem(section.SectionName);
        if (section == null) throw new ArgumentNullException(nameof(section));
        Type classType = typeof(CanBus);
        if (classType is not null)
        {
            Base.Tools.ReadInProperties(this, classType, section.ParameterList);
        }

    }
    public override string ToString()
    {
        Type type = typeof(CanBus);
        return Base.Tools.SerialisationToIni(type);
    }
}
