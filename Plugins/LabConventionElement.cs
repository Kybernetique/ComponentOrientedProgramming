﻿using Plugins.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins
{
    public class LabConventionElement : PluginsConventionElement
    {
        public string Subject { get; set; }

        public string Topic { get; set; }

        public string Questions { get; set; }
    }
}
