<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeFile="InsertAdvisorTimes.aspx.cs" Inherits="_Default" %>
<html>
    <head>
     <title>Website</title>
     <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
     <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
     <link rel="stylesheet" href="/resources/demos/style.css">
     <link rel="stylesheet" type="text/css" href="css/bootstrap.css" />
     <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
     <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
     <script>
     $( function() {
       $( "#datepicker" ).datepicker({
           onSelect: function(date) {
               $("#<%= Hidden.ClientID %>").val(date);
            },
       });
     } );
     </script>
    <style>

        .gridViewPager span, a
{
    border-top-left-radius: 3px;
    border-bottom-left-radius: 3px;
    border-top-right-radius: 3px;
    border-bottom-right-radius: 3px;
    border: 1px solid;
    text-decoration: none;
    text-size-adjust:100%;

}
        .gridViewPager td
{
	padding-left: 4px;
	padding-right: 4px;
	padding-top: 1px;
	padding-bottom: 2px;

}

    </style>
    </head>


    <body>

    
    <asp:Panel runat="server" ID="pnl_AvailableTimes">
    <form runat="server">
    <div class="col-sm-3">
        <h1>Available Times</h1>
        <asp:Label ID="hold" runat="server"></asp:Label>
        <asp:HiddenField ID="advisor" runat="server" />
        <div ID="datepicker" runat="server"></div>
        <asp:HiddenField ID="Hidden" runat="server"/>
        <div style="text-align:left;width:76%;">
        <asp:DropDownList runat="server" class="form-control" ID="Time">
            <asp:ListItem Value="0:00">12:00 AM</asp:ListItem>
            <asp:ListItem Value="0:30">12:30 AM</asp:ListItem>
            <asp:ListItem Value="1:00">1:00 AM</asp:ListItem>
            <asp:ListItem Value="1:30">1:30 AM</asp:ListItem>
            <asp:ListItem Value="2:00">2:00 AM</asp:ListItem>
            <asp:ListItem Value="2:30">2:30 AM</asp:ListItem>
            <asp:ListItem Value="3:00">3:00 AM</asp:ListItem>
            <asp:ListItem Value="3:30">3:30 AM</asp:ListItem>
            <asp:ListItem Value="4:00">4:00 AM</asp:ListItem>
            <asp:ListItem Value="4:30">4:30 AM</asp:ListItem>
            <asp:ListItem Value="5:00">5:00 AM</asp:ListItem>
            <asp:ListItem Value="5:30">5:30 AM</asp:ListItem>
            <asp:ListItem Value="6:00">6:00 AM</asp:ListItem>
            <asp:ListItem Value="6:30">6:30 AM</asp:ListItem>
            <asp:ListItem Value="7:00">7:00 AM</asp:ListItem>
            <asp:ListItem Value="7:30">7:30 AM</asp:ListItem>
            <asp:ListItem Value="8:00">8:00 AM</asp:ListItem>
            <asp:ListItem Value="8:30">8:30 AM</asp:ListItem>
            <asp:ListItem Value="9:00">9:00 AM</asp:ListItem>
            <asp:ListItem Value="9:30">9:30 AM</asp:ListItem>
            <asp:ListItem Value="10:00">10:00 AM</asp:ListItem>
            <asp:ListItem Value="10:30">10:30 AM</asp:ListItem>
            <asp:ListItem Value="11:00">11:00 AM</asp:ListItem>
            <asp:ListItem Value="11:30">11:30 AM</asp:ListItem>
            <asp:ListItem Value="12:00">12:00 PM</asp:ListItem>
            <asp:ListItem Value="12:30">12:30 PM</asp:ListItem>
            <asp:ListItem Value="13:00">1:00 PM</asp:ListItem>
            <asp:ListItem Value="13:30">1:30 PM</asp:ListItem>
            <asp:ListItem Value="14:00">2:00 PM</asp:ListItem>
            <asp:ListItem Value="14:30">2:30 PM</asp:ListItem>
            <asp:ListItem Value="15:00">3:00 PM</asp:ListItem>
            <asp:ListItem Value="15:30">3:30 PM</asp:ListItem>
            <asp:ListItem Value="16:00">4:00 PM</asp:ListItem>
            <asp:ListItem Value="16:30">4:30 PM</asp:ListItem>
            <asp:ListItem Value="17:00">5:00 PM</asp:ListItem>
            <asp:ListItem Value="17:30">5:30 PM</asp:ListItem>
            <asp:ListItem Value="18:00">6:00 PM</asp:ListItem>
            <asp:ListItem Value="18:30">6:30 PM</asp:ListItem>
            <asp:ListItem Value="19:00">7:00 PM</asp:ListItem>
            <asp:ListItem Value="19:30">7:30 PM</asp:ListItem>
            <asp:ListItem Value="20:00">8:00 PM</asp:ListItem>
            <asp:ListItem Value="20:30">8:30 PM</asp:ListItem>
            <asp:ListItem Value="21:00">9:00 PM</asp:ListItem>
            <asp:ListItem Value="21:30">9:30 PM</asp:ListItem>
            <asp:ListItem Value="22:00">10:00 PM</asp:ListItem>
            <asp:ListItem Value="22:30">10:30 PM</asp:ListItem>
            <asp:ListItem Value="23:00">11:00 PM</asp:ListItem>
            <asp:ListItem Value="23:30">11:30 PM</asp:ListItem>
        </asp:DropDownList>
           
            <asp:LinkButton 
            runat="server" 
            CssClass="btn btn-default btn-lg"    
            OnClick="GetDate" style="width:100%;">
      <span class="glyphicon glyphicon-circle-arrow-right"></span>
</asp:LinkButton>
        </div>
    </div>
    <div class="col-sm-3" id="CurrentTimes">
    <br /><br />

    <h3>Current Available Times</h3>
    <asp:GridView ID="result" runat="server" style="width:100%;margin-bottom:5px;"
             BackColor="#ffffff" HorizontalAlign="center"
             CellPadding="15" CellSpacing="15" GridLines ="none" AllowPaging ="true" AllowSorting="true" OnPageIndexChanging="Paging" OnSorting="Sort" OnRowDeleting="DeleteTime" AutoGenerateColumns ="false" PageSize="3">
         <PagerStyle CssClass="gridViewPager" HorizontalAlign="center"></PagerStyle>
   <Columns>
     <asp:BoundField DataField="Date" HeaderText="Date"/>
        <asp:BoundField DataField="Time" HeaderText="Time" />
        <asp:CommandField ShowDeleteButton="True" ButtonType="Button"  ControlStyle-CssClass="btn btn-default btn-sm"/>
  
    </Columns>

    </asp:GridView>
    </div>
    </form>
    </asp:Panel>
    
    </body>
</html>

