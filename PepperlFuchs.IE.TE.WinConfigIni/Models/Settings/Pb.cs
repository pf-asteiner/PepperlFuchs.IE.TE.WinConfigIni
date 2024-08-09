using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PepperlFuchs.IE.TE.IniFile;
using PepperlFuchs.IE.TE.WinConfigIni.Models.Settings.Base;


namespace PepperlFuchs.IE.TE.WinConfigIni.Models.Settings;

internal class Pb
{
    [Base.Parameter("ITEM", "")]
    public uint Item { get; init; }
    public Pb(Section section)
    {
        Item = Base.Tools.GetItem(section.SectionName);
        if (section == null) throw new ArgumentNullException(nameof(section));
        Type classType = typeof(Dio);
        if (classType is not null)
        {
            Base.Tools.ReadInProperties(this, classType, section.ParameterList);
        }

    }
    public override string ToString()
    {
        Type type = typeof(Dio);
        return Base.Tools.SerialisationToIni(type);
    }
}
