﻿using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinCustomUI.Models
{
    public class AccordianViewDemoModel
    {
        public string Title { get; set; }
        public List<XamarinCustomUI.Models.Item> AttachedEquipments { get; set; } = new List<XamarinCustomUI.Models.Item>();

    }
}
