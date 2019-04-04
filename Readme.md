<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
* [GridEditor.aspx](./CS/WebSite/GridEditor.aspx) (VB: [GridEditor.aspx](./VB/WebSite/GridEditor.aspx))
* [GridEditor.aspx.cs](./CS/WebSite/GridEditor.aspx.cs) (VB: [GridEditor.aspx.vb](./VB/WebSite/GridEditor.aspx.vb))
* [StandaloneEditor.aspx](./CS/WebSite/StandaloneEditor.aspx) (VB: [StandaloneEditor.aspx](./VB/WebSite/StandaloneEditor.aspx))
* [StandaloneEditor.aspx.cs](./CS/WebSite/StandaloneEditor.aspx.cs) (VB: [StandaloneEditor.aspx.vb](./VB/WebSite/StandaloneEditor.aspx.vb))
<!-- default file list end -->
# How to use ASPxHtmlEditor to edit RTF data


<p><strong>Important Note</strong><br /><br />In version 14.1 we've developed a great new <a href="http://ASP.NET">ASP.NET</a> editor that may better fit your scenario. Read more about the new ASPxRichEdit here: <a href="https://community.devexpress.com/blogs/aspnet/archive/2014/11/12/asp-net-word-inspired-rich-text-editor-preview-release-coming-soon.aspx">https://community.devexpress.com/blogs/aspnet/archive/2014/11/12/asp-net-word-inspired-rich-text-editor-preview-release-coming-soon.aspx</a></p>
<p><br /><a href="https://www.devexpress.com/Support/Center/p/T260978">How to use ASPxRichEdit to edit RTF data in ASPxGridView's EditForm</a><br /><br /><strong>For previous versions:</strong><br /><br />It is possible to use ASPxHtmlEditor WYSIWYG capabilities to edit rich text, for example, imported from the RTF file.</p>
<p>This example illustrates how to:</p>
<p>- Store real RTF content in a data source;</p>
<p>- Edit this RTF content within ASPxHtmlEditor.</p>
<p>The StandaloneEditor page:</p>
<p>When a page is loaded for the first time, ASPxHtmlEditor imports either RTF content saved in the Session state or a real RTF document located on a web server via the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxHtmlEditorASPxHtmlEditor_Importtopic"><u>ASPxHtmlEditor.Import</u></a> method.</p>
<p>An end-user is able to click the custom ASPxHtmlEditor toolbar item to save the changes. To retrieve the modified rich content from the HTML Editor the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxHtmlEditorASPxHtmlEditor_Exporttopic"><u>ASPxHtmlEditor.Export</u></a> method is used.</p>
<p>The GridEditor page:</p>
<p>- ASPxHtmlEditor is placed into a column’s EditItemTemplate;</p>
<p>- The ASPxHtmlEditor content is populated by handling the ASPxHtmlEditor.Init event: A real column’s RTF data is imported via the ASPxHtmlEditor.Import method.</p>
<p>- When an end-user clicks the Update button, the ASPxGridView.RowUpdating event is raised;</p>
<p>- A reference to the ASPxHtmlEditor is retrieved via the ASPxGridView.FindEditRowCellTemplateControl method;</p>
<p>- A modified RTF content is retrieved from the ASPxHtmlEditor.Html via the ASPxHtmlEditor.Export method and passed back to the datasource.</p>
<p>- Clicking the “More Info” link invokes ASPxPopupControl, which populates its content via its built-in callback functionality. The popup loads the clicked row’s RTF content transformed to the HTML via our cross-platform <a href="http://help.devexpress.com/#DocumentServer/CustomDocument15097"><u>RichEditDocumentServer</u></a> engine.</p>
<p>Please note that this example can't run on the Web because it requires file creation during its running, but the file creation is prevented on our example server.</p>

<br/>


