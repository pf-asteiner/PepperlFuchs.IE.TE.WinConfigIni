using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepperlFuchs.IE.TE.WinConfigIni.Models.Settings.Base
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false )]
    public sealed class ParameterAttribute : Attribute
    {
        private readonly string keyWord;
        private readonly string description;
        private readonly uint? minValue;
        private readonly uint? maxValue;

        public ParameterAttribute(string KeyWord, string Decription)
        {
           this . keyWord = KeyWord;
           this. description = Decription;
        }

        public ParameterAttribute(string KeyWord, string Decription, uint MinValue, uint MaxValue)
        {
            keyWord = KeyWord;
            description = Decription;
            minValue = MinValue;
            maxValue = MaxValue;
        }

        public string GetKeyWord() => keyWord;
        public string GetDescription() => description;
        public uint? GetMinValue() => minValue;
        public uint? GetMaxValue() => maxValue;
    }
}
