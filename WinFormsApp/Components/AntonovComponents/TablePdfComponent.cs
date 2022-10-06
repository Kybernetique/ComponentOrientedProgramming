using App.Components.AntonovComponents.Enums;
using App.Components.AntonovComponents.HelperModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;

namespace App.Components.AntonovComponents
{
    public partial class TablePdfComponent : Component
    {
        private ErrorTablePdfMessage _errorMessage = ErrorTablePdfMessage.Ошибок_нет;
        private Dictionary<string, int> _propertyInfos;

        [Category("ComponentPdfDiagram"), Description("Содержание ошибки")]
        public string ErrorMessageString => _errorMessage.ToString();
        public TablePdfComponent()
        {
            InitializeComponent();
        }

        public TablePdfComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        private bool InputValidation<T>(TablePdfParameters<T> parameters)
        {
            if (parameters == null)
            {
                _errorMessage = ErrorTablePdfMessage.Не_указаны_параметры_таблицы;
                return false;
            }

            if (string.IsNullOrEmpty(parameters.Path))
            {
                _errorMessage = ErrorTablePdfMessage.Не_указан_путь;
                return false;
            }

            if (string.IsNullOrEmpty(parameters.Title))
            {
                _errorMessage = ErrorTablePdfMessage.Не_указан_заголовок;
                return false;
            }

            if (parameters.DataList == null)
            {
                _errorMessage = ErrorTablePdfMessage.Не_указаны_данные;
                return false;
            }

            if (parameters.CellsFirstRow == null || parameters.CellsSecondRow == null)
            {
                _errorMessage = ErrorTablePdfMessage.Не_указаны_параметры_шапки;
                return false;
            }
            return true;
        }

        private void CreateTextStyle(Document document, int titleTextSize, int contentTextSize)
        {
            var styleTitle = document.Styles["Normal"];
            styleTitle.Font.Name = "Times New Roman";
            styleTitle.Font.Size = titleTextSize;
            styleTitle.Font.Color = Colors.Black;
            styleTitle.Font.Bold = true;
            document.Styles.AddStyle("NormalTitle", "Normal");

            var styleContent = document.Styles["Normal"];
            styleContent.Font.Name = "Times New Roman";
            styleContent.Font.Size = contentTextSize;
            styleContent.Font.Color = Colors.Black;
            document.Styles.AddStyle("NormalContent", "Normal");
        }

        private bool CreateHeadInTable(Table table, List<CellPdfTable> firstRow, List<CellPdfTable> secondRow)
        {
            var countColumnsTop = 0;
            var countMergeColumns = 0;
            foreach (var cell in firstRow)
            {
                countColumnsTop += cell.CountCells;
                countMergeColumns = cell.CountCells > 1 ? countMergeColumns += cell.CountCells : countMergeColumns;
            }

            if (countMergeColumns != secondRow.Count)
            {
                _errorMessage = ErrorTablePdfMessage.Неправильно_указаны_ячейки_шапки;
                return false;
            }

            foreach (var cell in firstRow)
            {
                for (var i = 0; i < cell.CountCells; i++)
                {
                    table.AddColumn(cell.ColumnWidth);
                }
            }

            _propertyInfos = new Dictionary<string, int>();
            table.AddRow();

            var currentIndex = 0;
            foreach (var cell in firstRow)
            {
                var currentCell = table.Rows[0].Cells[currentIndex];
                if (string.IsNullOrEmpty(cell.Text))
                {
                    _errorMessage = ErrorTablePdfMessage.Не_указано_название_для_колонки;
                    return false;
                }
                currentCell.AddParagraph(cell.Text);
                currentCell.Format.Alignment = ParagraphAlignment.Center;
                if (cell.CountCells > 1)
                {
                    currentCell.MergeRight = cell.CountCells - 1;
                    currentIndex += cell.CountCells;
                }
                else
                {
                    if (string.IsNullOrEmpty(cell.PropertyName))
                    {
                        _errorMessage = ErrorTablePdfMessage.Не_указано_название_свойства_для_колонки;
                        return false;
                    }
                    _propertyInfos.Add(cell.PropertyName, currentIndex);
                    currentIndex++;
                }
            }

            table.AddRow();

            var countMerged = 0;
            currentIndex = 0;
            for (var i = 0; i < countColumnsTop; i++)
            {
                var highCurrentCell = table.Rows[0].Cells[i];
                var currentCell = table.Rows[1].Cells[i];

                countMerged = highCurrentCell.MergeRight > 0 ? highCurrentCell.MergeRight + 1 : countMerged;
                if (countMerged != 0)
                {
                    if (string.IsNullOrEmpty(secondRow[currentIndex].Text))
                    {
                        _errorMessage = ErrorTablePdfMessage.Не_указано_название_для_колонки;
                        return false;
                    }
                    currentCell.AddParagraph(secondRow[currentIndex].Text);
                    if (string.IsNullOrEmpty(secondRow[currentIndex].PropertyName))
                    {
                        _errorMessage = ErrorTablePdfMessage.Не_указано_название_свойства_для_колонки;
                        return false;
                    }
                    _propertyInfos.Add(secondRow[currentIndex].PropertyName, i);
                    currentCell.Format.Alignment = ParagraphAlignment.Center;
                    currentIndex++;
                    countMerged--;
                }
                else
                {
                    highCurrentCell.MergeDown = 1;
                }
            }
            return true;
        }

        /// <summary>
        /// Метод создания pdf документа стаблицей
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tablePdfParameters">Параметры таблицы</param>
        /// <returns>Результат создания документа</returns>
        public bool CreateDocument<T>(TablePdfParameters<T> tablePdfParameters) where T : class
        {
            if (!InputValidation(tablePdfParameters))
            {
                return false;
            }

            //required for correct rendering
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var document = new Document();
            CreateTextStyle(document, tablePdfParameters.TitleTextSize, tablePdfParameters.ContentTextSize);
            var section = document.AddSection();

            var paragraph = section.AddParagraph(tablePdfParameters.Title);
            paragraph.Format.SpaceAfter = "1cm";
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Style = "NormalTitle";

            var borders = new Borders { Width = 1 };

            var table = document.LastSection.AddTable();
            table.Borders = borders;
            table.Rows.VerticalAlignment = VerticalAlignment.Center;

            if (!CreateHeadInTable(table, tablePdfParameters.CellsFirstRow, tablePdfParameters.CellsSecondRow))
            {
                return false;
            }

            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var data in tablePdfParameters.DataList)
            {
                var newRow = table.AddRow();
                foreach (var property in props)
                {
                    var prop = data.GetType().GetProperty(property.Name);
                    if (prop == null)
                    {
                        _errorMessage = ErrorTablePdfMessage.Неверно_указано_название_свойства_для_колонки;
                        return false;
                    }
                    var columnIndex = _propertyInfos[prop.Name];
                    newRow.Cells[columnIndex].AddParagraph(prop.GetValue(data, null)?.ToString());
                }
            }

            var renderer = new PdfDocumentRenderer(true) { Document = document };
            renderer.RenderDocument();
            renderer.PdfDocument.Save(tablePdfParameters.Path);
            return true;
        }
    }
}
