using Components.AlexandrovComponents.HelperEnums;
using Components.AlexandrovComponents.HelperModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Components.AlexandrovComponents
{
    public partial class TableExcelComponent : Component
    {
        public TableExcelComponent()
        {
            InitializeComponent();
        }

        public TableExcelComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void Save<T>(string fileName, string title, ExcelTableHeaderBlockParameters[] headerParameters, List<T> data)
        {
            if (String.IsNullOrEmpty(fileName) || String.IsNullOrEmpty(title) || headerParameters.Length == 0 ||
                headerParameters.Any(rec => rec.RowCount < 1) || data.Count == 0)
            {
                throw new ArgumentException();
            }

            Type type = data[0].GetType();
            PropertyInfo[] properties = type.GetProperties();
            FieldInfo[] fields = type.GetFields();
            foreach (ExcelTableHeaderBlockParameters block in headerParameters)
            {
                if (block.RowCount == 1)
                {
                    if (!properties.Any(rec => String.Equals(rec.Name, block.titleFirstRow.properyName)) &&
                        !fields.Any(rec => String.Equals(rec.Name, block.titleFirstRow.properyName)))
                        throw new ArgumentException();
                }
                else
                {
                    foreach (ExcelTableHeaderCellProperties cell in block.titlesSecondRow)
                        if (!properties.Any(rec => String.Equals(rec.Name, cell.properyName)) &&
                            !fields.Any(rec => String.Equals(rec.Name, cell.properyName)))
                            throw new ArgumentException();
                }
            }

            CreateFile(fileName, title, headerParameters, data);
        }

        public void CreateFile<T>(string fileName, string title, ExcelTableHeaderBlockParameters[] headerParameters, List<T> data)
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

            List<string> properties = new List<string>();
            char columnF = 'A';
            char columnT = 'A';
            uint count = 1;
            foreach (ExcelTableHeaderBlockParameters block in headerParameters)
            {
                if (block.RowCount == 1)
                {
                    ec.SetColumnSize(count, block.titleFirstRow.width);

                    ec.InsertCellInWorksheet(new ExcelCellParameters
                    {
                        ColumnName = columnF + "",
                        RowIndex = 3,
                        Text = block.titleFirstRow.title,
                        StyleInfo = ExcelStyleInfoType.Header
                    });

                    ec.InsertCellInWorksheet(new ExcelCellParameters
                    {
                        ColumnName = columnF + "",
                        RowIndex = 4,
                        Text = "",
                        StyleInfo = ExcelStyleInfoType.Header
                    });

                    ec.MergeCells(new ExcelMergeParameters { CellFromName = columnF + "3", CellToName = columnF + "4" });

                    properties.Add(block.titleFirstRow.properyName);
                    count++;
                    columnF++;
                    columnT++;
                }
                else
                {
                    columnT--;
                    foreach (ExcelTableHeaderCellProperties cell in block.titlesSecondRow)
                    {

                        columnT++;
                        ec.SetColumnSize(count, cell.width);

                        ec.InsertCellInWorksheet(new ExcelCellParameters
                        {
                            ColumnName = columnT + "",
                            RowIndex = 3,
                            Text = "",
                            StyleInfo = ExcelStyleInfoType.Header
                        });

                        ec.InsertCellInWorksheet(new ExcelCellParameters
                        {
                            ColumnName = columnT + "",
                            RowIndex = 4,
                            Text = cell.title,
                            StyleInfo = ExcelStyleInfoType.Header
                        });

                        properties.Add(cell.properyName);
                        count++;
                    }

                    ec.InsertCellInWorksheet(new ExcelCellParameters
                    {
                        ColumnName = columnF + "",
                        RowIndex = 3,
                        Text = block.titleFirstRow.title,
                        StyleInfo = ExcelStyleInfoType.Header
                    });

                    ec.MergeCells(new ExcelMergeParameters { CellFromName = columnF + "3", CellToName = columnT + "3" });

                    columnT++;
                    columnF = columnT;
                }
            }

            Type type = data[0].GetType();
            columnF = 'A';
            uint rowIndex;
            foreach (string prop in properties)
            {
                rowIndex = 5;
                foreach (T item in data)
                {
                    if (type.GetField(prop) != null)
                    {
                        ec.InsertCellInWorksheet(new ExcelCellParameters
                        {
                            ColumnName = columnF + "",
                            RowIndex = rowIndex,
                            Text = type.GetField(prop).GetValue(item).ToString(),
                            StyleInfo = ExcelStyleInfoType.TextWithBorder
                        });
                    }
                    else
                    {
                        ec.InsertCellInWorksheet(new ExcelCellParameters
                        {
                            ColumnName = columnF + "",
                            RowIndex = rowIndex,
                            Text = type.GetProperty(prop).GetValue(item).ToString(),
                            StyleInfo = ExcelStyleInfoType.TextWithBorder
                        });
                    }
                    rowIndex++;
                }
                columnF++;
            }

            ec.SaveExcel();
        }
    }
}
