using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PepperlFuchs.IE.TE.WinConfigIni.Models.Settings.Base;
using PepperlFuchs.IE.TE.IniFile;


namespace PepperlFuchs.IE.TE.WinConfigIni.Models.Settings;

internal class Cam
{
    [Base.Parameter("ITEM", "")]
    public uint Item { get; init; }

    [Base.Parameter("TYPE", "")]
    public string Type { get; set; } = string.Empty;
    ///// <summary>
    ///// Settings for communicate over a serial com port
    ///// </summary>
    [Parameter("Com port", "communication over a Com Port")]
    public ComSetting Com { get; set; } = new ComSetting();
    public Cam(Section section)
    {
        Item = Base.Tools.GetItem(section.SectionName);
        if (section == null) throw new ArgumentNullException(nameof(section));
        Type classType = typeof(Cam);
        if (classType is not null)
        {
            Base.Tools.ReadInProperties(this, classType, section.ParameterList);
        }

    }
    public override string ToString()
    {
        Type type = typeof(Cam);
        return Base.Tools.SerialisationToIni(type);
    }
}
