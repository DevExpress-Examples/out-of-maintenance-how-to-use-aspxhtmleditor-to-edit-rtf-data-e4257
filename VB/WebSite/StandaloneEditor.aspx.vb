Imports System
Imports System.Text
Imports System.IO
Imports DevExpress.Web
Imports DevExpress.Web.ASPxHtmlEditor

Partial Public Class StandaloneEditor
    Inherits System.Web.UI.Page

    Private Const ContentFolder As String = "~/Content/Demo/Imported"

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
        If (Not IsPostBack) AndAlso (Not IsCallback) Then
            If Session("RTFContent") IsNot Nothing Then
                Dim rtfText As String = Session("RTFContent").ToString()
                Dim byteArray() As Byte = Encoding.ASCII.GetBytes(rtfText)
                Using ms As New MemoryStream(byteArray)
                    he.Import(HtmlEditorImportFormat.Rtf, ms, False, ContentFolder)
                End Using
            Else
                Dim path As String = Server.MapPath("~/Content/Demo/SampleImportDocument.rtf")
                he.Import(path, ContentFolder)
            End If
        End If
    End Sub

    Protected Sub he_CustomDataCallback(ByVal sender As Object, ByVal e As CustomDataCallbackEventArgs)
        Dim editor As ASPxHtmlEditor = TryCast(sender, ASPxHtmlEditor)
        Select Case e.Parameter
            Case "Save"
                Dim rtf As String = String.Empty
                Using ms As New MemoryStream()
                    editor.Export(HtmlEditorExportFormat.Rtf, ms)
                    ms.Flush()
                    ms.Position = 0
                    Using sr As New StreamReader(ms)
                        rtf = sr.ReadToEnd()
                    End Using
                End Using
                SaveToDB(rtf)
        End Select
    End Sub

    Private Sub SaveToDB(ByVal htmlString As String)
        Session("RTFContent") = htmlString
    End Sub
End Class