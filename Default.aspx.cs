using System;
using System.Collections.Generic;
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
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=db1; Integrated Security=True;Pooling=False";
            SqlCommand com;
            SqlDataAdapter ada;
            com= new SqlCommand("select name from items where category=@category", con);
            SqlDataReader reader;
            int no_categories = 4;
            try
	{
	    con.Open();
	    for(int i=1;i<= no_categories;i++)
            {
                      
                    com.Parameters.AddWithValue("category","cat"+i.ToString());       
                    reader = com.ExecuteReader();
			while(reader.read())
			{
				if(i==1)l1.Items.Add(new ListItem(reader["name"]));
				if(i==2)l2.Items.Add(new ListItem(reader["name"]));
				if(i==3)l3.Items.Add(new ListItem(reader["name"]));
				if(i==4)l4.Items.Add(new ListItem(reader["name"]));
			}
            }
        
	}catch(Exception e){ }
	finally
	{
		con.Close();
	}

	}
    }

    protected void submit_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=jHousekeeping; Integrated Security=True;Pooling=False";
        SqlCommand com = new SqlCommand("update staff set city=@city where id=@id", con);
        com.Parameters.AddWithValue("city", cityLB.SelectedValue);
        com.Parameters.AddWithValue("id", staff_id.SelectedValue);
        try
        {
            con.Open();
            com.ExecuteNonQuery();
        }
        catch(Exception err) { }
        finally { con.Close(); }
    }

    protected void staff_id_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=jHousekeeping; Integrated Security=True;Pooling=False";
        try
        {
            con.Open();
            SqlCommand com = new SqlCommand("select * from staff where id=" + staff_id.SelectedValue, con);
            SqlDataReader reader = com.ExecuteReader();
            reader.Read();
            Details.Text = 
                      staff_id.SelectedValue + " "
                    + reader["FirstName"].ToString() + " "
                    + reader["LastName"].ToString() + " "
                    + reader["Dno"].ToString() + " "
                    + reader["Street"].ToString() + " "
                    + reader["City"].ToString() + " "
                    + reader["State"].ToString() + " "
                    + reader["zipCode"].ToString() + " ";
        }
        catch(Exception ex) { }
        finally { con.Close(); }
    }
}

//----Kinkdom----
}