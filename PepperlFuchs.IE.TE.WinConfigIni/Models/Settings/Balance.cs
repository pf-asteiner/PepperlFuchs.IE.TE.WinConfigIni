using PepperlFuchs.IE.TE.IniFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PepperlFuchs.IE.TE.WinConfigIni.Models.Settings.Base;


namespace PepperlFuchs.IE.TE.WinConfigIni.Models.Settings;

public class Balance 
{
    [Base.Parameter("ITEM", "")]
    public uint Item { get; init; }


    /// <summary>
    /// Settings for communicate over a serial com port
    /// </summary>
    [Parameter("Com port", "communication over a Com Port")]
    public ComSetting?  Com { get; set; } = new ComSetting();

    public Balance(Section section)
    {
        Item = Base.Tools.GetItem(section.SectionName);
        if (section == null) throw new ArgumentNullException(nameof(section));
        Type classType = typeof(Balance);
        if (classType is not null)
        {
            Base.Tools.ReadInProperties(this, classType, section.ParameterList);
        }

    }
    public override string ToString()
    {
        Type type = typeof(Balance);
        return Base.Tools.SerialisationToIni(type);
    }
}
