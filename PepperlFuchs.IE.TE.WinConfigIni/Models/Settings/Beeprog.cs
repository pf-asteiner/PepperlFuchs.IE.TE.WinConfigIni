using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PepperlFuchs.IE.TE.WinConfigIni.Models.Settings.Base;
using PepperlFuchs.IE.TE.IniFile;


namespace PepperlFuchs.IE.TE.WinConfigIni.Models.Settings
{
    internal class Beeprog
    {
        [Base.Parameter("ITEM", "")]
        public uint Item { get; init; }

        [Base.Parameter("APPLICATION", "")]
        public string Application { get; set; }
        [Base.Parameter("LOGFILE", "")]
        public string LogFile { get; set; }
        [Base.Parameter("VERIFYFILE", "")]
        public string VerifyFile {  get; set; } 


        public Beeprog(Section section)
        {
            Item = Base.Tools.GetItem(section.SectionName);
            if (section == null) throw new ArgumentNullException(nameof(section));
            Type classType = typeof(Beeprog);
            if (classType is not null)
            {
                Base.Tools.ReadInProperties(this, classType, section.ParameterList);
            }

        }
        public override string ToString()
        {
            Type type = typeof(Beeprog);
            return Base.Tools.SerialisationToIni(type);
        }
    }
}
