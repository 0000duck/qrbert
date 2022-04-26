using System.Windows;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using BitMiracle.Docotic.Pdf;

namespace QRbert;

public partial class VolunteerViewTimesheets : Window
{
    public VolunteerViewTimesheets()
    {
        InitializeComponent();
    }

    
    /// <summary>
    /// Redirects volunteer user to their MyAccount window via a button click on the menu item
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void VolunteerMyAcctBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.VolunteerPortalSwitch(new VolunteerMyAccount());
        this.Close();
    }

    /// <summary>
    /// Logs out Volunteer and redirects user to the Log In page via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void LogOutBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.LogOutSwitch();
        this.Close();
    }

    /// <summary>
    /// Redirects user to home page - volunteer portal via QRbert image click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void HomeVolunteerPortalBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.RedirectVolunteerPortal();
        this.Close();
    }
    
    /// <summary>
    /// Redirects user to view timesheet window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ViewTimesheetBtn_Click(object sender, RoutedEventArgs e)
    {
        //makeTable();
        Switcher.VolunteerPortalSwitch(new VolunteerViewTimesheets());
        this.Close();
    }

    /// <summary>
    /// Redirects user to scan pet qr code window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ScanPetQRCodeBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.VolunteerPortalSwitch(new VolunteerScanPetQrCode());
        this.Close();
    }

    /// <summary>
    /// Redirects user to pet report window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void PetReportBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.VolunteerPortalSwitch(new VolunteerScanPetQrCode());
        this.Close();
    }


    private void makeTable(object sender, RoutedEventArgs routedEventArgs)
        {
            Document document = new Document();

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
            var header1 = header.Cells.Add("User ID: 600");
            header1.ColSpan = 2;
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
            
            
            for (int row_count = 1; row_count < 2; row_count++)
            {
                // Add row to table
                Aspose.Pdf.Row row = timeTable.Rows.Add();
                // Add table cells
                string msg =
                    Switcher.VerifyRole(
                        "Select QRbertTables.TimeSheet.Clock_In  FROM ((QRbertTables.TimeSheet INNER JOIN QRbertTables.Volunteer ON QRbertTables.TimeSheet.ID = QRbertTables.Volunteer.ID));");
                row.Cells.Add(msg);
                MessageBox.Show(msg);
                msg = Switcher.VerifyRole("Select QRbertTables.TimeSheet.Clock_Out FROM ((QRbertTables.TimeSheet INNER JOIN QRbertTables.Volunteer ON QRbertTables.TimeSheet.ID = QRbertTables.Volunteer.ID));");
                row.Cells.Add(msg);
                row.Cells.Add("Column (" + row_count + ", 3)");
                row.Cells.Add("Column (" + row_count + ", 4)");
                row.Cells.Add("Column (" + row_count + ", 5)");
                row.Cells.Add("Column (" + row_count + ", 6)");
                row.Cells.Add("Column (" + row_count + ", 7)");
                row.Cells.Add("Column (" + row_count + ", 8)");
                row.Cells.Add("Column (" + row_count + ", 9)");
                row.Cells.Add("Column (" + row_count + ", 0)");
            }
            page.Paragraphs.Add(table);
            page.Paragraphs.Add(timeTable);
            page.PageInfo.IsLandscape = true;
            

// Save PDF 
            document.Save("document.pdf");
            PdfDocument pdf = new PdfDocument("document.pdf");
            PdfDrawOptions options = PdfDrawOptions.CreateZoom(150);
            options.BackgroundColor = new PdfRgbColor(255, 255, 255); // white background, transparent by default
            //options.Format = PdfDrawFormat.Jpeg;
            PdfPage page2 = pdf.Pages[0];
            PdfBox cropBoxBefore = page2.CropBox;

            //page2.CropBox = new PdfBox(0, cropBoxBefore.Height - 256, 256, cropBoxBefore.Height);
            pdf.Pages[0].Save("result.jpg",options);
            
            
            
            Switcher.VolunteerPortalSwitch(new VolunteerViewTimesheets());
            //Switcher.VolunteerPortalSwitch(new VolunteerViewTimesheets());
            this.Close();
            
        }
    

}