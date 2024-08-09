using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PepperlFuchs.IE.TE.IniFile;

namespace PepperlFuchs.IE.TE.WinConfigIni.Models
{
    public class RelationInterfaceDeviceSlot
    {
        private const string name = "RELATION_INTERFACE_DEVICE_SLOT";
        private const string device = "Device";
        private const string slotdevice = "SlotDevice";
        private const string slotinterface = "SlotInterface";

        public string Name { get { return name + "_" + Number.ToString(); } }
        public int Number {  get; set; }
        public string SlotDevice { get; set; } = string.Empty;
        public string SlotInterface { get; set; } = string.Empty;

        public RelationInterfaceDeviceSlot(Section section)
        {
            if (section == null) throw new ArgumentNullException("section");
            if (!section.SectionName.Contains(name))
            {
                throw new Exception("Secction isn't an Interface Card");
            }

            var number = section.SectionName.Substring(section.SectionName.LastIndexOf("_") + 1);

            Number = Convert.ToInt32(number);

            foreach (var parameter in section.ParameterList)
            {
                if (parameter.Name == device)
                {
                    SlotDevice = parameter.Value;
                    break;
                }
            }
            foreach (var parameter in section.ParameterList)
            {
                if (parameter.Name == SlotDevice)
                {
                    SlotDevice = parameter.Value;
                    break;
                }
            }

            foreach (var parameter in section.ParameterList)
            {
                if (parameter.Name == slotinterface)
                {
                    SlotInterface = parameter.Value;
                    break;
                }
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[" + name + "_" + Number.ToString() + "]" + Environment.NewLine);
            sb.Append(device + " = " + device + Environment.NewLine);
            sb.Append(slotdevice + " = " + SlotDevice + Environment.NewLine);
            sb.Append(slotinterface + " = " + SlotInterface + Environment.NewLine);
            sb.Append(Environment.NewLine);
            return sb.ToString();
        }
    }
}
