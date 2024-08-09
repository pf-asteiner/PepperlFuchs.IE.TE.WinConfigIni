using PepperlFuchs.IE.TE.WinConfigIni.Models.Settings.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PepperlFuchs.IE.TE.IniFile;

namespace PepperlFuchs.IE.TE.WinConfigIni.Models.Settings
{
    internal class ClimateChamber
    {
        [Base.Parameter("ITEM", "")]
        public uint Item { get; init; }
        ///// <summary>
        ///// Settings for communicate over a serial com port
        ///// </summary>
        [Parameter("Com port", "communication over a Com Port")]
        public ComSetting Com { get; set; } = new ComSetting();

        public ClimateChamber(Section section)
        {
        
        }
    }
}
