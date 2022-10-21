using Components.AlexandrovComponents.HelperEnums;
using Components.AlexandrovComponents.HelperModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.AlexandrovComponents
{
    public partial class LinearDiagramExcelComponent : Component
    {
        public LinearDiagramExcelComponent()
        {
            InitializeComponent();
        }

        public LinearDiagramExcelComponent(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        public void Save(string fileName, string title, string titleDiagram, ExcelLegendPosition legendPosition,
            Dictionary<string, int[]> data, Tuple<double, double> axisProperties = null)
        {
            if (String.IsNullOrEmpty(fileName) || String.IsNullOrEmpty(title) || String.IsNullOrEmpty(titleDiagram) || data == null)
            {
                throw new ArgumentException();
            }
            if (data.Count == 0) throw new ArgumentException();

            CreateFile(fileName, title, titleDiagram, legendPosition, data, axisProperties);
        }

        private void CreateFile(string fileName, string title, string titleDiagram, ExcelLegendPosition legendPosition,
            Dictionary<string, int[]> data, Tuple<double, double> axisProperties)
        {
            ExcelCreator ec = new ExcelCreator();
            ec.CreateExcel(fileName);

            ec.InsertCellInWorksheet(new ExcelCellParameters
            {
                ColumnName = "A",
                RowIndex = 1,
                Text = title,
                StyleInfo = ExcelStyleInfoType.Title
            });

            ec.CreateLineChart(titleDiagram, legendPosition, data, axisProperties);

            ec.SaveExcel();
        }
    }
}
