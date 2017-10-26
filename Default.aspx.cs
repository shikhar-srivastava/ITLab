using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*
—-------DETAILS---------—
DataBase name: db1 

Table name: items
Attributes
1. item_id
2. name
3. category
4. stock
6. required
7. sales
8. perishable (shelf life same for all perishables or non-perishables)
 
 
Categories: cat1,cat2,cat3,cat4
===========================
*/


public partial class _Default : System.Web.UI.Page
{
        //Dataset ds
        // Listbox lb1,lb2,lb3,lb4
        
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //create a Cart object if it doesn't exist in Session
            if(Session["cart"] == null)
            {
                Session["cart"] = new Cart();
            }
            if (Request.Cookies["customer"] != null)
            {
                cust_name.Text = Request.Cookies["customer"]["name"];
                address.Text = Request.Cookies["customer"]["address"];
            }

            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=foodandstuff; Integrated Security=True;Pooling=False");
            SqlDataReader reader;
            int no_categories = 4;
            try
	        {
	            con.Open();
	            for(int i=1;i<= no_categories;i++)
                {
                    SqlCommand com = new SqlCommand("select name from item where category=@category", con);
                    com.Parameters.AddWithValue("category",i);       
                    reader = com.ExecuteReader();
			        while(reader.Read())
			        {
				        if(i==1)c1ListBox.Items.Add(reader["name"].ToString());
				        else if(i==2)c2ListBox.Items.Add(reader["name"].ToString());
				        else if(i==3)c3ListBox.Items.Add(reader["name"].ToString());
				        else if(i==4)c4ListBox.Items.Add(reader["name"].ToString());
			        }
                    reader.Close();
                }
        
	        }catch(Exception ex){ }
	        finally{ con.Close(); }
	    }
    }

    //protected void submit_Click(object sender, EventArgs e)
    //{
    //    SqlConnection con = new SqlConnection();
    //    con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=jHousekeeping; Integrated Security=True;Pooling=False";
    //    SqlCommand com = new SqlCommand("update staff set city=@city where id=@id", con);
    //    com.Parameters.AddWithValue("city", cityLB.SelectedValue);
    //    com.Parameters.AddWithValue("id", staff_id.SelectedValue);
    //    try
    //    {
    //        con.Open();
    //        com.ExecuteNonQuery();
    //    }
    //    catch(Exception err) { }
    //    finally { con.Close(); }
    //}

    //protected void staff_id_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    SqlConnection con = new SqlConnection();
    //    con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=jHousekeeping; Integrated Security=True;Pooling=False";
    //    try
    //    {
    //        con.Open();
    //        SqlCommand com = new SqlCommand("select * from staff where id=" + staff_id.SelectedValue, con);
    //        SqlDataReader reader = com.ExecuteReader();
    //        reader.Read();
    //        Details.Text = 
    //                  staff_id.SelectedValue + " "
    //                + reader["FirstName"].ToString() + " "
    //                + reader["LastName"].ToString() + " "
    //                + reader["Dno"].ToString() + " "
    //                + reader["Street"].ToString() + " "
    //                + reader["City"].ToString() + " "
    //                + reader["State"].ToString() + " "
    //                + reader["zipCode"].ToString() + " ";
    //    }
    //    catch(Exception ex) { }
    //    finally { con.Close(); }
    //}
    protected void c1_AddCart(object sender, EventArgs e)
    {
        Cart c = (Cart)Session["cart"];
        c.c1[c1ListBox.SelectedValue] = int.Parse(c1Quantity.Text);
        Session["cart"] = c;
        updateCart();
    }
    protected void c2_AddCart(object sender, EventArgs e)
    {
        Cart c = (Cart)Session["cart"];
        c.c2[c2ListBox.SelectedValue] = int.Parse(c2Quantity.Text);
        Session["cart"] = c;
        updateCart();
    }
    protected void c3_AddCart(object sender, EventArgs e)
    {
        Cart c = (Cart)Session["cart"];
        c.c3[c3ListBox.SelectedValue] = int.Parse(c3Quantity.Text);
        Session["cart"] = c;
        updateCart();
    }
    protected void c4_AddCart(object sender, EventArgs e)
    {
        Cart c = (Cart)Session["cart"];
        c.c4[c4ListBox.SelectedValue] = int.Parse(c4Quantity.Text);
        Session["cart"] = c;
        updateCart();
    }
    private void updateCart()
    {
        Cart c = (Cart)Session["cart"];
        if (c.c1.Count > 0)
        {
            c1Heading.Visible = true;
            c1Items.Visible = true;
            c1HR.Visible = true;
            c1Items.Text = "";
            foreach(KeyValuePair<string, int> item in c.c1)
            {
                if (item.Value > 0)
                    c1Items.Text += item.Key + ": x" + item.Value + System.Environment.NewLine;
            }
        }
        if (c.c2.Count > 0)
        {
            c2Heading.Visible = true;
            c2Items.Visible = true;
            c2HR.Visible = true;
            c2Items.Text = "";
            foreach (KeyValuePair<string, int> item in c.c2)
            {
                if (item.Value > 0)
                    c2Items.Text += item.Key + ": x" + item.Value + System.Environment.NewLine;
            }
        }
        if (c.c3.Count > 0)
        {
            c3Heading.Visible = true;
            c3Items.Visible = true;
            c3HR.Visible = true;
            c3Items.Text = "";
            foreach (KeyValuePair<string, int> item in c.c3)
            {
                if (item.Value > 0)
                    c3Items.Text += item.Key + ": x" + item.Value + System.Environment.NewLine;
            }
        }
        if (c.c4.Count > 0)
        {
            c4Heading.Visible = true;
            c4Items.Visible = true;
            c4HR.Visible = true;
            c4Items.Text = "";
            foreach (KeyValuePair<string, int> item in c.c4)
            {
                if (item.Value > 0)
                    c4Items.Text += item.Key + ": x" + item.Value + System.Environment.NewLine;

            }
        }
    }

    protected void checkout_Click(object sender, EventArgs e)
    {
        Cart c = (Cart)Session["cart"];
        c.timeslot_id = timeslot.SelectedValue;

        HttpCookie d = new HttpCookie("customer");
        d["name"] = cust_name.Text;
        d["address"] = address.Text;
        d.Expires = DateTime.Now.AddMonths(1);
        Response.Cookies.Add(d);

        
    }
}

[Serializable]
public partial class Cart
{
    public Dictionary<string,int> c1, c2, c3, c4;
    public string timeslot_id;

    public Cart() {
        c1 = new Dictionary<string, int>();
        c2 = new Dictionary<string, int>();
        c3 = new Dictionary<string, int>();
        c4 = new Dictionary<string, int>();
        timeslot_id = "1";
    }
}