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
    public partial class BigTextExcelComponent : Component
    {
        public BigTextExcelComponent()
        {
            InitializeComponent();
        }

        public BigTextExcelComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void Save(string fileName, string title, string[] text)
        {
            if (String.IsNullOrEmpty(fileName) || String.IsNullOrEmpty(title) || text.Length == 0)
            {
                throw new ArgumentException();
            }

            CreateFile(fileName, title, text);
        }

        private void CreateFile(string fileName, string title, string[] text)
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

            uint rowIndex = 3;
            foreach (var paragrapf in text)
            {
                ec.InsertCellInWorksheet(new ExcelCellParameters
                {
                    ColumnName = "A",
                    RowIndex = rowIndex,
                    Text = paragrapf,
                    StyleInfo = ExcelStyleInfoType.Text
                });

                rowIndex++;
            }

            ec.SaveExcel();
        }
    }
}
