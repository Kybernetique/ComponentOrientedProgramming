using App.Components.AntonovComponents.Enums;
using App.Components.AntonovComponents.HelperModels;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes.Charts;
using MigraDoc.Rendering;
using System;
using System.ComponentModel;
using System.Text;


namespace App.Components.AntonovComponents
{
    public partial class DiagramPdfComponent : Component
    {
        private ErrorDiagramPdfMessage _errorMessage = ErrorDiagramPdfMessage.Ошибок_нет;
        public string ErrorMessageString => _errorMessage.ToString();
        public DiagramPdfComponent()
        {
            InitializeComponent();
        }

        public DiagramPdfComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        private bool InputValidation(DiagramPdfParameters parameters)
        {
            if (parameters == null)
            {
                _errorMessage = ErrorDiagramPdfMessage.Не_указаны_параметры_диаграммы;
                return false;
            }

            if (string.IsNullOrEmpty(parameters.Path))
            {
                _errorMessage = ErrorDiagramPdfMessage.Не_указан_путь;
                return false;
            }

            if (string.IsNullOrEmpty(parameters.Title))
            {
                _errorMessage = ErrorDiagramPdfMessage.Не_указан_заголовок;
                return false;
            }

            if (string.IsNullOrEmpty(parameters.DiagramName))
            {
                _errorMessage = ErrorDiagramPdfMessage.Не_указано_название_диаграммы;
                return false;
            }

            if (!Enum.IsDefined(typeof(ChartAreaLegend), parameters.ChartAreaLegend))
            {
                _errorMessage = ErrorDiagramPdfMessage.Не_указано_местоположение_легенды;
                return false;
            }

            if (parameters.Series.Name == null || parameters.Series.YAxisValues.Length == 0)
            {
                _errorMessage = ErrorDiagramPdfMessage.Не_указаны_данные;
                return false;
            }

            if (parameters.XAxisValues == null)
            {
                _errorMessage = ErrorDiagramPdfMessage.Не_указаны_подписи_оси_абсцисс;
                return false;
            }
            return true;
        }

        public bool CreateDocument(DiagramPdfParameters parameters)
        {
            if (!InputValidation(parameters))
            {
                return false;
            }

            //required for correct rendering
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var document = new Document();
            var styleTitle = document.Styles["Normal"];
            styleTitle.Font.Name = "Times New Roman";
            styleTitle.Font.Size = 14;
            styleTitle.Font.Color = Colors.Black;
            styleTitle.Font.Bold = true;
            document.Styles.AddStyle("NormalTitle", "Normal");

            var section = document.AddSection();
            var paragraph = section.AddParagraph(parameters.Title);
            paragraph.Format.Alignment = ParagraphAlignment.Left;
            paragraph.Style = "NormalTitle";

            var chart = section.AddChart(ChartType.PieExploded2D);
            chart.Left = 0;
            chart.Width = Unit.FromCentimeter(16);
            chart.Height = Unit.FromCentimeter(10);
            chart.HeaderArea.AddParagraph(parameters.DiagramName);
            chart.HeaderArea.Format.Font.Bold = false;

            switch (parameters.ChartAreaLegend)
            {
                case ChartAreaLegend.Top:
                    {
                        chart.TopArea.AddLegend();
                        break;
                    }
                case ChartAreaLegend.Right:
                    {
                        chart.RightArea.AddLegend();
                        break;
                    }
                case ChartAreaLegend.Bottom:
                    {
                        chart.BottomArea.AddLegend();
                        break;
                    }
                case ChartAreaLegend.Left:
                    {
                        chart.LeftArea.AddLegend();
                        break;
                    }
                default:
                    {
                        chart.BottomArea.AddLegend();
                        break;
                    }
            }

            var data = parameters.Series;
            if (string.IsNullOrEmpty(data.Name) || data.YAxisValues.Length < 2)
            {
                _errorMessage = ErrorDiagramPdfMessage.Неверно_указаны_данные_серии;
                return false;
            }
            var series = chart.SeriesCollection.AddSeries();
            series.Name = data.Name;
            series.Add(data.YAxisValues);

            chart.XAxis.MajorTickMark = TickMarkType.Outside;
            chart.YAxis.MajorTickMark = TickMarkType.Outside;
            chart.YAxis.HasMajorGridlines = true;

            chart.PlotArea.LineFormat.Width = 1;
            chart.PlotArea.LineFormat.Visible = true;

            var xseries = chart.XValues.AddXSeries();
            xseries.Add(parameters.XAxisValues);

            var renderer = new PdfDocumentRenderer(true) { Document = document };
            renderer.RenderDocument();
            renderer.PdfDocument.Save(parameters.Path);
            return true;
        }
    }
}
