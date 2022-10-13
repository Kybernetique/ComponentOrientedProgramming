using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonVisualComponents
{
    public partial class HistogramWord : Component
    {
        public HistogramWord()
        {
            InitializeComponent();
        }

        public HistogramWord(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
