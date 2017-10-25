<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" MasterPageFile="~/MasterPage.master"%>

<asp:Content ContentPlaceHolderID="main" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm-9 card-container" style="height: 1000px;">
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
		                <div id="collapseOne" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
			                <div class="panel-body">
				                <asp:ListBox ID="FruitsListBox" CssClass="item-list" runat="server">
                                    <asp:ListItem Text="Banana" />
                                    <asp:ListItem Text="Apples" />
                                    <asp:ListItem Text="Guavava" />
                                    <asp:ListItem Text="Chikoo" />
				                </asp:ListBox>
                                <asp:Button ID="FruitsAdd" runat="server" Text="Add to cart" />
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
				                Insert ListBox here
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
				                More stuff here
			                </div>
		                </div>
	                </div>		
                </div>
            </div>
            <div class="col-sm-3 card-container">
                <div class="card">
                    <div><h4>Cart: </h4></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
