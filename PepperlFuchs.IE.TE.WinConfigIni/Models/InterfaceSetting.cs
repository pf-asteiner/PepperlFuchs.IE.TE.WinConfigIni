using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using PepperlFuchs.IE.TE.IniFile;
using PepperlFuchs.IE.TE.WinConfigIni.Models.Settings.Base;

namespace PepperlFuchs.IE.TE.WinConfigIni.Models
{
    public class InterfaceSetting
    {
    
        public string Name { get; set; }
        public int Number { get; set; }
        public List<KeyValuePair<string, string>> Parameters { get; set; }
        public InterfaceSetting(Section section)
        {
            if (section.ParameterList.Count == 0)
            {
                throw new Exception("The section: " + section.SectionName + " has no parameter!");
            }
            Parameters = new List<KeyValuePair<string, string>>();

            Name = section.SectionName.Substring(0, section.SectionName.IndexOf("_"));

            switch (Name)
            {
                case "Adc":

                    SetAdc(section);
                    break;
                case "ADS":
                    SetAds(section);
                    break;
                case "ANALOG_IO":
                    SetAnalog(section);
                    break;
                case "ASI":
                    SetAsi(section);
                    break;
                case "BALANCE":
                    SetBalance(section);
                    break;
                case "BAROMETER":
                    SetBarometer(section);
                    break;
                case "BEEPROG":
                    SetBeeprog(section);
                    break;
                case "BOUNDARYSCAN":
                    SetBoundaryScan(section);
                    break;
                case "CALB":
                    SetCalb(section);
                    break;
                case "CAM":
                    SetCam(section);
                    break;
                case "CANBUS":
                    SetCanbus(section);
                    break;
                case "CC_LINK_COM":
                    SetCcLinkCom(section);
                    break;
                case "CLIMATE_CHAMBER":
                    SetClimateChamber(section);
                    break;
                case "COM":
                    SetCom(section);
                    break;
                case "DIO":
                    SetDio(section);
                    break;
                case "DIRECTXCAM":
                    SetDirectxCam(section);
                    break;
                case "DMM":
                    SetDmm(section);
                    break;
                case "ECODRIVECS_INI_PATH":
                    SetEcodriveceIniPath(section);
                    break;
                case "EDM":
                    SetEdm(section);
                    break;
                case "EMS":
                    SetEms(section);
                    break;
                case "ENGINEERING_MODE":
                    SetEngineeringMode(section);
                    break;
                case "ESS_CONTROLLER":
                    SetEssController(section);
                    break;
                case "ETHERCAT":
                    SetEthercat(section);
                    break;
                case "ETHERNET":
                    SetEthernet(section);
                    break;
                case "FAIL_SAFE_PLC":
                    SetFailSafePlc(section);
                    break;
                case "FGEN":
                    SetFgen(section);
                    break;
                case "GPIB":
                    SetGpio(section);
                    break;
                case "HART_COM":
                    SetHartCom(section);
                    break;
                case "HYGRO":
                    SetHygro(section);
                    break;
                case "I2C_COM":
                    SetI2cCom(section);
                    break;
                case "IDENT_MASTER":
                    SetIdentMaster(section);
                    break;
                case "IOLINK_COM":
                    SetIoLinkCom(section);
                    break;
                case "LASERPOWERMONITOR":
                    SetLaserPowerMonitor(section);
                    break;
                case "LASERSYSTEMS_LS8000":
                    SetLasersystemsLs8000(section);
                    break;
                case "LASERSYSTEMS_LSE":
                    SetLasersystemsLse(section);
                    break;
                case "LBFB_GATEWAY":
                    SetLbfbGateway(section);
                    break;
                case "LINEAR_MEASUREMENT":
                    SetLinearMeasurement(section);
                    break;
                case "LINEAR_MOVE":
                    SetLinearMove(section);
                    break;
                case "LOAD":
                    SetLoad(section);
                    break;
                case "MASTER_CARD":
                    SetMaserCard(section);
                    break;
                case "MATRIX_CODE_SCANNER":
                    SetMatrixCodeScanner(section);
                    break;
                case "MODBUS":
                    SetModbus(section);
                    break;
                case "OPTOOUT":
                    SetOptoOut(section);
                    break;
                case "OPTO":
                    SetOpto(section);
                    break;
                case "OSC":
                    SetOsc(section);
                    break;
                case "PARAL":
                    SetParal(section);
                    break;
                case "PAX_SSPP_COM":
                    SetPaxSsppCom(section);
                    break;
                case "PB":
                    SetPb(section);
                    break;
                case "PM":
                    SetPm(section);
                    break;
                case "POW":
                    SetPow(section);
                    break;
                case "PRESSURECONTROLLER":
                    SetPressurecontroller(section);
                    break;
                case "PRINT":
                    SetPrint(section);
                    break;
                case "PROFINET_DCP":
                    SetIp(section);
                    break;
                case "RDEC":
                    SetRdec(section);
                    break;
                case "RELAY":
                    SetRelay(section);
                    break;
                case "REMOTE_DOOR":
                    SetIp(section);
                    break;
                case "RS232_COM":
                    SetCom(section);
                    break;
                case "SAMS":
                    SetSams(section);
                    break;
                case "SIAT":
                    SetCom(section);
                    break;
                case "SINK":
                    SetCom(section);
                    break;
                case "SPECTRUM_ANALYZER":
                    SetIp(section);
                    break;
                case "SSPP_COM":
                    SetCom(section);
                    break;
                case "TID":
                    SetTid(section);
                    break;
                case "TRIMMING_LASER":
                    SetCom(section);
                    break;
                case "UV_SOURCE":
                    SetCom(section);
                    break;
                case "VISION":
                    SetVision(section);
                    break;
                case "VISION_SOFTWARE":
                    SetVisionSoftware(section);
                    break;
                case "WPAN_COM":
                    SetCom(section);
                    break;

                default:
                    throw new Exception("Devoice setting for " + Name + " dosn't exist!");
            }
        }
        private void SetAdc(Section section)
        {

            foreach (SectionParameter parameter in section.ParameterList)
            {
                //if (parameter.Name == Defines.adRange |
                //      parameter.Name == sampleCount |
                //    parameter.Name == sampelRate |
                //    parameter.Name == trigDelay |
                //    parameter.Name == trigLev |
                //    parameter.Name == trigMod |
                //    parameter.Name == trigSlp |
                //    parameter.Name == trigSrc)
                //{
                //    Parameters.Add(new KeyValuePair<string, string>(parameter.Name, parameter.Value));
                //}
                //else
                //{
                //    throw new Exception("At moment is the Parameter: " + parameter.Name + " not allowed!");
                //}
            };
        }

        private void SetAds(Section section)
        {
            foreach (SectionParameter parameter in section.ParameterList)
            {
                //if (parameter.Name == fc5101Boradindes |
                //    parameter.Name == fc5101Timeout)
                //{
                //    Parameters.Add(new KeyValuePair<string, string>(parameter.Name, parameter.Value));
                //}
                //else
                //{
                //    throw new Exception("At moment is the Parameter: " + parameter.Name + " not allowed!");
                //}
            };
        }
        private void SetAnalog(Section section)
        {
            SetIp(section);
        }
        private void SetAsi(Section section)
        {
            SetCom  (section);
        }
        private void SetBalance(Section section)
        {
            SetCom(section);
        }
        private void SetBarometer(Section section)
        {
            SetIp(section);
        }
        private void SetCom(Section section) { 
            throw new NotImplementedException(); }
        private void SetIp(Section section) { throw new NotImplementedException(); }
        private void SetBeeprog(Section section) { throw new NotImplementedException(); }
        private void SetBoundaryScan(Section section) { throw new NotImplementedException(); }
        private void SetCalb(Section section) { throw new NotImplementedException(); }
        private void SetCam(Section section) { throw new NotImplementedException(); }
        private void SetCanbus(Section section) { throw new NotImplementedException(); }

        private void SetCcLinkCom(Section section) { throw new NotImplementedException(); }

        private void SetClimateChamber(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetDio(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetDirectxCam(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetDmm(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetEcodriveceIniPath(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetEdm(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetEms(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetEngineeringMode(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetEssController(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetEthercat(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetEthernet(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetFailSafePlc(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetFgen(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetGpio(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetHartCom(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetHygro(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetI2cCom(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetIdentMaster(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetIoLinkCom(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetLaserPowerMonitor(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetLasersystemsLs8000(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetLasersystemsLse(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetLbfbGateway(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetLinearMeasurement(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetSams(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetLinearMove(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetLoad(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetMaserCard(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetMatrixCodeScanner(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetModbus(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetOptoOut(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetOpto(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetOsc(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetParal(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetPaxSsppCom(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetPb(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetPm(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetPow(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetPressurecontroller(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetPrint(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetRdec(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetRelay(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetTid(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetVision(Section section)
        {
            throw new NotImplementedException();
        }

        private void SetVisionSoftware(Section section)
        {
            throw new NotImplementedException();
        }
    }
}
