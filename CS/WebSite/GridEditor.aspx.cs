using System;
using System.IO;
using System.Text;
using System.Web.UI.WebControls;
using DevExpress.Web;
using DevExpress.Web.ASPxHtmlEditor;
using DevExpress.Web.Data;
using DevExpress.XtraRichEdit;

public partial class GridEditor : System.Web.UI.Page {
    const string ContentFolder = @"~/Content/Demo/Imported";

    protected void he_Init(object sender, EventArgs e) {
        ASPxHtmlEditor htmlEditor = sender as ASPxHtmlEditor;
        GridViewDataItemTemplateContainer container = htmlEditor.NamingContainer as GridViewDataItemTemplateContainer;
        string rtfText = container.Grid.GetRowValues(container.VisibleIndex, "RtfContent").ToString();

        byte[] byteArray = Encoding.ASCII.GetBytes(rtfText);
        using(MemoryStream ms = new MemoryStream(byteArray)) {
            htmlEditor.Import(HtmlEditorImportFormat.Rtf, ms, false, ContentFolder);
        }
    }

    protected void gv_RowUpdating(object sender, ASPxDataUpdatingEventArgs e) {
        ASPxGridView gridView = sender as ASPxGridView;
        GridViewDataColumn columnRftContent = gridView.Columns["RtfContent"] as GridViewDataColumn;
        ASPxHtmlEditor htmlEditor = gridView.FindEditRowCellTemplateControl(columnRftContent, "he") as ASPxHtmlEditor;
        e.NewValues["RtfContent"] = GetRtfTextFromASPxHtmlEditor(htmlEditor);

        throw new InvalidOperationException("Data modifications are not allowed in online demos");
        //Note that data modifications are not allowed in online demos. To allow editing in local/offline mode, download the example and comment out the "throw..." operation in the ASPxGridView.RowUpdating event handler.
    }

    protected void popup_WindowCallback(object source, PopupWindowCallbackArgs e) {
        string rtfText = gv.GetRowValuesByKeyValue(e.Parameter, "RtfContent").ToString();
        Literal ltl = e.Window.FindControl("ltl") as Literal;
        ltl.Text = GetHtmlTextFromDocumentServer(rtfText);
    }

    private static string GetRtfTextFromASPxHtmlEditor(ASPxHtmlEditor htmlEditor) {
        string rtfText;
        using(MemoryStream ms = new MemoryStream()) {
            htmlEditor.Export(HtmlEditorExportFormat.Rtf, ms);
            ms.Flush();
            ms.Position = 0;

            StreamReader reader = new StreamReader(ms);
            rtfText = reader.ReadToEnd();
        }
        return rtfText;
    }

    private static string GetHtmlTextFromDocumentServer(string rtfText) {
        if(string.IsNullOrEmpty(rtfText)) return "No Data";

        string htmlText;
        using(MemoryStream stream = new MemoryStream()) {
            RichEditDocumentServer documentServer = new RichEditDocumentServer();
            documentServer.Options.Export.Html.ExportRootTag = DevExpress.XtraRichEdit.Export.Html.ExportRootTag.Body;
            documentServer.Options.Export.Html.EmbedImages = true;
            documentServer.RtfText = rtfText;
            documentServer.SaveDocument(stream, DocumentFormat.Html);

            stream.Position = 0;
            StreamReader reader = new StreamReader(stream);
            htmlText = reader.ReadToEnd();
        }

        return htmlText;
    }
}