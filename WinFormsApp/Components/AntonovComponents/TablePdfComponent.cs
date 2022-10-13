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
        private List<string> _propertyInfos;

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

            if (parameters.CellsFirstColumn == null)
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

        private bool CreateHeadInTable(Table table, List<CellPdfTable> firstColumn)
        {
            _propertyInfos = new List<string>();

            int flag = 0; // нужно ли слиять ячейки
            for (var i = 0; i < firstColumn.Count; i++)
            {
                if (firstColumn[i].PropertyName != null)
                {
                    Row row = table.AddRow();
                    Cell cell;
                    if (flag == 0)
                    {
                        cell = row.Cells[0];
                        cell.AddParagraph(firstColumn[i].Text);
                        //в шапке два столбца первые, нужно объединить справа
                        cell.MergeRight = 1;
                    }
                    else
                    {
                        cell = row.Cells[1];
                        cell.AddParagraph(firstColumn[i].Text);
                        flag--;
                    }
                    _propertyInfos.Add(firstColumn[i].PropertyName);
                }
                //else we need to merge
                else
                {
                    Row row = table.AddRow();
                    Cell cell = row.Cells[0];
                    cell.AddParagraph(firstColumn[i].Text);

                    row.Cells[0].MergeDown = firstColumn[i].CountCells - 1;

                    //пишем в тот же ряд новый параграф
                    cell = row.Cells[1];
                    cell.AddParagraph(firstColumn[i + 1].Text);
                    _propertyInfos.Add(firstColumn[i + 1].PropertyName);

                    flag = firstColumn[i].CountCells - 1;
                    //свойство уже записи, пропускаем одну итерацию
                    i++;
                }
            }

            return true;
        }

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

            //все свойства класса лабораторной работы
            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            //две колонки под шапку
            table.AddColumn(Unit.FromCentimeter(2));
            table.AddColumn(Unit.FromCentimeter(2));

            for (int i = 0; i < tablePdfParameters.DataList.Count; i++)
            {
                table.AddColumn(Unit.FromCentimeter(3));
            }

            if (!CreateHeadInTable(table, tablePdfParameters.CellsFirstColumn))
            {
                return false;
            }

            //заполнение рядов/столбцов с данными
            for (int j = 0; j < tablePdfParameters.DataList.Count; j++)
            {
                var data = tablePdfParameters.DataList[j];
                for (int i = 0; i < _propertyInfos.Count; i++)
                {
                    var prop = data.GetType().GetProperty(_propertyInfos[i]);
                    if (prop == null)
                    {
                        _errorMessage = ErrorTablePdfMessage.Неверно_указано_название_свойства_для_колонки;
                        return false;
                    }

                    //+2 потому что первые два столбца шапка
                    Cell cell = table.Rows[i].Cells[j + 2];
                    cell.AddParagraph(prop.GetValue(data, null)?.ToString());
                }
            }

            var renderer = new PdfDocumentRenderer(true) { Document = document };
            try
            {
                renderer.RenderDocument();
            }
            catch (Exception)
            {
                throw new Exception("Неправильные настройки таблицы");
            }
            renderer.PdfDocument.Save(tablePdfParameters.Path);
            return true;
        }
    }
}
