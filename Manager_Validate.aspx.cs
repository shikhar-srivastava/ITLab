using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_Validate : System.Web.UI.Page
{
    private bool authorized_user = false;
    public bool Auth {
        get { return authorized_user; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.QueryString["msg"] != null)
        {
            msg.Text = Request.QueryString["msg"];
        }
    }

    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        foreach (char c in args.Value)
        {
            if (c < '0' || c > '9')
            {
                args.IsValid = false;
                return;
            }
        }
        args.IsValid = true;
    }

    protected void submit_Click(object sender, EventArgs e)
    {
        if(passcode.Text == "1337")
        {
            authorized_user = true;
        }
        else
        {
            msg.Text = "Incorrect passcode!";
        }
    }
}