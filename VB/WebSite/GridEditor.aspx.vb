Imports System
Imports System.IO
Imports System.Text
Imports System.Web.UI.WebControls
Imports DevExpress.Web
Imports DevExpress.Web.ASPxHtmlEditor
Imports DevExpress.Web.Data
Imports DevExpress.XtraRichEdit

Partial Public Class GridEditor
    Inherits System.Web.UI.Page

    Private Const ContentFolder As String = "~/Content/Demo/Imported"

    Protected Sub he_Init(ByVal sender As Object, ByVal e As EventArgs)
        Dim htmlEditor As ASPxHtmlEditor = TryCast(sender, ASPxHtmlEditor)
        Dim container As GridViewDataItemTemplateContainer = TryCast(htmlEditor.NamingContainer, GridViewDataItemTemplateContainer)
        Dim rtfText As String = container.Grid.GetRowValues(container.VisibleIndex, "RtfContent").ToString()

        Dim byteArray() As Byte = Encoding.ASCII.GetBytes(rtfText)
        Using ms As New MemoryStream(byteArray)
            htmlEditor.Import(HtmlEditorImportFormat.Rtf, ms, False, ContentFolder)
        End Using
    End Sub

    Protected Sub gv_RowUpdating(ByVal sender As Object, ByVal e As ASPxDataUpdatingEventArgs)
        Dim gridView As ASPxGridView = TryCast(sender, ASPxGridView)
        Dim columnRftContent As GridViewDataColumn = TryCast(gridView.Columns("RtfContent"), GridViewDataColumn)
        Dim htmlEditor As ASPxHtmlEditor = TryCast(gridView.FindEditRowCellTemplateControl(columnRftContent, "he"), ASPxHtmlEditor)
        e.NewValues("RtfContent") = GetRtfTextFromASPxHtmlEditor(htmlEditor)

        Throw New InvalidOperationException("Data modifications are not allowed in online demos")
        'Note that data modifications are not allowed in online demos. To allow editing in local/offline mode, download the example and comment out the "throw..." operation in the ASPxGridView.RowUpdating event handler.
    End Sub

    Protected Sub popup_WindowCallback(ByVal source As Object, ByVal e As PopupWindowCallbackArgs)
        Dim rtfText As String = gv.GetRowValuesByKeyValue(e.Parameter, "RtfContent").ToString()
        Dim ltl As Literal = TryCast(e.Window.FindControl("ltl"), Literal)
        ltl.Text = GetHtmlTextFromDocumentServer(rtfText)
    End Sub

    Private Shared Function GetRtfTextFromASPxHtmlEditor(ByVal htmlEditor As ASPxHtmlEditor) As String
        Dim rtfText As String
        Using ms As New MemoryStream()
            htmlEditor.Export(HtmlEditorExportFormat.Rtf, ms)
            ms.Flush()
            ms.Position = 0

            Dim reader As New StreamReader(ms)
            rtfText = reader.ReadToEnd()
        End Using
        Return rtfText
    End Function

    Private Shared Function GetHtmlTextFromDocumentServer(ByVal rtfText As String) As String
        If String.IsNullOrEmpty(rtfText) Then
            Return "No Data"
        End If

        Dim htmlText As String
        Using stream As New MemoryStream()
            Dim documentServer As New RichEditDocumentServer()
            documentServer.Options.Export.Html.ExportRootTag = DevExpress.XtraRichEdit.Export.Html.ExportRootTag.Body
            documentServer.Options.Export.Html.EmbedImages = True
            documentServer.RtfText = rtfText
            documentServer.SaveDocument(stream, DocumentFormat.Html)

            stream.Position = 0
            Dim reader As New StreamReader(stream)
            htmlText = reader.ReadToEnd()
        End Using

        Return htmlText
    End Function
End Class