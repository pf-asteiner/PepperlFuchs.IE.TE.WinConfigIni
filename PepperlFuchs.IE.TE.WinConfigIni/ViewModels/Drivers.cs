using PepperlFuchs.IE.TE.WinConfigIni.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepperlFuchs.IE.TE.WinConfigIni.ViewModels
{
    internal class Drivers
    {
        public ObservableCollection<RelationInterfaceCard>? InterfaceCards { get; set; }
        public ObservableCollection<RelationInterfaceDeviceSlot>? Interfaces { get; set; }
    }
}
