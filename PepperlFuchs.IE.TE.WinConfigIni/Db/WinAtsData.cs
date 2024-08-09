using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepperlFuchs.IE.TE.WinConfigIni.Db
{
    public static class WinAtsData
    {
        public static List<string> ParameterList
        {
            get
            {
                using (var db = new WinConfigIniTableAdapters.WinConfigParameterNamesTableAdapter())
                {
                    List<string> list = new List<string>();
                    foreach (var item in db.GetData())
                    {
                        list.Add(item.ParameterName.ToString());
                    }
                    return list;
                }
            }
        }

        public static List<string> SectionNameList
        {
            get
            {
                using (var db = new WinConfigIniTableAdapters.WinConfigSektionsNameTableAdapter())
                {
                    List<string> list = new List<string>();
                    foreach (var item in db.GetData())
                    {
                        list.Add(item.SektionsName.ToString());
                    }
                    return list;
                }
            }
        }
    }
}
