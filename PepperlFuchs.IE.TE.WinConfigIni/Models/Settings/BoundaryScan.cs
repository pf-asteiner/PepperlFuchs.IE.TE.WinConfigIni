using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PepperlFuchs.IE.TE.WinConfigIni.Models.Settings.Base;
using PepperlFuchs.IE.TE.IniFile;

namespace PepperlFuchs.IE.TE.WinConfigIni.Models.Settings;

internal class BoundaryScan
{
    [Base.Parameter("ITEM", "")]
    public uint Item { get; init; }
    [Base.Parameter("CASCON_DLLPATH", "")]
    public string CasconDllPath { get; set; }
    [Base.Parameter("CASCON_RESULTPATH", "")]
    public string CasconResultPath { get; set; }
    [Base.Parameter("CASCON_ROOTPATH", "")]
    public string CasconRootPath { get; set; }
    [Base.Parameter("CASCON_USERNAME", "")]
    public string CasconUserName { get; set; }
    // obsolate parameter
    //[Base.Parameter("CASCON_UUTPATH", "")]
    //public string CasconUutPath { get; set; }

    public BoundaryScan(Section section)
    {
        Item = Base.Tools.GetItem(section.SectionName);
        if (section == null) throw new ArgumentNullException(nameof(section));
        Type classType = typeof(BoundaryScan);
        if (classType is not null)
        {
            Base.Tools.ReadInProperties(this, classType, section.ParameterList);
        }

    }
    public override string ToString()
    {
        Type type = typeof(BoundaryScan);
        return Base.Tools.SerialisationToIni(type);
    }
}
