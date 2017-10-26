<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manager.aspx.cs" Inherits="Manager" MasterPageFile="~/MasterPage.master"%>
<%@ PreviousPageType VirtualPath="~/Manager_Validate.aspx"%>

<asp:Content ID="content1" ContentPlaceHolderID="main" runat="server">
    <div class="container">
        <div class="row">
            <div class="card">
          
                <asp:SqlDataSource ID="item_source" runat="server"
                    ConnectionString="<%$ConnectionStrings:foodandstuff %>"
                    SelectCommand="select * from item"
                    UpdateCommand="update item set name=@name, category=@category, stock=@stock, required=@required, perishable=@perishable, sales=@sales where item_id=@item_id"></asp:SqlDataSource>
            
                <asp:SqlDataSource ID="customer_source" runat="server"
                    ConnectionString="<%$ConnectionStrings:foodandstuff %>"
                    SelectCommand="select * from customer"
                    UpdateCommand="update customer set name=@name, address=@address where customer_id=@customer_id"></asp:SqlDataSource>
            
                 <asp:SqlDataSource ID="order_source" runat="server"
                    ConnectionString="<%$ConnectionStrings:foodandstuff %>"
                    SelectCommand="select * from _order"
                    UpdateCommand="update _order set status=@status, quantity=@quantity, time_slot=@time_slot, van_id=van_id where order_id=@order_id and item_id=@item_id and customer_id=@customer_id"></asp:SqlDataSource>
            
                 <asp:SqlDataSource ID="van_source" runat="server"
                    ConnectionString="<%$ConnectionStrings:foodandstuff %>"
                    SelectCommand="select * from van"
                    UpdateCommand="update van set status=@status, model=@model where van_id=@van_id"></asp:SqlDataSource>
            
                 <asp:SqlDataSource ID="manufacturer_source" runat="server"
                    ConnectionString="<%$ConnectionStrings:foodandstuff %>"
                    SelectCommand="select * from manufacturer"
                    UpdateCommand="update manufacturer set name=@name, item_id=@item_id where manufacturer_id=@manufacturer_id"></asp:SqlDataSource>
         
                 <asp:SqlDataSource ID="employee_source" runat="server"
                    ConnectionString="<%$ConnectionStrings:foodandstuff %>"
                    SelectCommand="select * from employee"
                    UpdateCommand="update employee set name=@name, salary=@salary where employee_id=@employee_id"></asp:SqlDataSource>
            
                 Items:  
                 <br/>    
                <asp:GridView ID="item_grid" DataSourceID="item_source" runat="server"
                    AutoGenerateColumns="false"
                    AllowPaging="true" PageSize="3" AllowSorting="true"
                    DataKeyNames="item_id"> 
                    <HeaderStyle BackColor="LightGreen" ForeColor="Red"/>
                    <Columns>
                        <asp:BoundField HeaderText="Item ID" DataField="item_id" ReadOnly="true" SortExpression="item_id"/>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <%# Eval("name") %><br />
                            </ItemTemplate>
                            <EditItemTemplate>
                              <asp:TextBox ID="name_tb" runat="server" Text='<%#Bind("name") %>' Width="90px"></asp:TextBox><br />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Category">
                            <ItemTemplate>
                                <%#Eval("category") %><br />
                            </ItemTemplate>
                            <EditItemTemplate>
                              <asp:TextBox ID="category_tb" runat="server" Text='<%#Bind("category") %>' Width="90px"></asp:TextBox><br />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Stock">
                            <ItemTemplate>
                                <%#Eval("stock") %><br />
                            </ItemTemplate>
                            <EditItemTemplate>
                              <asp:TextBox ID="stock_tb" runat="server" Text='<%#Bind("stock") %>' Width="90px"></asp:TextBox><br />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Restocking Level">
                            <ItemTemplate>
                                <%#Eval("required") %><br />
                            </ItemTemplate>
                            <EditItemTemplate>
                              <asp:TextBox ID="required_tb" runat="server" Text='<%#Bind("required") %>' Width="90px"></asp:TextBox><br />
                            </EditItemTemplate>
                        </asp:TemplateField>
                           <asp:TemplateField HeaderText="Sales">
                            <ItemTemplate>
                                <%#Eval("sales") %><br />
                            </ItemTemplate>
                            <EditItemTemplate>
                              <asp:TextBox ID="sales_tb" runat="server" Text='<%#Bind("sales") %>' Width="90px"></asp:TextBox><br />
                            </EditItemTemplate>
                        </asp:TemplateField>
                           <asp:TemplateField HeaderText="Perishable">
                            <ItemTemplate>
                                <%#Eval("perishable") %><br />
                            </ItemTemplate>
                            <EditItemTemplate>
                              <asp:TextBox ID="perishable_tb" runat="server" Text='<%#Bind("perishable") %>' Width="90px"></asp:TextBox><br />
                            </EditItemTemplate>
                        </asp:TemplateField>
                      <%--<asp:BoundField HeaderText="Van ID" DataField="van_id" ReadOnly="true"/>--%>
                      <asp:CommandField ShowEditButton="true" />
                    </Columns>
                </asp:GridView>
                <br/> 
                Orders
                <br/>
                  <asp:GridView ID="order_grid" DataSourceID="order_source" runat="server"
                    AutoGenerateColumns="false"
                    AllowPaging="true" PageSize="3" AllowSorting="true"
                    DataKeyNames="order_id, item_id, customer_id">
                    <HeaderStyle BackColor="LightGreen" ForeColor="Red"/>
                    <Columns>
                        <asp:BoundField HeaderText="Order ID" DataField="order_id" ReadOnly="true" SortExpression="order_id" />
                        <asp:BoundField HeaderText="Item ID" DataField="item_id" ReadOnly="true" />
                        <asp:BoundField HeaderText="Customer ID" DataField="customer_id" ReadOnly="true" />
                        <asp:BoundField HeaderText="Quantity" DataField="quantity"/>
                        <asp:TemplateField HeaderText="Delivery Status">
                            <ItemTemplate>
                                <%#Eval("status") %><br />
                            </ItemTemplate>
                            <EditItemTemplate>
                              <asp:TextBox ID="status_tb" runat="server" Text='<%#Bind("status") %>' Width="90px"></asp:TextBox><br />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Time Slot">
                            <ItemTemplate>
                                <%#Eval("time_slot") %><br />
                            </ItemTemplate>
                            <EditItemTemplate>
                              <asp:TextBox ID="time_slot_tb" runat="server" Text='<%#Bind("time_slot") %>' Width="90px"></asp:TextBox><br />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Van" DataField="van_id" />
                        <asp:CommandField ShowEditButton="true" />
                    </Columns>
                </asp:GridView>
               <br/> Delivery Van Tracker: <br/>
                <asp:GridView ID="van_grid" DataSourceID="van_source" runat="server"
                    AutoGenerateColumns="false"
                    AllowPaging="true" PageSize="3" AllowSorting="true"
                    DataKeyNames="van_id">
                    <HeaderStyle BackColor="LightGreen" ForeColor="Red"/>
                    <Columns>
                        <asp:BoundField HeaderText="Delivery Van ID" DataField="van_id" ReadOnly="true" SortExpression="van_id"/>
                        <asp:BoundField HeaderText="Model Name" DataField="model" />
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <%#Eval("status") %><br />
                            </ItemTemplate>
                            <EditItemTemplate>
                              <asp:TextBox ID="status_tb_model" runat="server" Text='<%#Bind("status") %>' Width="90px"></asp:TextBox><br />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Van" DataField="van_id" />
                        <asp:CommandField ShowEditButton="true" />
                    </Columns>
                </asp:GridView>
                <br/> Customer Details </br>
                <asp:GridView ID="customer_id" DataSourceID="customer_source" runat="server"
                    AutoGenerateColumns="false"
                    AllowPaging="true" PageSize="3" AllowSorting="true"
                    DataKeyNames="customer_id">
                    <HeaderStyle BackColor="LightGreen" ForeColor="Red"/>
                    <Columns>
                        <asp:BoundField HeaderText="Customer ID" DataField="customer_id" ReadOnly="true" SortExpression="customer_id"/>
                        <asp:BoundField HeaderText="Customer Name" DataField="name" />
                        <asp:BoundField HeaderText="Address" DataField="address" />
                        <asp:CommandField ShowEditButton="true" />
                    </Columns>
                </asp:GridView>
                 <br/> Employee Details: <br/>
                 <asp:GridView ID="employee_id" DataSourceID="employee_source" runat="server"
                    AutoGenerateColumns="false"
                    AllowPaging="true" PageSize="3" AllowSorting="true"
                    DataKeyNames="employee_id">
                    <HeaderStyle BackColor="LightGreen" ForeColor="Red"/>
                    <Columns>
                        <asp:BoundField HeaderText="Employee ID" DataField="employee_id" ReadOnly="true" SortExpression="employee_id"/>
                        <asp:BoundField HeaderText="Employee Name" DataField="name" />
                        <asp:BoundField HeaderText="Salary" DataField="salary" />
                        <asp:CommandField ShowEditButton="true" />
                    </Columns>
                </asp:GridView>
                <br/> Manufacturer Details </br>
                <asp:GridView ID="manufacturer_id" DataSourceID="manufacturer_source" runat="server"
                    AutoGenerateColumns="false"
                    AllowPaging="true" PageSize="3" AllowSorting="true"
                    DataKeyNames="manufacturer_id">
                    <HeaderStyle BackColor="LightGreen" ForeColor="Red"/>
                    <Columns>
                        <asp:BoundField HeaderText="Manufacturer ID" DataField="manufacturer_id" ReadOnly="true" SortExpression="manufacturer_id"/>
                        <asp:BoundField HeaderText="Manufacturer Name" DataField="name" />
                        <asp:BoundField HeaderText="Product Manufactured ID" DataField="item_id" />
                        <asp:CommandField ShowEditButton="true" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

<!-- Buttons for Starting Time-Slot -->
<!-- These buttons help us simulate the passage of time -->
    <div class="container" style="margin-top: 30px;">
        <div class="row">

        <!-- Morning Slot -->
            <div class="col-xs-4">
                    <div class="card text-center">
                        <asp:Button Text="Start Morning Delivery" runat="server" button_id="morning_start" OnClick="handle_starts" CssClass="orange-btn"/>
                        <asp:Button Text="End Morning Delivery" runat="server" button_id="morning_stop" OnClick="handle_stops" CssClass="orange-btn" />
                    </div>
            </div>
        <!-- Afternoon Slot -->
            <div class="col-xs-4">
                    <div class="card text-center">
                        <asp:Button Text="Start Afternoon Delivery" runat="server" button_id="afternoon_start" OnClick="handle_starts" CssClass="orange-btn" />
                        <asp:Button Text="End Afternoon Delivery" runat="server" button_id="afternoon_stop" OnClick="handle_stops" CssClass="orange-btn" />
                    </div>
            </div>
        <!-- Evening Slot -->
            <div class="col-xs-4">
                    <div class="card text-center">
                        <asp:Button Text="Start Evening Delivery" runat="server" button_id="evening_start" OnClick="handle_starts" CssClass="orange-btn" />
                        <asp:Button Text="End Evening Delivery" runat="server" button_id="evening_stop" OnClick="handle_stops" CssClass="orange-btn" />
                    </div>
            </div>
        </div>

        <!--Buttons for RESTOCK and DAY_END Actions-->
        <div class="row card" style="margin: 30px 0">
            <div class="col-xs-6 text-center">
                <asp:Button Text="End Day" runat="server" button_id="day_end" OnClick="handle_day_end" CssClass="orange-btn" />
            </div>
            <div class="col-xs-6 text-center">
                <asp:Button Text="Restock Inventory" runat="server" button_id="restock" OnClick="handle_restock" CssClass="orange-btn" />
            </div>
        </div>
    </div>

</asp:Content>