using PepperlFuchs.IE.TE.WinConfigIni.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PepperlFuchs.IE.TE.IniFile;
using PepperlFuchs.IE.TE.WinConfigIni.Models.Settings;
using PepperlFuchs.IE.TE.WinConfigIni.Db;
using PepperlFuchs.IE.TE.WinConfigIni.Models.Settings.Base;
using System.Security.Cryptography;
using System.Diagnostics;


namespace PepperlFuchs.IE.TE.WinConfigIni
{
    public class WinConfigIniFile
    {
        public bool Debuging { get; set; } = false;
        Settings? GlobalSettings { get; set; } = null;
        DeviceInterfaces? DeviceInterfaces { get; set; } = null;
        Drivers? Drivers { get; set; } = null;

        public WinConfigIniFile(string PathTo, bool Debugging)
        {
            this.Debuging = Debugging;

            IniFile.IniFile iniFile = new(PathTo);


            GlobalSettings = new Settings();
            DeviceInterfaces = new DeviceInterfaces();
            Drivers = new Drivers();
        }

        public static object? ConvertSectionToSetting(Section section)
        {
            if (section == null)
            {
                return null;
            }
            string secName = string.Empty;

            string[] sectionNameParts = section.SectionName.Split("_");

            if(int.TryParse(sectionNameParts.Last(),out int i))
            {
                for (int j = 0; j < sectionNameParts.Length-1; j++)
                {
                    secName += sectionNameParts[j] + "_";
                }
                secName = secName.Substring(0, secName.Length - 1);
            }
            else 
            {
                secName= section.SectionName;
            }

            if (!WinAtsData.SectionNameList.Contains(secName))
            {
                throw new InvalidOperationException("Section Name: " + section.SectionName + " is not allowed!");
            }

            switch (secName)
            {
                case Defines.adc:
                    return new Adc(section);
                case Defines.ads:
                    return new Ads(section);
                case Defines.analogIo:
                    return new Analog(section);
                case Defines.asi:
                    return new Asi(section);
                case Defines.balacnce:
                    return new Balance(section);
                case Defines.barometer:
                    return new Barometer(section);
                case Defines.beeprog:
                    return new Beeprog(section);
                case Defines.boundaryScan:
                   return new BoundaryScan(section);
                case Defines.calb:
                    return new Calb(section);
                case Defines.cam:
                    return new Cam(section);
                case Defines.canBus:
                    return new CanBus(section);
                case Defines.ccLInkCom:
                    return new CcLinkCom(section);
                //case Defines.climateChamber:
                //    return new (section);
                //case Defines.com:
                //    return new Ads(section);
                //case Defines.dio:
                //    return new Ads(section);
                //case Defines.directcCam:
                //    return new Ads(section);
                //case Defines.dmm:
                //    return new Ads(section);
                //case Defines.ccodrivesIniPath:
                //    return new Ads(section);
                //case Defines.edm:
                //    return new Ads(section);
                //case Defines.ems:
                //    return new Ads(section);
                //case Defines.engineeringMode:
                //    return new Ads(section);
                //case Defines.essController:
                //    return new Ads(section);
                //case Defines.etherCat:
                //    return new Ads(section);
                //case Defines.etherNet:
                //    return new Ads(section);
                //case Defines.vailSavePlc:
                //    return new Ads(section);
                //case Defines.fGen:
                //    return new Ads(section);
                //case Defines.gpib:
                //    return new Ads(section);
                //case Defines.hartCom:
                //    return new Ads(section);
                //case Defines.hygro:
                //    return new Ads(section);
                //case Defines.i2cCom:
                //    return new Ads(section);
                //case Defines.identMaster:
                //    return new Ads(section);
                //case Defines.ioLinkCom:
                //    return new Ads(section);
                //case Defines.laserPowerMonitor:
                //    return new Ads(section);
                //case Defines.lasersystemsLs8000:
                //    return new Ads(section);
                //case Defines.lasersystemsLse:
                //    return new Ads(section);
                //case Defines.lbfbGateway:
                //    return new Ads(section);
                //case Defines.linearMoesurement:
                //    return new Ads(section);
                //case Defines.linearMove:
                //    return new Ads(section);
                //case Defines.load:
                //    return new Ads(section);
                //case Defines.masterCard:
                //    return new Ads(section);
                //case Defines.matrixCodeScanner:
                //    return new Ads(section);
                //case Defines.modBus:
                //    return new Ads(section);
                //case Defines.optoOut:
                //    return new Ads(section);
                //case Defines.opto:
                //    return new Ads(section);
                //case Defines.osc:
                //    return new Ads(section);
                //case Defines.paral:
                //    return new Ads(section);
                //case Defines.paxSsppCom:
                //    return new Ads(section);
                //case Defines.pb:
                //    return new Ads(section);
                //case Defines.pm:
                //    return new Ads(section);
                //case Defines.pow:
                //    return new Ads(section);
                //case Defines.presureController:
                //    return new Ads(section);
                //case Defines.print:
                //    return new Ads(section);
                //case Defines.profinetDcp:
                //    return new Ads(section);
                //case Defines.rdec:
                //    return new Ads(section);
                //case Defines.relay:
                //    return new Ads(section);
                //case Defines.remoteDoor:
                //    return new Ads(section);
                //case Defines.rs232Com:
                //    return new Ads(section);
                //case Defines.sams:
                //    return new Ads(section);
                //case Defines.siat:
                //    return new Ads(section);
                //case Defines.sink:
                //    return new Ads(section);
                //case Defines.sprectrumAnalyzer:
                //    return new Ads(section);
                //case Defines.ssppCom:
                //    return new Ads(section);
                //case Defines.tid:
                //    return new Ads(section);
                //case Defines.trimmingLaser:
                //    return new Ads(section);
                //case Defines.uvSource:
                //    return new Ads(section);
                //case Defines.vision:
                //    return new Ads(section);
                //case Defines.visionSoftware:
                //    return new Ads(section);
                //case Defines.wpanCom:
                //    return new Ads(section);
                default:
                break;
                    //    throw new Exception ("Ther given't a class for: " + section.SectionName);
            }
            return null;
        }
    }
}
