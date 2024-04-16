using ABS.FileGeneration;
using System;
using System.IO;

namespace ABS.WebApp
{
    public partial class DownLoadExcel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                FileGenerationService obj = new FileGenerationService();
                MemoryStream mstream = obj.GenerateFileAsync().Result;
                byte[] byteArray = mstream.ToArray();
                mstream.Flush();
                mstream.Close();
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=Test.xlsx");
                Response.AddHeader("Content-Length", byteArray.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.BinaryWrite(byteArray);
            }
            catch (Exception ex)
            {
                Response.Write("Something went wrong :" + ex.Message + "Trace :" + ex.StackTrace);
            }
        }
    }
}