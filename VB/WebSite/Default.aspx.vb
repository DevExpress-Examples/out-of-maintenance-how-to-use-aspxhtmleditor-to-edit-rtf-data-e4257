Imports System
Imports System.IO

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Private Const ContentFolder As String = "~/Content/Demo/Imported"

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
        ' Deleting files from server for test project.
        If Not IsPostBack Then
            Dim serverPath As String = Server.MapPath(ContentFolder)

            Dim isExists As Boolean = Directory.Exists(serverPath)
            If Not isExists Then
                Directory.CreateDirectory(serverPath)
            Else
                Dim files() As String = Directory.GetFiles(serverPath)

                For Each path As String In files
                    Dim dt As Date = File.GetCreationTime(path)
                    If Date.Now.Subtract(dt).TotalMinutes > 60 Then
                        File.Delete(path)
                    End If
                Next path
            End If
        End If
    End Sub
End Class