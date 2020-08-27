<%@ Page Language="vb" AutoEventWireup="true" CodeFile="GridEditor.aspx.vb" Inherits="GridEditor" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>


<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v15.1, Version=15.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxSpellChecker.v15.1, Version=15.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxSpellChecker" TagPrefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>How to use an ASPxHtmlEditor to edit RTF data in ASPxGridView</title>
    <script type="text/javascript">
        function OnMoreInfoClick(element, key) {
            popup.ShowAtElement(element);
            popup.PerformCallback(key);
        }

        function popup_OnCloseUp(s, e) {
            s.SetContentHtml("");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <dx:ASPxPopupControl ID="popup" runat="server" ClientInstanceName="popup" AllowDragging="true"
            CloseAction="OuterMouseClick" PopupHorizontalAlign="OutsideRight" OnWindowCallback="popup_WindowCallback"
            ScrollBars="Auto" Width="300px" Height="300px">
            <ClientSideEvents CloseUp="popup_OnCloseUp" />
            <ContentCollection>
                <dx:PopupControlContentControl>
                    <asp:Literal ID="ltl" runat="server"></asp:Literal>
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>
        <dx:ASPxGridView ID="gv" runat="server" AutoGenerateColumns="False" DataSourceID="ads"
            KeyFieldName="ID" OnRowUpdating="gv_RowUpdating">
            <Columns>
                <dx:GridViewCommandColumn VisibleIndex="0" ShowEditButton="True"/>
                <dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True" VisibleIndex="1">
                    <EditFormSettings Visible="False" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Trademark" VisibleIndex="2">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Model" VisibleIndex="3">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="RtfContent" VisibleIndex="4">
                    <DataItemTemplate>
                        <a href="javascript:void(0);" onclick="OnMoreInfoClick(this, '<%#Container.KeyValue%>')">
                            More Info...</a>
                    </DataItemTemplate>
                    <EditItemTemplate>
                        <dx:ASPxHtmlEditor ID="he" runat="server" OnInit="he_Init">
                        </dx:ASPxHtmlEditor>
                    </EditItemTemplate>
                </dx:GridViewDataTextColumn>
            </Columns>
        </dx:ASPxGridView>
        <asp:AccessDataSource ID="ads" runat="server" DataFile="~/App_Data/CarsDB.mdb" SelectCommand="SELECT [ID], [Trademark], [Model], [RtfContent] FROM [Cars]"
            UpdateCommand="UPDATE [Cars] SET [Trademark] = ?, [Model] = ?, [RtfContent] = ? WHERE [ID] = ?">
            <UpdateParameters>
                <asp:Parameter Name="Trademark" Type="String" />
                <asp:Parameter Name="Model" Type="String" />
                <asp:Parameter Name="RtfContent" Type="String" />
                <asp:Parameter Name="ID" Type="Int32" />
            </UpdateParameters>
        </asp:AccessDataSource>
    </form>
</body>
</html>