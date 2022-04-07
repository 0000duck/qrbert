using System;
using System.Windows.Media;
using Aspose.Pdf;
using Page = System.Windows.Controls.Page;

namespace QRbert;

public partial class VolunteerPortal : Page
{
    public VolunteerPortal()
    {
        InitializeComponent();
        Page temp = new Page();
        this.Content = temp;
        //PdfMaker();
    }


    public void PdfMaker()
    {
        Document pdfTest = new Document();
        // Add page
        Aspose.Pdf.Page page = pdfTest.Pages.Add();

        // Add text to new page
        page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("Hello World!"));
        
        
        
        pdfTest.Save("document.pdf");
    }
    
    


}