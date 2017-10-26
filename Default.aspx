<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" MasterPageFile="~/MasterPage.master"%>

<asp:Content ContentPlaceHolderID="main" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm-8 card-container">
                <div class="panel-group card" id="accordion" role="tablist" aria-multiselectable="true">
                    <h4>Our product catalog:</h4>
                    <div class="panel panel-default">
		                <div class="panel-heading" role="tab" id="headingOne"> 
			                <h4 class="panel-title">
				                <a role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
					                Fruits and Vegetables
				                </a>
			                </h4>
		                </div>
		                <div id="collapseOne" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
			                <div class="panel-body">
				                <asp:ListBox ID="c1ListBox" CssClass="item-list" runat="server">
				                </asp:ListBox><br />
                                <asp:RequiredFieldValidator ControlToValidate="c1ListBox" runat="server" Text="Required" ForeColor="Red" ValidationGroup="c1"/>
                                <div>
                                    <span>Quantity: </span>
                                    <asp:TextBox ID="c1Quantity" runat="server" />
                                    <asp:RequiredFieldValidator ControlToValidate="c1Quantity" runat="server" Text="Required" ForeColor="Red" ValidationGroup="c1"/>
                                </div>
                                <asp:Button ID="c1Add" runat="server" Text="Add to cart" OnClick="c1_AddCart" ValidationGroup="c1"/>
                                
			                </div>
		                </div>
	                </div>
	                <div class="panel panel-default">
		                <div class="panel-heading" role="tab" id="headingTwo">
			                <h4 class="panel-title">
				                <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
					                Staples
				                </a>
			                </h4>
		                </div>
		                <div id="collapseTwo" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingTwo">
			                <div class="panel-body">
				                <asp:ListBox ID="c2ListBox" CssClass="item-list" runat="server">
				                </asp:ListBox><br />
                                <asp:RequiredFieldValidator ControlToValidate="c2ListBox" runat="server" Text="Required" ForeColor="Red" ValidationGroup="c2"/>
                                <div>
                                    <span>Quantity: </span>
                                    <asp:TextBox ID="c2Quantity" runat="server" />
                                    <asp:RequiredFieldValidator ControlToValidate="c2Quantity" runat="server" Text="Required" ForeColor="Red" ValidationGroup="c2"/>
                                </div>
                                <asp:Button ID="c2Add" runat="server" Text="Add to cart" OnClick="c2_AddCart" ValidationGroup="c2"/>
			                </div>
		                </div>
	                </div>
	                <div class="panel panel-default">
		                <div class="panel-heading" role="tab" id="headingThree">
			                <h4 class="panel-title">
				                <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
					                Beverages
				                </a>
			                </h4>
		                </div>
		                <div id="collapseThree" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingThree">
			                <div class="panel-body">
				                <asp:ListBox ID="c3ListBox" CssClass="item-list" runat="server">
				                </asp:ListBox><br />
                                <asp:RequiredFieldValidator ControlToValidate="c3ListBox" runat="server" Text="Required" ForeColor="Red" ValidationGroup="c3"/>
                                <div>
                                    <span>Quantity: </span>
                                    <asp:TextBox ID="c3Quantity" runat="server" />
                                    <asp:RequiredFieldValidator ControlToValidate="c3Quantity" runat="server" Text="Required" ForeColor="Red" ValidationGroup="c3"/>
                                </div>
                                <asp:Button ID="c3Add" runat="server" Text="Add to cart" OnClick="c3_AddCart" ValidationGroup="c3"/>
			                </div>
		                </div>
	                </div>
                    <div class="panel panel-default">
		                <div class="panel-heading" role="tab" id="headingFour">
			                <h4 class="panel-title">
				                <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseFour" aria-expanded="false" aria-controls="collapseThree">
					                Personal Care
				                </a>
			                </h4>
		                </div>
		                <div id="collapseFour" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingFour">
			                <div class="panel-body">
				                <asp:ListBox ID="c4ListBox" CssClass="item-list" runat="server">
				                </asp:ListBox><br />
                                <asp:RequiredFieldValidator ControlToValidate="c4ListBox" runat="server" Text="Required" ForeColor="Red" ValidationGroup="c4"/>
                                <div>
                                    <span>Quantity: </span>
                                    <asp:TextBox ID="c4Quantity" runat="server" />
                                    <asp:RequiredFieldValidator ControlToValidate="c4Quantity" runat="server" Text="Required" ForeColor="Red" ValidationGroup="c4"/>
                                </div>
                                <asp:Button ID="c4Add" runat="server" Text="Add to cart" OnClick="c4_AddCart" ValidationGroup="c4"/>
			                </div>
		                </div>
	                </div>
                    
                </div>
            </div>
            <div class="col-sm-4 card-container">
                <div class="card">
                    <div><h4>Cart: </h4></div>
                    <div>
                        <asp:Label id="c1Heading" Text="Fruits" runat="server" visible="false" Font-Bold="true" /><br />
                        <asp:Label ID="c1Items" Text="" runat="server" Visible="false" />
                        <hr id="c1HR" runat="server" visible="false"/>
                    </div>
                    <div>
                        <asp:Label id="c2Heading" Text="Staples" runat="server" Visible="false" Font-Bold="true" /><br />
                        <asp:Label ID="c2Items" Text="" runat="server" Visible="false" />
                        <hr id="c2HR" runat="server" visible="false"/>
                    </div>
                    <div>
                        <asp:Label id="c3Heading" Text="Beverages" runat="server" Visible="false" Font-Bold="true" /><br />
                        <asp:Label ID="c3Items" Text="" runat="server" Visible="false" />
                        <hr id="c3HR" runat="server" visible="false"/>
                    </div>
                    <div>
                        <asp:Label id="c4Heading" Text="Personal Care" runat="server" Visible="false" Font-Bold="true" /><br />
                        <asp:Label ID="c4Items" Text="" runat="server" Visible="false" />
                        <hr id="c4HR" runat="server" visible="false"/>
                    </div>
                    <div class="m-bot-20">
                        <span>Delivery time: </span>
                        <asp:DropDownList ID="timeslot" runat="server" ValidationGroup="Checkout">
                            <asp:ListItem Text="Morning" Value="1" />
                            <asp:ListItem Text="Afternoon" Value="2" />
                            <asp:ListItem Text="Evening" Value="3" />
                            <asp:ListItem Text="Night" Value="4" />
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ControlToValidate="timeslot" Text="Required!" ForeColor="Red" runat="server" />
                    </div>
                    <div class="m-bot-20">
                        <span>Name:     </span><asp:TextBox ID="cust_name" runat="server" />
                        <asp:RequiredFieldValidator ControlToValidate="cust_name" Text="Required!" ForeColor="Red" runat="server" />
                    </div>
                    <div class="m-bot-20">
                        <span> Address: </span>
                        <asp:TextBox ID="address" runat="server" />
                        <asp:RequiredFieldValidator ControlToValidate="address" Text="Required!" ForeColor="Red" runat="server" />
                    </div>
                    <div>
                        <asp:Button ID="checkout" OnClick="checkout_Click" ValidationGroup="Checkouts" runat="server" Text="Checkout" CssClass="orange-btn float-right"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
