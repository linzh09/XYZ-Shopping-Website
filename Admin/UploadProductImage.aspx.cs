using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

//public partial class Admin_UploadProductImage : System.Web.UI.Page
public partial class Admin_UploadProductImage : MyBasePage
{
    public Admin_UploadProductImage()
    {
        requireSSL = true;
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnUploadPImage_Click(object sender, EventArgs e)
    {
        string dir = Server.MapPath("../PImages");
        // make sure uploaded files folder has disabled script and  
        // execute permissions but gives write permissions to "everyone"
        // this could be a security risk, so the upload page should not
        // not be an open acess page, i.e., only an admin could access it
        FileInfo fi = new FileInfo(txtFname.Text);
        string fname = Path.Combine(dir, fi.Name);
        if (null != fUpload.PostedFile)
        {
            try
            {
                fUpload.PostedFile.SaveAs(fname);
                lblStatus.Text = "File uplodaded successfully";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "error" + ex.Message;
            }
        }
        else
            lblStatus.Text = "no file specified:" + fname;

    }
}
