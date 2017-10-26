using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
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
    Dictionary<string, int> item_IDs = new Dictionary<string, int>();

    protected void Page_Load(object sender, EventArgs e)
    {
        item_IDs.Add("Apple", 0);
        item_IDs.Add("Banana", 1);
        item_IDs.Add("Guava", 2);
        item_IDs.Add("Watermelon", 3);
        item_IDs.Add("Rice", 4);
        item_IDs.Add("Masala", 5);
        item_IDs.Add("Coke", 6);
        item_IDs.Add("Juice", 7);
        item_IDs.Add("Shampoo", 8);
        item_IDs.Add("Soap", 9);
        item_IDs.Add("Conditioner", 10);




        if (!IsPostBack)
        {
            //create a Cart object if it doesn't exist in Session
            if (Session["cart"] == null)
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
                DataSet[] ds = new DataSet[4];
                con.Open();
                for (int i = 1; i <= no_categories; i++)
                {
                    SqlCommand com = new SqlCommand("select item_id, name from item where category=@category", con);
                    com.Parameters.AddWithValue("category", i);
                    SqlDataAdapter ada = new SqlDataAdapter(com);
                    ds[i-1] = new DataSet();
                    ada.Fill(ds[i-1]);
                }
                c1ListBox.DataSource = ds[0]; c1ListBox.DataTextField = "name"; c1ListBox.DataValueField = "name"; c1ListBox.DataBind();
                c2ListBox.DataSource = ds[1]; c1ListBox.DataTextField = "name"; c2ListBox.DataValueField = "name"; c2ListBox.DataBind();
                c1ListBox.DataSource = ds[2]; c1ListBox.DataTextField = "name"; c3ListBox.DataValueField = "name"; c3ListBox.DataBind();
                c1ListBox.DataSource = ds[3]; c1ListBox.DataTextField = "name"; c4ListBox.DataValueField = "name"; c4ListBox.DataBind();
            }
            catch (Exception ex) { Response.Write(ex.StackTrace + "<br/>" + ex.Message); }
            finally { con.Close(); }
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
            foreach (KeyValuePair<string, int> item in c.c1)
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

        //add customer details to cookie for persistence
        HttpCookie d = new HttpCookie("customer");
        d["name"] = cust_name.Text;
        d["address"] = address.Text;
        d.Expires = DateTime.Now.AddMonths(1);
        Response.Cookies.Add(d);

        //insert order details into customer
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=foodandstuff; Integrated Security=True;Pooling=False");
        try {
            con.Open();
            //Getting Next ORDER_ID
            SqlCommand com = new SqlCommand("select max(order_id) as next_id from _order", con);
            SqlDataReader reader = com.ExecuteReader();
            int order_id = 0;
            reader.Read();
            order_id = int.Parse(reader["next_id"].ToString()) + 1;
            reader.Close();

            //Getting Next Customer_ID

            com = new SqlCommand("select max(customer_id)  as next_id from customer", con);
            reader = com.ExecuteReader();
            int customer_id;
            reader.Read();
            customer_id = int.Parse(reader["next_id"].ToString()) + 1;
            reader.Close();
            SqlCommand insc = new SqlCommand("insert into customer(customer_id,name,address) values(@customer_id,@name,@address)", con);
            insc.Parameters.AddWithValue("customer_id", customer_id);
            insc.Parameters.AddWithValue("name", cust_name.Text);
            insc.Parameters.AddWithValue("address", address.Text);
            insc.ExecuteNonQuery();

            Dictionary<string, int> cat = c.c1;
            for (int i = 1; i <= 4; i++)
            {
                if (i == 1) cat = c.c1;
                else if (i == 2) cat = c.c2;
                else if (i == 3) cat = c.c3;
                else if (i == 4) cat = c.c4;

                if (cat.Count > 0)
                {
                    foreach (KeyValuePair<string, int> item in cat)
                    {
                        SqlCommand ins = new SqlCommand("insert into _order (order_id, item_id, customer_id, quantity, status, time_slot) values(@order_id,@item_id,@customer_id,@quantity,@status,@time_slot)",con);
                        ins.Parameters.AddWithValue("order_id", order_id);
                        ins.Parameters.AddWithValue("item_id", item_IDs[item.Key]);
                        ins.Parameters.AddWithValue("customer_id", customer_id);
                        ins.Parameters.AddWithValue("quantity", item.Value);
                        ins.Parameters.AddWithValue("status", 0);
                        ins.Parameters.AddWithValue("time_slot", timeslot.SelectedItem.Value);
                        ins.ExecuteNonQuery();
                    }
                }
            }
        }
        catch(Exception ex) { Response.Write(ex.StackTrace + "<br/>" + ex.Message); }
        finally { con.Close(); }
    }
}

[Serializable]
public partial class Cart
{
    public Dictionary<string, int> c1, c2, c3, c4;

    public Cart()
    {
        c1 = new Dictionary<string, int>();
        c2 = new Dictionary<string, int>();
        c3 = new Dictionary<string, int>();
        c4 = new Dictionary<string, int>();
    }
}
