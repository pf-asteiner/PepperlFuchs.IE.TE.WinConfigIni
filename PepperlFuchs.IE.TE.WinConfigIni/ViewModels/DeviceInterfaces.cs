﻿using PepperlFuchs.IE.TE.WinConfigIni.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepperlFuchs.IE.TE.WinConfigIni.ViewModels
{
    internal class DeviceInterfaces
    {
        public ObservableCollection<InterfaceSetting>? Interfaces { get; set; }
    }
}
