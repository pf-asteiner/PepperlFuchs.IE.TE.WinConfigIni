using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PepperlFuchs.IE.TE.IniFile;

namespace PepperlFuchs.IE.TE.WinConfigIni.Models
{
    public class RelationInterfaceCard
    {
        private const string name = "RELATION_INTERFACE_CARD";
        private const string card = "Card";
        private const string slotinterface = "SlotInterface";
        public int Number { get; set; }
        public string Card { get; set; } = string.Empty;
        public string SlotInterface { get; set; } = string.Empty ;

        public RelationInterfaceCard(Section section)
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
                if (parameter.Name == card)
                {
                    Card = parameter.Value;
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
            sb.Append(card + " = " + Card + Environment.NewLine);
            sb.Append(slotinterface + " = " + SlotInterface + Environment.NewLine);
            sb.Append(Environment.NewLine);
            return sb.ToString();
        }
    }
}
