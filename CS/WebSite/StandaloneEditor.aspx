<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StandaloneEditor.aspx.cs"
    Inherits="StandaloneEditor" %>

<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v12.1, Version=12.1.10.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v12.1, Version=12.1.10.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxSpellChecker.v12.1, Version=12.1.10.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxSpellChecker" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>How to use a standalone ASPxHtmlEditor to edit RTF data</title>

    <script type="text/javascript">
        function OnCustomCommand(s, e) {
            switch (e.commandName) {
                case 'Save':
                    s.PerformDataCallback(e.commandName, function() { });
                    break;
                case 'Load':
                    document.location.reload(true);
                    break;
            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <dx:ASPxHtmlEditor ID="he" runat="server" OnCustomDataCallback="he_CustomDataCallback">
        <ClientSideEvents CustomCommand="OnCustomCommand" />
        <Toolbars>
            <dx:HtmlEditorToolbar Name="StandardToolbar2">
                <Items>
                    <dx:ToolbarParagraphFormattingEdit Width="120px">
                        <Items>
                            <dx:ToolbarListEditItem Text="Normal" Value="p" />
                            <dx:ToolbarListEditItem Text="Heading  1" Value="h1" />
                            <dx:ToolbarListEditItem Text="Heading  2" Value="h2" />
                            <dx:ToolbarListEditItem Text="Heading  3" Value="h3" />
                            <dx:ToolbarListEditItem Text="Heading  4" Value="h4" />
                            <dx:ToolbarListEditItem Text="Heading  5" Value="h5" />
                            <dx:ToolbarListEditItem Text="Heading  6" Value="h6" />
                            <dx:ToolbarListEditItem Text="Address" Value="address" />
                            <dx:ToolbarListEditItem Text="Normal (DIV)" Value="div" />
                        </Items>
                    </dx:ToolbarParagraphFormattingEdit>
                    <dx:ToolbarFontNameEdit>
                        <Items>
                            <dx:ToolbarListEditItem Text="Times New Roman" Value="Times New Roman" />
                            <dx:ToolbarListEditItem Text="Tahoma" Value="Tahoma" />
                            <dx:ToolbarListEditItem Text="Verdana" Value="Verdana" />
                            <dx:ToolbarListEditItem Text="Arial" Value="Arial" />
                            <dx:ToolbarListEditItem Text="MS Sans Serif" Value="MS Sans Serif" />
                            <dx:ToolbarListEditItem Text="Courier" Value="Courier" />
                        </Items>
                    </dx:ToolbarFontNameEdit>
                    <dx:ToolbarFontSizeEdit>
                        <Items>
                            <dx:ToolbarListEditItem Text="1 (8pt)" Value="1" />
                            <dx:ToolbarListEditItem Text="2 (10pt)" Value="2" />
                            <dx:ToolbarListEditItem Text="3 (12pt)" Value="3" />
                            <dx:ToolbarListEditItem Text="4 (14pt)" Value="4" />
                            <dx:ToolbarListEditItem Text="5 (18pt)" Value="5" />
                            <dx:ToolbarListEditItem Text="6 (24pt)" Value="6" />
                            <dx:ToolbarListEditItem Text="7 (36pt)" Value="7" />
                        </Items>
                    </dx:ToolbarFontSizeEdit>
                    <dx:ToolbarBoldButton BeginGroup="True">
                    </dx:ToolbarBoldButton>
                    <dx:ToolbarItalicButton>
                    </dx:ToolbarItalicButton>
                    <dx:ToolbarUnderlineButton>
                    </dx:ToolbarUnderlineButton>
                    <dx:ToolbarStrikethroughButton>
                    </dx:ToolbarStrikethroughButton>
                    <dx:ToolbarJustifyLeftButton BeginGroup="True">
                    </dx:ToolbarJustifyLeftButton>
                    <dx:ToolbarJustifyCenterButton>
                    </dx:ToolbarJustifyCenterButton>
                    <dx:ToolbarJustifyRightButton>
                    </dx:ToolbarJustifyRightButton>
                    <dx:ToolbarBackColorButton BeginGroup="True">
                    </dx:ToolbarBackColorButton>
                    <dx:ToolbarFontColorButton>
                    </dx:ToolbarFontColorButton>
                </Items>
            </dx:HtmlEditorToolbar>
            <dx:HtmlEditorToolbar>
                <Items>
                    <dx:CustomToolbarButton CommandName="Save" ViewStyle="Image" ToolTip="Save">
                        <Image Url="Images/Save.png" Width="32px" Height="32px">
                        </Image>
                    </dx:CustomToolbarButton>
                    <dx:CustomToolbarButton CommandName="Load" ViewStyle="Image" ToolTip="Re-Load Page">
                        <Image Url="Images/Load.png" Width="32px" Height="32px">
                        </Image>
                    </dx:CustomToolbarButton>
                </Items>
            </dx:HtmlEditorToolbar>
        </Toolbars>
    </dx:ASPxHtmlEditor>
    </form>
</body>
</html>
