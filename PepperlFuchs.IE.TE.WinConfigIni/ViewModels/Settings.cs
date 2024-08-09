using PepperlFuchs.IE.TE.WinConfigIni.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepperlFuchs.IE.TE.WinConfigIni.ViewModels
{
    public  class Settings
    {
        public ObservableCollection<GlobalSection>? Sections { get; set; }
    }
}
