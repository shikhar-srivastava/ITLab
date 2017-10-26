using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*
---------DETAILS-----------
DataBase name: db1 

Table name: item
Attributes
1. item_id
2. name
3. category (1,2,3,4 for cat1,cat2,cat3,cat4)
4. stock
5. required
6. sales
7. perishable (shelf life same for all perishables or non-perishables 0:non_perishable 1: perishable)
  
Categories: cat1,cat2,cat3,cat4

Table name: _order
1. order_id
2. item_id
3. customer_id
4. quantity
5. status (0:order received 1: out for delivery 2:delivered)
6. time_slot (0:morning, 1:afternoon, 2:evening)
7. van_id

//For every Slot "start": 
Order Table: status=1, Van_id is set
Item Table: sales++,stock--
Van Table: van status=1

//For every Slot "stop": 
Order Table: status=2, Van_id 
Van table: Van status=0

//For Day END action
Item Table: Set stock=0 where perishable=1
Set stock=restock where sales > K_sales and perishable=0
K_sales is Assumed to be 5

//For RESTOCK action
Item table: Set stock=required where stock< required


Table name: van
1. van_id 
2. status (0:in station, 1:in transit)
3. model

NO OF VANS: 3


Table name: employee
1. employee_id
2. name
3. salary

Table name: manufacturer
1. manufacturer_id
2. name
3. item_id

Table name: customer
1. customer_id
2. name
3. address
===========================
*/

public partial class Manager : System.Web.UI.Page
{
    int van_id;    //Get this value from Application_State with Van_id for the day

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (PreviousPage == null)
            {
                Response.Redirect("Manager_Validate.aspx?msg=You+need+to+login+first");
            }
            if (PreviousPage.Auth == false)
            {
                Response.Redirect("Manager_Validate.aspx?msg=Invalid+Login");
            }
        }
    }
    protected void Pre_Render(object sender, EventArgs e)
    {
        this.DataBind();
    }


    protected void handle_starts(object sender, EventArgs e)
    {
        int slot_called; //Get this value from sender
        SqlConnection con = new SqlConnection();
        con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=foodandstuff; Integrated Security=True;Pooling=False";
        //Get Slot Called
        string id="";
        //if (sender.GetType().ToString().EndsWith("Button"))
        //{
            Button btn = (Button)sender;
            id = btn.ID;
        //}
        if (String.Compare("morning_start", id) == 0) slot_called = 0;
        else if (String.Compare("afternoon_start", id) == 0) slot_called = 1;
        else slot_called = 2;

        //Using APPLICATION STATE

        if (Application["van_id"] == null)
        {
            van_id = 0;
            Application["van_id"] = 1;
        }
        else
        {
            int.TryParse(Application["van_id"].ToString(), out van_id);
            Application["van_id"] = (van_id + 1) % 4;
        }
        SqlCommand com_item, com_order, com_van;

        com_order = new SqlCommand("update _order set status=1 and van_id=@van_id where status=0 and time_slot=@slot_called", con);
        com_order.Parameters.AddWithValue("slot_called", slot_called);
        com_order.Parameters.AddWithValue("van_id", van_id);

        com_item = new SqlCommand("update item,_order set item.sales=item.sales+quantity, item.stock=item.stock-quantity where status=1 and item.item_id=order.item_id and order.time_slot=@slot_called", con);
        com_item.Parameters.AddWithValue("slot_called", slot_called);

        com_van = new SqlCommand("update van set status=1 where van_id=@van_id and status=0", con);
        com_van.Parameters.AddWithValue("van_id", van_id);
        try
        {
            con.Open();

            int status = com_order.ExecuteNonQuery();
            status = com_item.ExecuteNonQuery();
            status = com_van.ExecuteNonQuery();
        }
        catch (Exception err) { }
        finally { con.Close(); };
    }

    protected void handle_stops(object sender, EventArgs e)
    {
        int slot_called; //Get this value from sender
        string id="";
        if (sender.GetType().ToString().EndsWith("Button"))
        {
            Button btn = (Button)sender;
            id = btn.ID;
        }
        if (String.Compare("morning_start", id) == 0) slot_called = 0;
        else if (String.Compare("afternoon_start", id) == 0) slot_called = 1;
        else slot_called = 2;


        SqlConnection con = new SqlConnection();
        con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=foodandstuff; Integrated Security=True;Pooling=False";


        SqlCommand com_order, com_van;

        com_order = new SqlCommand("update _order set status=2 where status=1 and time_slot=@slot_called", con);
        com_order.Parameters.AddWithValue("slot_called", slot_called);
        
        com_van = new SqlCommand("update van,_order set van.status=0 where van.status=1 and _order.van_id=van.van_id and _order.status=2 and _order.time_slot=@slot_called", con);
        com_van.Parameters.AddWithValue("van_id", van_id);
        com_van.Parameters.AddWithValue("slot_called", slot_called);
        try
        {
            con.Open();

            int status = com_order.ExecuteNonQuery();
            status = com_van.ExecuteNonQuery();
        }
        catch (Exception err) { }
        finally { con.Close(); };
    }

    protected void handle_restock(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=foodandstuff; Integrated Security=True;Pooling=False";


        SqlCommand com_item;

        com_item = new SqlCommand("update item set stock=required where stock < required", con);
        try
        {
            con.Open();
            int status = com_item.ExecuteNonQuery();
        }
        catch (Exception err) { }
        finally { con.Close(); };
    }


    protected void handle_day_end(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=foodandstuff; Integrated Security=True;Pooling=False";


        SqlCommand com_item_1, com_item_2;

        com_item_1 = new SqlCommand("update item set stock=0 where perishable=1", con);
        com_item_2 = new SqlCommand("update item set stock=required where perishable=0 and sales > 5", con);
        try
        {
            con.Open();
            int status = com_item_1.ExecuteNonQuery();
            status = com_item_2.ExecuteNonQuery();
        }
        catch (Exception err) { }
        finally { con.Close(); };
    }

}