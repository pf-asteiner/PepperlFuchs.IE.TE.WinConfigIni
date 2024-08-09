using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PepperlFuchs.IE.TE.WinConfigIni.Models
{
    public class Thread
    {
        public string  Name { get; init; }
        public bool Start { get; set; } = false;
        public List<string>? WaitingFor { get;}

        public Thread(string Name)
        {
            this.Name = Name;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[");
            stringBuilder.Append(Name);
            stringBuilder.Append("]" + Environment.NewLine);
            stringBuilder.Append(" THREAD_START = ");
            if (Start)
            {
                stringBuilder.Append('1');
            }
            else
            {
                stringBuilder.Append("0");
            }

            if (WaitingFor != null)
            {
                stringBuilder.Append(" WAIT_FOR = ");
                foreach (string str in WaitingFor)
                {
                    stringBuilder.Append(str);
                }
            }
            return stringBuilder.ToString();
        }
    }
}
