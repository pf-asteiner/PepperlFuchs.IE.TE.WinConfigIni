using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PepperlFuchs.IE.TE.IniFile;
using PepperlFuchs.IE.TE.WinConfigIni;
using PepperlFuchs.IE.TE.WinConfigIni.Models;


namespace PepperlFuchs.IE.TE.WinconfigIni.Gui
{
    public class WinConfigIniFacility
    {
        private List<string> _listSettingNames = new();
        public List<GlobalSection>? globals { get; init; }
        public List<GlobalSection>? globalsDebug { get; init; }
        public List<GlobalSection>? globalsManual { get; init; }
        //public Drivers? drivers { get; init; }
        //public Drivers? driversDebug { get; init; }
        //public Drivers? driversManual { get; init; }
        public List<object>? settings { get; init; }
        public List<InterfaceSetting>? settingsDebug { get; init; }
        public List<InterfaceSetting>? settingsManual { get; init; }

        public List<string> ListSettingNames { get { return _listSettingNames; } }

        public WinConfigIniFacility(string PathToFiles)
        {
            // IniFile.IniFile winConfigDrivers = new(PathToFiles+@"\Win_Config_Drivers.ini");

            //  drivers = new(winConfigDrivers);

            IniFile.IniFile winConfigSettings = new(PathToFiles + @"\Win_Config_Settings.ini");
            settings = new List<object>();

            foreach (var sb in winConfigSettings.SectionsBlocks)
            {
                foreach (var section in sb.Sections)
                {
                    try
                    {
                        settings.Add(WinConfigIniFile.ConvertSectionToSetting(section));
                    }
                    catch (Exception)
                    {

                        throw;
                    }


                    var cla = settings.LastOrDefault();
                    if (cla != null)
                    {
                        string name = cla.GetType().Name;
                        _listSettingNames.Add(name);
                    }
                }
            }
        }
    }
}
