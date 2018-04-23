using System;
using System.IO;

public partial class _Default : System.Web.UI.Page {
    const string ContentFolder = @"~/Content/Demo/Imported";

    protected void Page_Init(object sender, EventArgs e) {
        // Deleting files from server for test project.
        if(!IsPostBack) {
            string serverPath = Server.MapPath(ContentFolder);

            bool isExists = Directory.Exists(serverPath);
            if(!isExists)
                Directory.CreateDirectory(serverPath);
            else {
                string[] files = Directory.GetFiles(serverPath);

                foreach(string path in files) {
                    DateTime dt = File.GetCreationTime(path);
                    if(DateTime.Now.Subtract(dt).TotalMinutes > 60)
                        File.Delete(path);
                }
            }
        }
    }
}