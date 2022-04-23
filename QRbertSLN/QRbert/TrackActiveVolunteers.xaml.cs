using System.Windows;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using BitMiracle.Docotic.Pdf;

namespace QRbert;

/*
 * Window for Staff - To Track Active Volunteers
 */

public partial class TrackActiveVolunteers : Window
{
    public TrackActiveVolunteers()
    {
        InitializeComponent();
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
            header.Cells.Add("User ID");
            header.Cells.Add("First Name");
            header.Cells.Add("Last Name");
            Row header2 = table.Rows.Add();
            header2.Cells.Add("      ");
            Row header3 = table.Rows.Add();
            header3.Cells.Add("      ");
            

            Table timeTable = new Table();
            timeTable.ColumnWidths = "70 2cm";
            //timeTable.ColumnAdjustment = ColumnAdjustment.AutoFitToWindow;
            //Aspose.Pdf.Row timeRows = timeTable.Rows.Add();
            
            
            
            for (int row_count = 1; row_count < 3; row_count++)
            {
                // Add row to table
                Aspose.Pdf.Row row = timeTable.Rows.Add();
                // Add table cells
                row.Cells.Add("100");
                row.Cells.Add("Some");
                row.Cells.Add("Body");
            }
            page.Paragraphs.Add(table);
            page.Paragraphs.Add(timeTable);
            page.PageInfo.IsLandscape = true;
            

// Save PDF 
            document.Save("activeVolunteerDocument.pdf");
            PdfDocument pdf = new PdfDocument("activeVolunteerDocument.pdf");
            PdfDrawOptions options = PdfDrawOptions.CreateZoom(150);
            options.BackgroundColor = new PdfRgbColor(255, 255, 255); // white background, transparent by default
            //options.Format = PdfDrawFormat.Jpeg;
            PdfPage page2 = pdf.Pages[0];
            PdfBox cropBoxBefore = page2.CropBox;

            //page2.CropBox = new PdfBox(0, cropBoxBefore.Height - 256, 256, cropBoxBefore.Height);
            pdf.Pages[0].Save("activeVolunteers.jpg",options);
            
        // Should populate a window with the table listing once window loads
    }
    
    /// <summary>
    /// Redirects staff to their MyAccount page via button click
    /// Since the portal and the MyAccount are both pages, they should be easily navigable
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void StaffMyAccountBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffMyAccount());
        this.Close();
    }

    /// <summary>
    /// Logs out Staff and redirects user to the Log In page via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void LogOutBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.LogOutSwitch();
        this.Close();
    }

    /// <summary>
    /// Redirects user to home page - staff portal via QRbert image click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void HomeStaffPortalBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.RedirectStaffPortal();
        this.Close();
    }

    /// <summary>
    /// Redirects user to scan pet's QR Code in PetQrcodeScanner window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ScanPetQRCodeRedirectBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffScanPetQrCode());
        this.Close();
    }

    /// <summary>
    /// Redirects user to Pet Reports window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void PetReportsBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffPetReport());
        this.Close();
    }

    /// <summary>
    /// Redirects user to Staff Search window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void StaffSearchBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffSearch());
        this.Close();
    }

    /// <summary>
    /// Redirects user to Lock Timesheet window via button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void LockTimesheetsBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffLockTimesheet());
        this.Close();
    }

    /// <summary>
    /// Redirects user to Rounding rules window via button click 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void RoundingRulesBtn_Click(object sender, RoutedEventArgs e)
    {
        Switcher.StaffPageSwitch(new StaffRoundingRules());
        this.Close();
    }
}