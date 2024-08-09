using PepperlFuchs.IE.TE.IniFile;
using PepperlFuchs.IE.TE.WinConfigIni.Models.Settings.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PepperlFuchs.IE.TE.WinConfigIni.Models.Settings
{
    public class Asi  
    {
        [Base.Parameter("ITEM", "")]
        public uint Item { get; init; }


        ///// <summary>
        ///// Settings for communicate over a serial com port
        ///// </summary>
        [Parameter("Com port", "communication over a Com Port")]
        public ComSetting Com { get; set; }  = new ComSetting();


    
        public Asi(Section section)
        {
            Item = Base.Tools.GetItem(section.SectionName);
            if (section == null) throw new ArgumentNullException(nameof(section));
            Type classType = typeof(Asi);
            if (classType is not null)
            {
                Base.Tools.ReadInProperties(this, classType, section.ParameterList);
            }

        }
        public override string ToString()
        {
            Type type = typeof(Asi);
            return Base.Tools.SerialisationToIni(type);
        }

    }
}
