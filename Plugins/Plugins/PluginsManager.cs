using Plugins.Plugins;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins
{
    public class PluginsManager
    {
        [ImportMany(typeof(IPluginsConvention))]
        IEnumerable<IPluginsConvention> Plugins { get; set; }

        public readonly Dictionary<string, IPluginsConvention> dictionary 
            = new Dictionary<string, IPluginsConvention>();

        public PluginsManager()
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory));
            catalog.Catalogs.Add(new DirectoryCatalog(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins")));

            CompositionContainer container = new CompositionContainer(catalog);
            container.ComposeParts(this);
            if (Plugins.Count() != 0)
            {
                Plugins.ToList()
                    .ForEach(p => { if (!dictionary.Keys.Contains(p.PluginName)) dictionary.Add(p.PluginName, p); });
            }
        }
    }
}
