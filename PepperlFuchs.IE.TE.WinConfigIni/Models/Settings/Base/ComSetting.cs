using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PepperlFuchs.IE.TE.WinConfigIni.Models.Settings.Base;
using static PepperlFuchs.IE.TE.WinConfigIni.Models.Settings.Base.Defines;

namespace PepperlFuchs.IE.TE.WinConfigIni.Models.Settings.Base
{
    public class ComSetting
    {
        /// <summary>
        /// Addres of Com Port
        /// </summary>
        [Parameter("COM_ADR", "Com Port", 1, 100)]
        public uint Address { get; set; }
        /// <summary>
        /// Baudrate for communication
        /// </summary>
        [Parameter("COM_BAUD", "Baudrate for communication")]
        public uint Baudrate { get; set; }
        /// <summary>
        /// Size of Send- and Receive Buffer of Com Port
        /// </summary>
        [Parameter("COM_BUFFER", "Size of Send- and Receive buffer")]
        public uint BufferSize { get; set; }
        /// <summary>
        /// Number of bytes of data telegram
        /// </summary>
        [Parameter("COM_BYTESIZE", "Byte length of telegram")]
        public uint ByteSize { get; set; }
        /// <summary>
        /// Type of parity check <see cref="Parity"/>
        /// </summary>
        [Parameter("COM_PARITY", "Parity check")]
        public Defines.Parity ParityCheck { get; set; }
        /// <summary>
        /// Type of communication protocol
        /// </summary>
        [Parameter("COM_PROTOKOLL", "Type of communication protocol")]
        public Defines.HwHandshake Protocol { get; set; }
        /// <summary>
        /// number of Stop bits <see cref="Stopbit"/>
        /// </summary>
        [Parameter("COM_STOPBITS", "How many stopbits will use")]
        public Defines.Stopbit StopBits { get; set; }
    }
}
