using System;
using System.Text;
using System.IO;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxHtmlEditor;

public partial class StandaloneEditor : System.Web.UI.Page {
    const string ContentFolder = @"~/Content/Demo/Imported";

    protected void Page_Init(object sender, EventArgs e) {
        if(!IsPostBack && !IsCallback) {
            if (Session["RTFContent"] != null) {
                string rtfText = Session["RTFContent"].ToString();
                byte[] byteArray = Encoding.ASCII.GetBytes(rtfText);
                using (MemoryStream ms = new MemoryStream(byteArray)) {
                    he.Import(HtmlEditorImportFormat.Rtf, ms, false, ContentFolder);
                }
            } else {
                string path = Server.MapPath("~/Content/Demo/SampleImportDocument.rtf");
                he.Import(path, ContentFolder);
            }
        }
    }

    protected void he_CustomDataCallback(object sender, CustomDataCallbackEventArgs e) {
        ASPxHtmlEditor editor = sender as ASPxHtmlEditor;
        switch (e.Parameter) {
            case "Save":
                string rtf = string.Empty;
                using (MemoryStream ms = new MemoryStream()) {
                    editor.Export(HtmlEditorExportFormat.Rtf, ms);
                    ms.Flush();
                    ms.Position = 0;
                    using (StreamReader sr = new StreamReader(ms)) {
                        rtf = sr.ReadToEnd();
                    }
                }
                SaveToDB(rtf);
                break;
        }
    }

    private void SaveToDB(string htmlString) {
        Session["RTFContent"] = htmlString;
    }
}