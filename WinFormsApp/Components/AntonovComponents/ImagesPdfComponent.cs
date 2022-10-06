using App.Components.AntonovComponents.Enums;
using App.Components.AntonovComponents.HelperModels;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.Rendering;
using System.ComponentModel;
using System.Text;

namespace App.Components.AntonovComponents
{
    public partial class ImagesPdfComponent : Component
    {
        private ErrorImagesMessage _errorMessage = ErrorImagesMessage.Ошибок_нет;
        public string ErrorMessageString { get => _errorMessage.ToString(); }
        public ImagesPdfComponent()
        {
            InitializeComponent();
        }

        public ImagesPdfComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public bool CreateDocument(ImagesParameters parameters)
        {
            if (!InputValidation(parameters))
            {
                return false;
            }

            //required for correct rendering
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            // Create a new MigraDoc document
            var document = new Document();
            document.Info.Title = parameters.Title;

            //styles for the document
            DefineStyles(document);

            //pdf with images
            CreateImagesPdf(document, parameters);

            //finally creating the document
            SavePdf(document, parameters.Path);

            return true;
        }

        void CreateImagesPdf(Document document, ImagesParameters parameters)
        {
            // Each MigraDoc document needs at least one section.
            Section section = document.AddSection();

            section.PageSetup.DifferentFirstPageHeaderFooter = true;
            Paragraph paragraph = section.Headers.FirstPage.AddParagraph();
            paragraph.AddText(parameters.Title);
            paragraph.Format.Font.Size = 14;
            paragraph.Format.Alignment = ParagraphAlignment.Center;


            // Add images
            foreach (var im_path in parameters.ArrayImages)
            {
                Image image = section.AddImage(im_path);
                image.Top = ShapePosition.Top;
                image.Left = ShapePosition.Center;
                image.WrapFormat.Style = WrapStyle.TopBottom;
            }
        }
        private bool InputValidation(ImagesParameters parameters)
        {
            if (parameters == null)
            {
                _errorMessage = ErrorImagesMessage.Не_указаны_параметры_вообще;
                return false;
            }

            if (string.IsNullOrEmpty(parameters.Path))
            {
                _errorMessage = ErrorImagesMessage.Не_указан_путь;
                return false;
            }

            if (string.IsNullOrEmpty(parameters.Title))
            {
                _errorMessage = ErrorImagesMessage.Не_указан_заголовок;
                return false;
            }

            if (parameters.ArrayImages == null)
            {
                _errorMessage = ErrorImagesMessage.Не_указан_массив_изображений;
                return false;
            }
            return true;
        }
        void DefineStyles(Document document)
        {
            // Get the predefined style Normal.
            Style style = document.Styles["Normal"];

            // Because all styles are derived from Normal, the next line changes the
            // font of the whole document. Or, more exactly, it changes the font of
            // all styles and paragraphs that do not redefine the font.
            style.Font.Name = "Verdana";

            style = document.Styles[StyleNames.Header];
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right);
            style = document.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center);

            // Create a new style called Table based on style Normal
            style = document.Styles.AddStyle("Table", "Normal");
            style.Font.Name = "Verdana";
            style.Font.Name = "Times New Roman";
            style.Font.Size = 14;

            // Create a new style called Reference based on style Normal
            style = document.Styles.AddStyle("Reference", "Normal");
            style.ParagraphFormat.SpaceBefore = "5mm";
            style.ParagraphFormat.SpaceAfter = "5mm";
            style.ParagraphFormat.TabStops.AddTabStop("16cm", TabAlignment.Right);
        }
        private void SavePdf(Document document, string file_name)
        {
            // Create a renderer
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer();

            // Associate the MigraDoc document with a renderer
            pdfRenderer.Document = document;

            // Layout and render document to PDF
            pdfRenderer.RenderDocument();

            // Save and show the document
            pdfRenderer.PdfDocument.Save(file_name);
        }
    }
}
