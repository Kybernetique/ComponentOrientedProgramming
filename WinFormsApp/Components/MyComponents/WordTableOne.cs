using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using NonVisualComponents.HelperModels;

namespace NonVisualComponents
{
    public partial class WordTableOne : Component
    {
        public WordTableOne()
        {
            InitializeComponent();
        }

        /*
             * Не визуальный компонент для создания документа с таблицами.
            У компонента должен быть публичный метод, который должен 
            23
            принимать на вход имя файла (включая путь до файла), название
            документа (заголовок в документе) и набор таблиц (каждая
            представляет собой двумерный массив строк, где каждая строка –
            ячейка таблицы документа). Таблицы выделить границами.
            Ширина колонок одинакова у всех. Должна быть проверка на
            заполненность входных данных значениями.
             */
        public void SaveData(string filename, string title, List<string[,]> tables)
        {
            if (!CheckTableIsNull(tables))
            {
                throw new Exception("Empty Data!");
            }
            if (string.IsNullOrEmpty(filename))
            {
                throw new Exception("Empty filename!");
            }
            if (string.IsNullOrEmpty(title))
            {
                throw new Exception("Empty title!");
            }
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(filename, WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body docBody = mainPart.Document.AppendChild(new Body());
                docBody.AppendChild(CreateParagraph(new WordParagraph
                {
                    Texts = new List<(string, WordTextProperties)> { (title, new WordTextProperties { Bold = true, Size = "24", }) },
                    TextProperties = new WordTextProperties
                    {
                        Size = "24",
                        JustificationValues = JustificationValues.Center
                    }
                }));
                //для каждого массива табличка
                foreach (string[,] tabl in tables)
                {
                    Table table = new Table();
                    TableProperties props = new TableProperties(
                    new TableBorders(
                    new TopBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 6
                    },
                    new BottomBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 6
                    },
                    new LeftBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 6
                    },
                    new RightBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 6
                    },
                    new InsideHorizontalBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 6
                    },
                    new InsideVerticalBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 6
                    }));

                    table.AppendChild<TableProperties>(props);
                    TableRow tr;
                    TableCell tc;
                    for (var i = 0; i < tabl.GetLength(0); i++)
                    {
                        //  int count = tabl
                        tr = new TableRow();
                        for (var j = 0; j < tabl.GetLength(1); j++)
                        {
                            tc = new TableCell();
                            tc.Append(new Paragraph(new Run(new Text(tabl[i, j].ToString()))));
                            tr.Append(tc);
                        }
                        table.Append(tr);
                    }
                    docBody.Append(table);
                }
                docBody.AppendChild(CreateSectionProperties());
                wordDocument.MainDocumentPart.Document.Save(); //
            }
        }

        private static SectionProperties CreateSectionProperties()
        {
            SectionProperties properties = new SectionProperties();
            PageSize pageSize = new PageSize
            {
                Orient = PageOrientationValues.Portrait
            };
            properties.AppendChild(pageSize);
            return properties;
        }

        /// <summary>
        /// Создание абзаца с текстом
        /// </summary>
        /// <param name="paragraph"></param>
        /// <returns></returns>
        private static Paragraph CreateParagraph(WordParagraph paragraph)
        {
            if (paragraph != null)
            {
                Paragraph docParagraph = new Paragraph();

                docParagraph.AppendChild(CreateParagraphProperties(paragraph.TextProperties));
                foreach (var run in paragraph.Texts)
                {
                    Run docRun = new Run();
                    RunProperties properties = new RunProperties();
                    properties.AppendChild(new FontSize { Val = run.Item2.Size });
                    if (run.Item2.Bold)
                    {
                        properties.AppendChild(new Bold());
                    }
                    docRun.AppendChild(properties);
                    docRun.AppendChild(new Text
                    {
                        Text = run.Item1,
                        Space =
                   SpaceProcessingModeValues.Preserve
                    });
                    docParagraph.AppendChild(docRun);
                }
                return docParagraph;
            }
            return null;
        }

        /// <summary>
        /// Задание форматирования для абзаца
        /// </summary>
        /// <param name="paragraphProperties"></param>
        /// <returns></returns>
        private static ParagraphProperties CreateParagraphProperties(WordTextProperties
       paragraphProperties)
        {
            if (paragraphProperties != null)
            {
                ParagraphProperties properties = new ParagraphProperties();
                properties.AppendChild(new Justification()
                {
                    Val = paragraphProperties.JustificationValues
                });
                properties.AppendChild(new SpacingBetweenLines
                {
                    LineRule = LineSpacingRuleValues.Auto
                });
                properties.AppendChild(new Indentation());
                ParagraphMarkRunProperties paragraphMarkRunProperties = new
               ParagraphMarkRunProperties();
                if (!string.IsNullOrEmpty(paragraphProperties.Size))
                {
                    paragraphMarkRunProperties.AppendChild(new FontSize
                    {
                        Val =
                   paragraphProperties.Size
                    });
                }
                properties.AppendChild(paragraphMarkRunProperties);
                return properties;
            }
            return null;
        }

        private bool CheckTableIsNull(List<string[,]> tables)
        {
            foreach (string[,] table in tables)
            {
                foreach (string str in table)
                {
                    if (str == null) return false;
                }
            }
            return true;
        }
    }
}
