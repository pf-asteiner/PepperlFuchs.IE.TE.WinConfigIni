using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PepperlFuchs.IE.TE.WinConfigIni.Models.Settings.Base
{
    public class Defines
    {
        #region SectionNames
        public const string adc = "ADC";
        public const string ads = "ADS";
        public const string analogIo = "ANALOG_IO";
        public const string asi = "ASI";
        public const string balacnce = "BALANCE";
        public const string barometer = "BAROMETER";
        public const string beeprog = "BEEPROG";
        public const string boundaryScan = "BOUNDARYSCAN";
        public const string calb = "CALB";
        public const string cam = "CAM";
        public const string canBus = "CANBUS";
        public const string ccLInkCom = "CC_LINK_COM";
        public const string climateChamber = "CLIMATE_CHAMBER";
        public const string com = "COM";
        public const string dio = "DIO";
        public const string directcCam = "DIRECTXCAM";
        public const string dmm = "DMM";
        public const string ccodrivesIniPath = "ECODRIVECS_INI_PATH";
        public const string edm = "EDM";
        public const string ems = "EMS";
        public const string engineeringMode = "ENGINEERING_MODE";
        public const string essController = "ESS_CONTROLLER";
        public const string etherCat = "ETHERCAT";
        public const string etherNet = "ETHERNET";
        public const string vailSavePlc = "FAIL_SAFE_PLC";
        public const string fGen = "FGEN";
        public const string gpib = "GPIB";
        public const string hartCom = "HART_COM";
        public const string hygro = "HYGRO";
        public const string i2cCom = "I2C_COM";
        public const string identMaster = "IDENT_MASTER";
        public const string ioLinkCom = "IOLINK_COM";
        public const string laserPowerMonitor = "LASERPOWERMONITOR";
        public const string lasersystemsLs8000 = "LASERSYSTEMS_LS8000";
        public const string lasersystemsLse = "LASERSYSTEMS_LSE";
        public const string lbfbGateway = "LBFB_GATEWAY";
        public const string linearMoesurement = "LINEAR_MEASUREMENT";
        public const string linearMove = "LINEAR_MOVE";
        public const string load = "LOAD";
        public const string masterCard = "MASTER_CARD";
        public const string matrixCodeScanner = "MATRIX_CODE_SCANNER";
        public const string modBus = "MODBUS";
        public const string optoOut = "OPTOOUT";
        public const string opto = "OPTO";
        public const string osc = "OSC";
        public const string paral = "PARAL";
        public const string paxSsppCom = "PAX_SSPP_COM";
        public const string pb = "PB";
        public const string pm = "PM";
        public const string pow = "POW";
        public const string presureController = "PRESSURECONTROLLER";
        public const string print = "PRINT";
        public const string profinetDcp = "PROFINET_DCP";
        public const string rdec = "RDEC";
        public const string relay = "RELAY";
        public const string remoteDoor = "REMOTE_DOOR";
        public const string rs232Com = "RS232_COM";
        public const string sams = "SAMS";
        public const string siat = "SIAT";
        public const string sink = "SINK";
        public const string sprectrumAnalyzer = "SPECTRUM_ANALYZER";
        public const string ssppCom = "SSPP_COM";
        public const string tid = "TID";
        public const string trimmingLaser = "TRIMMING_LASER";
        public const string uvSource = "UV_SOURCE";
        public const string vision = "VISION";
        public const string visionSoftware = "VISION_SOFTWARE";
        public const string wpanCom = "WPAN_COM";
        #endregion


        #region Parameter names
        #region A
        public readonly string adRange = "AD_RANGE";
        public const string application = "APPLICATION";
        #endregion

        #region B 

        #endregion

        #region C
        public const string captruePath = "CAPTURE_PATH";
        public const string casconDllpath = "CASCON_DLLPATH";
        public const string casconResltpath = "CASCON_RESULTPATH";
        public const string casconRootpath = "CASCON_ROOTPATH";
        public const string casconUsername = "CASCON_USERNAME";

        public const string channel = "CHANNEL";
        public const string comAdr = "COM_ADR";
        public const string comBaud = "COM_BAUD";
        public const string comBuffer = "COM_BUFFER";
        public const string comBytesize = "COM_BYTESIZE";
        public const string comParity = "COM_PARITY";
        public const string comProtocoll = "COM_PROTOKOLL";
        public const string comStopbits = "COM_STOPBITS";
        #endregion

        #region D
        public const string dbconnectAliasname = "DBCONNECT_ALIASNAME";
        public const string dbconnectPassword = "DBCONNECT_PASSWORD";
        public const string dbconnectSchema = "DBCONNECT_SCHEMA";
        public const string dbconnectUsername = "DBCONNECT_USERNAME";

        #endregion
        #region E
        public const string exposuretimeDefault = "EXPOSURETIME_DEFAULT";
        #endregion
        #region F
        public const string fc5101Boradindes = "FC5101_BOARDINDEX";
        public const string fc5101Timeout = "FC5101_TIMEOUT";

        #endregion

        #region I
        public const string ipAddress = "IP_ADDRESS";
        public const string ipAddressPc = "IP_ADDRESS_PC";
        public const string ipSubnetmaskPc = "IP_SUBNETMASK_PC";
        #endregion

        #region L
        public const string logFile = "LOGFILE";

        #endregion

        #region P
        public const string path_ToVpp = "PATH_TO_VPP";
        public const string password = "PASSWORD";
        public const string picName = "PIC_NAME";
        #endregion

        #region S
        public const string sampleCount = "SAMPLE_COUNT";
        public const string sampelRate = "SAMPLE_RATE";
        public const string showPic = "SHOW_PIC";
        public const string speed = "SPEED";
        public const string subType = "SUB_TYPE";

        #endregion

        #region T
        public const string tcpPort = "TCP_PORT";
        public const string trigDelay = "TRIG_DELAY";
        public const string trigLev = "TRIG_LEV";
        public const string trigMod = "TRIG_MOD";
        public const string trigSlp = "TRIG_SLP";
        public const string trigSrc = "TRIG_SRC";
        public const string type = "TYPE";
        #endregion

        #region V
        public const string privateFile = "VERIFYFILE";

        #endregion


        #endregion

        #region Com
        /// <summary>
        /// Type of parity check
        /// </summary>
        public enum Parity
        {
            NOPARITY = 0,
            ODDPARITY = 1,
            EVENPARITY = 2,
            MARKPARITY = 3,
            SPACEPARITY = 4
        }

        /// <summary>
        /// Number of Stopbits
        /// </summary>
        public enum Stopbit
        {
            ONESTOPBIT = 0,
            ONE5STOPBITS = 1,
            TWOSTOPBITS = 2
        }

        public enum HwHandshake
        {
            HW_HANDSHAKE_OFF = 0,
            HW_HANDSHAKE_CTS_RTS_DTR = 1,
            HW_HANDSHAKE_CTS_RTS = 2
        }

        #endregion
    }
}
