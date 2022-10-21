using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Office2013.Excel;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Drawing.Spreadsheet;
using Index = DocumentFormat.OpenXml.Drawing.Charts.Index;
using Components.AlexandrovComponents.HelperEnums;

namespace Components.AlexandrovComponents.HelperModels
{
    public class ExcelCreator
    {
        private SpreadsheetDocument spreadsheetDocument;
        private SharedStringTablePart shareStringPart;
        private Worksheet worksheet;

        private static void CreateStyles(WorkbookPart workbookpart)
        {
            var sp = workbookpart.AddNewPart<WorkbookStylesPart>();
            sp.Stylesheet = new Stylesheet();

            var fonts = new DocumentFormat.OpenXml.Spreadsheet.Fonts() { Count = 2U, KnownFonts = true };

            var fontUsual = new Font();
            fontUsual.Append(new FontSize() { Val = 12D });
            fontUsual.Append(new DocumentFormat.OpenXml.Office2010.Excel.Color() { Theme = 1U });
            fontUsual.Append(new FontName() { Val = "Times New Roman" });
            fontUsual.Append(new FontFamilyNumbering() { Val = 2 });
            fontUsual.Append(new DocumentFormat.OpenXml.Spreadsheet.FontScheme() { Val = FontSchemeValues.Minor });

            var fontTitle = new Font();
            fontTitle.Append(new Bold());
            fontTitle.Append(new FontSize() { Val = 14D });
            fontTitle.Append(new DocumentFormat.OpenXml.Office2010.Excel.Color() { Theme = 1U });
            fontTitle.Append(new FontName() { Val = "Times New Roman" });
            fontTitle.Append(new FontFamilyNumbering() { Val = 2 });
            fontTitle.Append(new DocumentFormat.OpenXml.Spreadsheet.FontScheme() { Val = FontSchemeValues.Minor });

            fonts.Append(fontUsual);
            fonts.Append(fontTitle);

            var fills = new Fills() { Count = 2U };

            var fill1 = new DocumentFormat.OpenXml.Spreadsheet.Fill();
            fill1.Append(new DocumentFormat.OpenXml.Spreadsheet.PatternFill() { PatternType = PatternValues.None });

            var fill2 = new DocumentFormat.OpenXml.Spreadsheet.Fill();
            fill2.Append(new DocumentFormat.OpenXml.Spreadsheet.PatternFill() { PatternType = PatternValues.Gray125 });

            fills.Append(fill1);
            fills.Append(fill2);

            var borders = new Borders() { Count = 2U };

            var borderNoBorder = new Border();
            borderNoBorder.Append(new DocumentFormat.OpenXml.Spreadsheet.LeftBorder());
            borderNoBorder.Append(new DocumentFormat.OpenXml.Spreadsheet.RightBorder());
            borderNoBorder.Append(new DocumentFormat.OpenXml.Spreadsheet.TopBorder());
            borderNoBorder.Append(new DocumentFormat.OpenXml.Spreadsheet.BottomBorder());
            borderNoBorder.Append(new DiagonalBorder());

            var borderThin = new Border();

            var leftBorder = new DocumentFormat.OpenXml.Spreadsheet.LeftBorder() { Style = BorderStyleValues.Thin };
            leftBorder.Append(new DocumentFormat.OpenXml.Office2010.Excel.Color() { Indexed = 64U });

            var rightBorder = new DocumentFormat.OpenXml.Spreadsheet.RightBorder() { Style = BorderStyleValues.Thin };
            rightBorder.Append(new DocumentFormat.OpenXml.Office2010.Excel.Color() { Indexed = 64U });

            var topBorder = new DocumentFormat.OpenXml.Spreadsheet.TopBorder() { Style = BorderStyleValues.Thin };
            topBorder.Append(new DocumentFormat.OpenXml.Office2010.Excel.Color() { Indexed = 64U });

            var bottomBorder = new DocumentFormat.OpenXml.Spreadsheet.BottomBorder() { Style = BorderStyleValues.Thin };
            bottomBorder.Append(new DocumentFormat.OpenXml.Office2010.Excel.Color() { Indexed = 64U });

            borderThin.Append(leftBorder);
            borderThin.Append(rightBorder);
            borderThin.Append(topBorder);
            borderThin.Append(bottomBorder);
            borderThin.Append(new DiagonalBorder());

            borders.Append(borderNoBorder);
            borders.Append(borderThin);

            var cellStyleFormats = new CellStyleFormats() { Count = 1U };
            var cellFormatStyle = new CellFormat() { NumberFormatId = 0U, FontId = 0U, FillId = 0U, BorderId = 0U };
            cellStyleFormats.Append(cellFormatStyle);

            var cellFormats = new CellFormats() { Count = 3U };
            var cellFormatFont = new CellFormat()
            {
                NumberFormatId = 0U,
                FontId = 0U,
                FillId = 0U,
                BorderId = 0U,
                FormatId = 0U,
                ApplyFont = true
            };
            var cellFormatFontAndBorder = new CellFormat()
            {
                NumberFormatId = 0U,
                FontId = 0U,
                BorderId = 1U,
                FormatId = 0U,
                ApplyFont = true,
                ApplyBorder = true
            };
            var cellFormatTitle = new CellFormat()
            {
                NumberFormatId = 0U,
                FontId = 1U,
                FillId = 0U,
                BorderId = 0U,
                FormatId = 0U,
                Alignment = new Alignment()
                {
                    Vertical = VerticalAlignmentValues.Center,
                    WrapText = true,
                    Horizontal = HorizontalAlignmentValues.Center
                },
                ApplyFont = true
            };
            var cellFormatHeader = new CellFormat()
            {
                NumberFormatId = 0U,
                FontId = 1U,
                FillId = 0U,
                BorderId = 1U,
                FormatId = 0U,
                Alignment = new Alignment()
                {
                    Vertical = VerticalAlignmentValues.Center,
                    WrapText = true,
                    Horizontal = HorizontalAlignmentValues.Center
                },
                ApplyFont = true
            };

            cellFormats.Append(cellFormatFont);
            cellFormats.Append(cellFormatFontAndBorder);
            cellFormats.Append(cellFormatTitle);
            cellFormats.Append(cellFormatHeader);

            var cellStyles = new CellStyles() { Count = 1U };
            cellStyles.Append(new CellStyle() { Name = "Normal", FormatId = 0U, BuiltinId = 0U });
            var differentialFormats = new DocumentFormat.OpenXml.Office2013.Excel.DifferentialFormats() { Count = 0U };

            var tableStyles = new TableStyles() { Count = 0U, DefaultTableStyle = "TableStyleMedium2", DefaultPivotStyle = "PivotStyleLight16" };

            var stylesheetExtensionList = new StylesheetExtensionList();

            var stylesheetExtension1 = new StylesheetExtension() { Uri = "{EB79DEF2-80B8-43e5-95BD-54CBDDF9020C}" };
            stylesheetExtension1.AddNamespaceDeclaration("x14", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/main");
            stylesheetExtension1.Append(new SlicerStyles() { DefaultSlicerStyle = "SlicerStyleLight1" });

            var stylesheetExtension2 = new StylesheetExtension() { Uri = "{9260A510-F301-46a8 - 8635 - F512D64BE5F5}" };
            stylesheetExtension2.AddNamespaceDeclaration("x15", "http://schemas.microsoft.com/office/spreadsheetml/2010/11/main");
            stylesheetExtension2.Append(new TimelineStyles() { DefaultTimelineStyle = "TimeSlicerStyleLight1" });

            stylesheetExtensionList.Append(stylesheetExtension1);
            stylesheetExtensionList.Append(stylesheetExtension2);

            sp.Stylesheet.Append(fonts);
            sp.Stylesheet.Append(fills);
            sp.Stylesheet.Append(borders);
            sp.Stylesheet.Append(cellStyleFormats);
            sp.Stylesheet.Append(cellFormats);
            sp.Stylesheet.Append(cellStyles);
            sp.Stylesheet.Append(differentialFormats);
            sp.Stylesheet.Append(tableStyles);
            sp.Stylesheet.Append(stylesheetExtensionList);
        }

        public static uint GetStyleValue(ExcelStyleInfoType styleInfo)
        {
            return styleInfo switch
            {
                ExcelStyleInfoType.Header => 3U,
                ExcelStyleInfoType.Title => 2U,
                ExcelStyleInfoType.TextWithBorder => 1U,
                ExcelStyleInfoType.Text => 0U,
                _ => 0U
            };
        }

        public void CreateExcel(string fileName)
        {
            spreadsheetDocument = SpreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook);

            var workbookpart = spreadsheetDocument.AddWorkbookPart();
            workbookpart.Workbook = new Workbook();
            CreateStyles(workbookpart);

            shareStringPart = spreadsheetDocument.WorkbookPart.GetPartsOfType<SharedStringTablePart>().Any() ?
                spreadsheetDocument.WorkbookPart.GetPartsOfType<SharedStringTablePart>().First() :
                spreadsheetDocument.WorkbookPart.AddNewPart<SharedStringTablePart>();

            if (shareStringPart.SharedStringTable == null)
            {
                shareStringPart.SharedStringTable = new SharedStringTable();
            }

            var worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet(new SheetData());

            var sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild(new Sheets());
            var sheet = new Sheet()
            {
                Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart),
                SheetId = 1,
                Name = "Лист"
            };
            sheets.Append(sheet);
            worksheet = worksheetPart.Worksheet;
        }

        public void InsertCellInWorksheet(ExcelCellParameters excelParams)
        {
            var sheetData = worksheet.GetFirstChild<SheetData>();

            Row row;
            if (sheetData.Elements<Row>().Where(r => r.RowIndex == excelParams.RowIndex).Any())
            {
                row = sheetData.Elements<Row>().Where(r => r.RowIndex == excelParams.RowIndex).First();
            }
            else
            {
                row = new Row() { RowIndex = excelParams.RowIndex };
                sheetData.Append(row);
            }

            Cell cell;
            if (row.Elements<Cell>().Where(c => c.CellReference.Value == excelParams.CellReference).Any())
            {
                cell = row.Elements<Cell>().Where(c => c.CellReference.Value == excelParams.CellReference).First();
            }
            else
            {
                Cell refCell = null;
                foreach (Cell rowCell in row.Elements<Cell>())
                {
                    if (string.Compare(rowCell.CellReference.Value, excelParams.CellReference, true) > 0)
                    {
                        refCell = rowCell;
                        break;
                    }
                }
                var newCell = new Cell() { CellReference = excelParams.CellReference };
                row.InsertBefore(newCell, refCell);
                cell = newCell;
            }
            shareStringPart.SharedStringTable.AppendChild(new SharedStringItem(new DocumentFormat.OpenXml.Spreadsheet.Text(excelParams.Text)));
            shareStringPart.SharedStringTable.Save();
            cell.CellValue = new CellValue((shareStringPart.SharedStringTable.Elements<SharedStringItem>().Count() - 1).ToString());
            cell.DataType = new EnumValue<CellValues>(CellValues.SharedString);
            cell.StyleIndex = GetStyleValue(excelParams.StyleInfo);
        }

        public void SetColumnSize(uint ColumnIndex, double ColumnWidth)
        {
            Column column = new()
            {
                Min = ColumnIndex,
                Max = ColumnIndex,
                Width = ColumnWidth,
                CustomWidth = true
            };

            if (worksheet.Elements<Columns>() == null || worksheet.Elements<Columns>().Any() || worksheet.GetFirstChild<Columns>() == null)
            {
                worksheet.InsertBefore(new Columns(column), worksheet.GetFirstChild<SheetData>());
            }
            else
            {
                Columns columns = worksheet.GetFirstChild<Columns>();
                columns.Append(column);
            }
        }

        public void MergeCells(ExcelMergeParameters excelParams)
        {
            MergeCells mergeCells;
            if (worksheet.Elements<MergeCells>().Any())
            {
                mergeCells = worksheet.Elements<MergeCells>().First();
            }
            else
            {
                mergeCells = new MergeCells();
                if (worksheet.Elements<CustomSheetView>().Any())
                {
                    worksheet.InsertAfter(mergeCells, worksheet.Elements<CustomSheetView>().First());
                }
                else
                {
                    worksheet.InsertAfter(mergeCells, worksheet.Elements<SheetData>().First());
                }
            }
            var mergeCell = new MergeCell()
            {
                Reference = new StringValue(excelParams.Merge)
            };
            mergeCells.Append(mergeCell);
        }

        public static LegendPositionValues GetLegendPositionValue(ExcelLegendPosition styleInfo)
        {
            return styleInfo switch
            {
                ExcelLegendPosition.Bottom => LegendPositionValues.Bottom,
                ExcelLegendPosition.Left => LegendPositionValues.Left,
                ExcelLegendPosition.Right => LegendPositionValues.Right,
                ExcelLegendPosition.Top => LegendPositionValues.Top,
                ExcelLegendPosition.TopRight => LegendPositionValues.TopRight,
                _ => LegendPositionValues.Bottom,
            };
        }

        public void CreateLineChart(string titleChart, ExcelLegendPosition excelLegendPosition,
            Dictionary<string, int[]> data, Tuple<double, double> categoryAxisProperties)
        {
            WorksheetPart worksheetPart = spreadsheetDocument.WorkbookPart.WorksheetParts.First();

            DrawingsPart drawingsPart = worksheetPart.AddNewPart<DrawingsPart>();
            worksheetPart.Worksheet.Append(new Drawing() { Id = worksheetPart.GetIdOfPart(drawingsPart) });
            worksheetPart.Worksheet.Save();

            ChartPart chartPart = drawingsPart.AddNewPart<ChartPart>();
            chartPart.ChartSpace = new ChartSpace();
            chartPart.ChartSpace.Append(new EditingLanguage() { Val = new StringValue("en-US") });
            DocumentFormat.OpenXml.Drawing.Charts.Chart chart = chartPart.ChartSpace.AppendChild(new DocumentFormat.OpenXml.Drawing.Charts.Chart());

            var ctitle = chart.AppendChild(new Title());
            var chartText = ctitle.AppendChild(new ChartText());
            var richText = chartText.AppendChild(new RichText());

            richText.AppendChild(new BodyProperties());
            richText.AppendChild(new ListStyle());
            var paragraph = richText.AppendChild(new Paragraph());

            var apPr = paragraph.AppendChild(new ParagraphProperties());
            apPr.AppendChild(new DefaultRunProperties());

            var run = paragraph.AppendChild(new DocumentFormat.OpenXml.Drawing.Run());
            run.AppendChild(new DocumentFormat.OpenXml.Drawing.RunProperties() { Language = "en-CA" });
            run.AppendChild(new DocumentFormat.OpenXml.Drawing.Text() { Text = titleChart });

            chart.AppendChild(new DisplayBlanksAs()
            {
                Val = new EnumValue<DocumentFormat.OpenXml.Drawing.Charts.DisplayBlanksAsValues>
                (DocumentFormat.OpenXml.Drawing.Charts.DisplayBlanksAsValues.Span)
            });
            PlotArea plotArea = chart.AppendChild(new PlotArea());
            plotArea.AppendChild(new Layout());
            LineChart lineChart = plotArea.AppendChild(new LineChart(
                new Grouping() { Val = new EnumValue<GroupingValues>(GroupingValues.Standard) },
                new DataLabels(
                    new DataLabelPosition() { Val = DataLabelPositionValues.Top },
                    new ShowCategoryName() { Val = new BooleanValue(false) },
                    new ShowLegendKey() { Val = new BooleanValue(false) },
                    new ShowSeriesName() { Val = new BooleanValue(false) },
                    new ShowValue() { Val = new BooleanValue(true) })));

            uint i = 0;

            foreach (string key in data.Keys)
            {
                LineChartSeries lineChartSeries = lineChart.AppendChild(new LineChartSeries(
                    new Index() { Val = new UInt32Value(i) },
                    new Order() { Val = new UInt32Value(i) },
                    new SeriesText(new NumericValue() { Text = key })));

                NumberLiteral numLit = lineChartSeries.AppendChild(new DocumentFormat.OpenXml.Drawing.Charts.Values()).AppendChild(new NumberLiteral());
                numLit.Append(new FormatCode("General"));
                PointCount numLitCount = new PointCount() { Val = new UInt32Value(0U) };
                numLit.Append(numLitCount);
                for (uint j = 0; j < data[key].Length; j++)
                {
                    if ((int)data[key].GetValue(j) == 0) continue;
                    numLitCount.Val++;
                    numLit.AppendChild(new NumericPoint() { Index = new UInt32Value(j) }).Append(new NumericValue(data[key].GetValue(j).ToString()));
                }

                i++;
            }

            lineChart.Append(new AxisId() { Val = new UInt32Value(48650112u) });
            lineChart.Append(new AxisId() { Val = new UInt32Value(48672768u) });

            Scaling scaling = new Scaling(new Orientation()
            {
                Val = new EnumValue<DocumentFormat.
                            OpenXml.Drawing.Charts.OrientationValues>(DocumentFormat.OpenXml.Drawing.Charts.OrientationValues.MinMax)
            });
            if (categoryAxisProperties != null)
            {
                scaling.Append(
                    new MinAxisValue() { Val = new DoubleValue(categoryAxisProperties.Item1) },
                    new MaxAxisValue() { Val = new DoubleValue(categoryAxisProperties.Item2) }
                );
            }

            plotArea.AppendChild(new CategoryAxis(
                new AxisId() { Val = new UInt32Value(48650112u) },
                scaling,
                new Delete() { Val = new BooleanValue(false) },
                new AxisPosition() { Val = new EnumValue<AxisPositionValues>(AxisPositionValues.Bottom) },
                new TickLabelPosition() { Val = new EnumValue<TickLabelPositionValues>(TickLabelPositionValues.NextTo) },
                new CrossingAxis() { Val = new UInt32Value(48672768U) },
                new Crosses() { Val = new EnumValue<CrossesValues>(CrossesValues.AutoZero) },
                new AutoLabeled() { Val = new BooleanValue(false) },
                new LabelAlignment() { Val = new EnumValue<LabelAlignmentValues>(LabelAlignmentValues.Center) },
                new LabelOffset() { Val = new UInt16Value((ushort)100) }));

            plotArea.AppendChild(new ValueAxis(
                new AxisId() { Val = new UInt32Value(48672768u) },
                new Scaling(new Orientation()
                {
                    Val = new EnumValue<DocumentFormat.OpenXml.Drawing.Charts.OrientationValues>(
                        DocumentFormat.OpenXml.Drawing.Charts.OrientationValues.MinMax)
                }
                ),
                new Delete() { Val = new BooleanValue(false) },
                new AxisPosition() { Val = new EnumValue<AxisPositionValues>(AxisPositionValues.Left) },
                new MajorGridlines(),
                new DocumentFormat.OpenXml.Drawing.Charts.NumberingFormat()
                {
                    FormatCode = new StringValue("General"),
                    SourceLinked = new BooleanValue(true)
                }, new TickLabelPosition()
                {
                    Val = new EnumValue<TickLabelPositionValues>(TickLabelPositionValues.NextTo)
                }, new CrossingAxis() { Val = new UInt32Value(48650112U) },
                new Crosses() { Val = new EnumValue<CrossesValues>(CrossesValues.AutoZero) },
                new CrossBetween() { Val = new EnumValue<CrossBetweenValues>(CrossBetweenValues.Between) }));

            chart.AppendChild(new Legend(new LegendPosition()
            { Val = new EnumValue<LegendPositionValues>(GetLegendPositionValue(excelLegendPosition)) }, new Layout()));

            chartPart.ChartSpace.Save();

            drawingsPart.WorksheetDrawing = new WorksheetDrawing();
            TwoCellAnchor twoCellAnchor = drawingsPart.WorksheetDrawing.AppendChild(new TwoCellAnchor());
            twoCellAnchor.Append(new DocumentFormat.OpenXml.Drawing.Spreadsheet.FromMarker(new ColumnId("1"),
                new ColumnOffset("581025"),
                new RowId("4"),
                new RowOffset("114300")));
            twoCellAnchor.Append(new DocumentFormat.OpenXml.Drawing.Spreadsheet.ToMarker(new ColumnId("13"),
                new ColumnOffset("276225"),
                new RowId("26"),
                new RowOffset("0")));

            DocumentFormat.OpenXml.Drawing.Spreadsheet.GraphicFrame graphicFrame =
                twoCellAnchor.AppendChild(new DocumentFormat.OpenXml.Drawing.Spreadsheet.GraphicFrame());
            graphicFrame.Macro = "";

            graphicFrame.Append(new DocumentFormat.OpenXml.Drawing.Spreadsheet.NonVisualGraphicFrameProperties(
                new DocumentFormat.OpenXml.Drawing.Spreadsheet.NonVisualDrawingProperties() { Id = new UInt32Value(2u), Name = "Chart 1" },
                new DocumentFormat.OpenXml.Drawing.Spreadsheet.NonVisualGraphicFrameDrawingProperties()));

            graphicFrame.Append(new Transform(new Offset() { X = 0L, Y = 0L }, new Extents() { Cx = 0L, Cy = 0L }));

            graphicFrame.Append(new Graphic(new GraphicData(new ChartReference() { Id = drawingsPart.GetIdOfPart(chartPart) })
            { Uri = "http://schemas.openxmlformats.org/drawingml/2006/chart" }));

            twoCellAnchor.Append(new ClientData());

            drawingsPart.WorksheetDrawing.Save();
        }

        public void SaveExcel()
        {
            spreadsheetDocument.WorkbookPart.Workbook.Save();
            spreadsheetDocument.Close();
        }
    }
}
