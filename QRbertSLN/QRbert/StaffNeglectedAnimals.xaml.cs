using System.Windows;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using BitMiracle.Docotic.Pdf;

namespace QRbert;

public partial class StaffNeglectedAnimals : Window
{
    public StaffNeglectedAnimals()
    {
        InitializeComponent();Document document = new Document();

// Add page
            Aspose.Pdf.Page page = document.Pages.Add();

// Add text to new page
            
            TextFragment textFragment = new TextFragment("Hello World!");
            textFragment.TextState.FontSize = 120;

            Table table = new Table();
            
            table.ColumnAdjustment = ColumnAdjustment.AutoFitToWindow;
            // Add row to table
            Aspose.Pdf.Row header = table.Rows.Add();
            // Add table cells
            header.Cells.Add("User ID: 600");
            header.Cells.Add("First Name: Melanie");
            header.Cells.Add("Last Name: Bee");
            Row header2 = table.Rows.Add();
            header2.Cells.Add("      ");
            Row header3 = table.Rows.Add();
            header3.Cells.Add("      ");
            

            Table timeTable = new Table();
            timeTable.ColumnWidths = "70 2cm";
            //timeTable.ColumnAdjustment = ColumnAdjustment.AutoFitToWindow;
            Aspose.Pdf.Row timeRows = timeTable.Rows.Add();
            var testCell1 = timeRows.Cells.Add("Mon");
            testCell1.ColSpan = 2;
            var testCell2 = timeRows.Cells.Add("Tues");
            testCell2.ColSpan = 2;
            var testCell3 = timeRows.Cells.Add("Wed");
            testCell3.ColSpan = 2;
            var testCell4 = timeRows.Cells.Add("Thurs");
            testCell4.ColSpan = 2;
            var testCell5 = timeRows.Cells.Add("Fri");
            testCell5.ColSpan = 2;
            
            
            for (int row_count = 1; row_count < 3; row_count++)
            {
                // Add row to table
                Aspose.Pdf.Row row = timeTable.Rows.Add();
                // Add table cells
                row.Cells.Add("800");
                row.Cells.Add("Lily");

            }
            page.Paragraphs.Add(table);
            page.Paragraphs.Add(timeTable);
            page.PageInfo.IsLandscape = true;
            

// Save PDF 
            document.Save("neglectedPet.pdf");
            PdfDocument pdf = new PdfDocument("neglectedPet.pdf");
            PdfDrawOptions options = PdfDrawOptions.CreateZoom(150);
            options.BackgroundColor = new PdfRgbColor(255, 255, 255); // white background, transparent by default
            //options.Format = PdfDrawFormat.Jpeg;
            PdfPage page2 = pdf.Pages[0];
            PdfBox cropBoxBefore = page2.CropBox;

            //page2.CropBox = new PdfBox(0, cropBoxBefore.Height - 256, 256, cropBoxBefore.Height);
            pdf.Pages[0].Save("neglectedPetResult.jpg",options);
            
    }
}