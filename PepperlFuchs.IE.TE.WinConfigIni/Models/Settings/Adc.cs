using PepperlFuchs.IE.TE.IniFile;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PepperlFuchs.IE.TE.WinConfigIni.Models.Settings
{
    public class Adc
    {
        [Base.Parameter("ITEM", "")]
        public uint Item { get; init; }

        [Base.Parameter("AD_RANGE", "")]
        public uint AdRange { get; set; }

        [Base.Parameter("SAMPLE_COUNT", "")]
        public uint SampleCount { get; set; }

        [Base.Parameter("SAMPLE_RATE", "")]
        public double SampleRate { get; set; }
        [Base.Parameter("TRIG_DELAY", "")]
        public int TriggerDelay { get; set; }
        [Base.Parameter("TRIG_LEV", "")]
        public double TriggerLevel { get; set; }
        [Base.Parameter("TRIG_MOD", "")]
        public int TriggerMode { get; set; }
        [Base.Parameter("TRIG_SLP", "")]
        public int TriggerSlp { get; set; }
        [Base.Parameter("TRIG_SRC", "")]
        public int TriggerSrc { get; set; }

        public Adc(Section section)
        {
            Item = Base.Tools.GetItem(section.SectionName);
            if (section == null) throw new ArgumentNullException(nameof(section));
            Type classType = typeof(Adc);
            if (classType is not null)
            {
                Base.Tools.ReadInProperties(this, classType, section.ParameterList);
                //Base.Tools.ReadInParameters(this, classType, section.ParameterList);
            }

        }
        public override string ToString()
        {
            Type type = typeof(Adc);
            return Base.Tools.SerialisationToIni(type);
        }
    }
}
