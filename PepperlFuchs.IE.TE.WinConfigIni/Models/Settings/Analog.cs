using PepperlFuchs.IE.TE.IniFile;
using PepperlFuchs.IE.TE.WinConfigIni.Models.Settings.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace PepperlFuchs.IE.TE.WinConfigIni.Models.Settings;

public class Analog
{
    private uint _SubTyp = 0;

    
    [Parameter("ITEM", "")]
    public uint Item { get; init; }

    // Mit einem Sub Parameter komme ich noch nicht klar

    ///// <summary>
    ///// Settings for communicate over a TCP IP port
    ///// </summary>
    [Parameter("IpSetting", "communication over a IP connection")]
    public TcpipSetting TcpIp { get; set; } = new TcpipSetting();
      
    /// <summary>
    /// typ of used daughter board
    /// </summary>
    [Parameter("SUB_TYPE", "")]
    public uint SubType
    {
        get { return _SubTyp; }
        set
        {
            if (value == 102 || value == 103 || value == 105)
            {
                // 102 = 8/8 AIO, 8/0 DIO
                // 103 = 16/16 AIO
                // 105 = 16/2 DIO
                _SubTyp = value;
            }
            else
            {
                throw new ArgumentException("Value >" + value.ToString() + "< is not allowed");
            }
        }
    }


    public Analog(Section section)
    {
        Item = Base.Tools.GetItem(section.SectionName);
        if (section == null) throw new ArgumentNullException(nameof(section));
        Type classType = typeof(Analog);
        if (classType is not null)
        {
            Base.Tools.ReadInProperties(this, classType, section.ParameterList);
        }

    }
    public override string ToString()
    {
        Type type = typeof(Analog);
        return Base.Tools.SerialisationToIni(type);
    }

}


