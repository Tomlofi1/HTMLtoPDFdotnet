using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

namespace ClassLibrary1;

public static class PdfHTMLGenerator
{
    public static byte[] GeneratePdfFromHtml(string htmlTemplate, Dictionary<string, string> dicionarioData)
    {
        string processedHtml = ProcessHtmlTemplate(htmlTemplate, dicionarioData);

        HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
        BlinkConverterSettings settings = new BlinkConverterSettings
        {
            Margin = { All = 10 },
            PdfPageSize = PdfPageSize.A4,
            Orientation = PdfPageOrientation.Portrait
        };
        htmlConverter.ConverterSettings = settings;

        PdfDocument pdfDocument = htmlConverter.Convert(processedHtml, "");

        using (MemoryStream ms = new MemoryStream())
        {
            pdfDocument.Save(ms);
            pdfDocument.Close(true);
            return ms.ToArray();
        }
    }
    
    private static string ProcessHtmlTemplate(string htmlTemplate, Dictionary<string, string> dicionarioData)
    {
        if (string.IsNullOrEmpty(htmlTemplate))
        {
            return string.Empty;
        }

        foreach (var entry in dicionarioData)
        {
            string placeholder = $"{{{{{entry.Key}}}}}";
            htmlTemplate = htmlTemplate.Replace(placeholder, entry.Value);
        }
        return htmlTemplate;
    }

}