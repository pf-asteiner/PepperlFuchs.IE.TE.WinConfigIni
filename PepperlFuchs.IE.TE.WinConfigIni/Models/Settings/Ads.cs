using PepperlFuchs.IE.TE.IniFile;
using PepperlFuchs.IE.TE.WinConfigIni.Models.Settings.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace PepperlFuchs.IE.TE.WinConfigIni.Models.Settings;

public class Ads
{
    [Base.Parameter("ITEM", "")]
    public uint Item { get; init; }

    [Parameter("FC5101_BOARDINDEX", "???")]
    public uint Fc5101BoardIndex { get; set; }

    [Parameter("FC5101_TIMEOUT", "???")]
    public uint Fc5101TimeOut { get; set; }


    public Ads(Section section)
    {
        Item = Base.Tools.GetItem(section.SectionName);
        if (section == null) throw new ArgumentNullException(nameof(section));
        Type classType = typeof(Ads);
        if (classType is not null)
        {
            Base.Tools.ReadInProperties(this, classType, section.ParameterList);
        }
    }
     
    public override string ToString()
    {
        Type type = typeof(Ads);
        return Base.Tools.SerialisationToIni(type);
    }
}


