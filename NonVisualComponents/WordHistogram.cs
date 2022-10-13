using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using NonVisualComponents.HelperModels;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace NonVisualComponents
{
    public partial class WordHistogram : Component
    {
        /*
           Не визуальный компонент для создания документа с
           гистограммой. У компонента должен быть публичный метод,
           который должен принимать на вход имя файла (включая путь до
           файла), название документа (заголовок в документе), заголовок
           для диаграммы, указание расположения легенды для диаграммы
           (создать для этого перечисление), набор данных для диаграммы
           (название серии и данные для графика). Должна быть проверка
            на заполненность входных данных значениями.
         */
        /// <summary>
        /// Метод создания отчета
        /// </summary>
        public void ReportSaveGistogram(string filename, string title, string nameGistogram,
            Legend legend, List<Test> list)
        {
            if (string.IsNullOrEmpty(filename) || string.IsNullOrEmpty(title) || string.IsNullOrEmpty(nameGistogram) || list.Count == 0)
            {
                throw new Exception("Fields is empty!");
            }
            CreateDoc(filename, title, nameGistogram, legend, list);

        }
        /// <summary>
        /// Создание документа
        /// </summary>
        private void CreateDoc(string fileName, string title, string nameDiagram, 
            Legend chartLegendPosition, List<Test> list)
        {
            try
            {
                DocX document = DocX.Create(fileName);
                document.InsertParagraph(title);
                document.Paragraphs[0].Direction = Direction.RightToLeft;
                document.Paragraphs[0].Alignment = Alignment.center;
                document.Paragraphs[0].FontSize(20);
                document.Paragraphs[0].Bold();
                // создаём линейную диаграмму
                BarChart gistogramChart = new BarChart();
                // добавляем легенду 
                gistogramChart.AddLegend((ChartLegendPosition)chartLegendPosition, false);
                Series seriesFirst = new Series(nameDiagram);
                // заполняем данными
                seriesFirst.Bind(list, "name", "value");
                // создаём набор данных и добавляем на диаграмму
                gistogramChart.AddSeries(seriesFirst);
                document.InsertChart(gistogramChart);
                document.Save();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
