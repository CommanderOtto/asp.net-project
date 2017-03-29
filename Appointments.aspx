<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Appointments.aspx.cs" Inherits="Appointments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>KSB - Advisor Portal</title>
    <meta charset="utf-8" />
    <meta name="Register" content="register, form" />
    <link rel="stylesheet" type="text/css" href="css/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="css/main.css"/>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    
    <script>
    $( function() {
    $( "#datepicker" ).datepicker({
      showOtherMonths: true,
      selectOtherMonths: true
    });
    });

    $( function() {
    $( "#datepickerFrom" ).datepicker({
      showOtherMonths: true,
      selectOtherMonths: true
    });
    });

    $( function() {
    $( "#datepickerTo" ).datepicker({
      showOtherMonths: true,
      selectOtherMonths: true
    });
  } );
  
  </script> 
    <style>
         .hidden-field
 {
     display:none;
 }
    </style>
</head>
<body>
 

    <header>
        <div><h2>Kelley School Of Business</h2></div>
    </header>

    <nav class="navbar navbar-default">
        <div class="container-fluid">
            <div class="navbar-header">
                <a class="navbar-brand" href="index.aspx">IUPUI</a>
            </div>
            <div class="collapse navbar-collapse" id="navbar-collapse-1">
                <ul class="nav navbar-nav">
                    <li><a href="#">KSB Home</a></li>
                    <li><a href="#">Admin Login</a></li>
                </ul>
            </div>
        </div>
    </nav>

    <main>
        <form id="form1" runat="server">
            <div style="background-color:#990000" class="container" id="registration-page">
                <div class="container" id="registration-main">
                <div class="page-header">
                    <h1>Appointments</h1>
                </div>
                <h3>Search Appointments (by Keyword)</h3>
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="input-group">
                                <span class="input-group-btn">
                                <asp:Button runat="server" class="btn btn-default" onclick="GetAppoint" Text="Go!"></asp:Button>
                                </span>
                                <asp:TextBox runat="server" ID="keyword_search" type="text" class="form-control" placeholder="Search for..."/>
                            </div>
                        </div>
                    </div>
                    
                    <h3>Search Appointments (by Date)</h3>
                    <asp:Panel runat="server" ID="SingleDate" >
                    <div class="row">
                        <div class="col-lg-6">
                         <div class="input-group">
                         <span class="input-group-btn">
                            <asp:button runat="server" class="btn btn-default" type="button" Text="Go!" OnClick="GetAppointDate"></asp:button>
                         </span>
                         <asp:TextBox runat="server" type="text" id="datepicker" class="form-control" placeholder="Search for..."/>
                        </div>
                        </div>
                        </div>
                    </asp:Panel>

                    <asp:Panel runat ="server" ID ="RangeDate">
                        <div class="row">
                        <div class="col-lg-6">
                         <div class="input-group">
                         <span class="input-group-btn">
                            <asp:button runat="server" class="btn btn-default" type="button" Text="Go!" OnClick="GetAppointDate"></asp:button>
                         </span>
                         <table>
                             <tr>
                                 <td><asp:TextBox runat="server" id="datepickerFrom" class="form-control" style="width:120px;" placeholder="From..."/> &nbsp; &nbsp;</td>
                                 <td><asp:TextBox runat="server" type="text" id="datepickerTo" class="form-control" style="width:120px;" placeholder="To..." /></td>
                             </tr>
                         </table>
                     
                        </div>
                        </div>
                        </div>
                    </asp:Panel>
                    
                    <div class="container-fluid" id="DateRange">
                        <div class="col-lg-6">
                            <div class="input-group">
                                 <br />
                                <span>     
                                    <asp:CheckBox ID="ShowRange" class="checkbox" runat="server" text="Range of Dates" AutoPostBack ="true" OnCheckedChanged ="Show_MultiDate"/>
                                </span>
                            </div>
                        </div>
                    </div>
                    

                     <h3>Appointment Search Result</h3>
                     <asp:Panel runat="server" id="searching">
                         <asp:GridView ID="result" runat="server" style="width:100%;margin-bottom:5px;" BackColor="#ffffff" HorizontalAlign="center" CellPadding="15" CellSpacing="15" GridLines ="none" AllowPaging ="true"  OnPageIndexChanging="Paging" OnRowDeleting="DeleteAppointment" AutoGenerateColumns ="false" PageSize="3"  >
         <PagerStyle CssClass="gridViewPager" HorizontalAlign="center"></PagerStyle>
         <Columns>
         <asp:BoundField DataField="APID"><ItemStyle CssClass="hidden-field" /><HeaderStyle CssClass="hidden-field" /></asp:BoundField>
         <asp:BoundField DataField="StuFName" HeaderText="First" />
         <asp:BoundField DataField="StuLName" HeaderText="Last" />
         <asp:BoundField DataField="StuEmail" HeaderText="Email" />
         <asp:BoundField DataField="StuPhone" HeaderText="Phone" />
         <asp:BoundField DataField="AvaDate"  HeaderText="Date" />
         <asp:BoundField DataField="AvaTime"  HeaderText="Time" />
         <asp:BoundField DataField="AdvFName" HeaderText="Advisor First" />
         <asp:BoundField DataField="AdvLName" HeaderText="Advisor Last" />
         <asp:CommandField ShowDeleteButton="True" ButtonType="Button"  ControlStyle-CssClass="btn btn-default btn-sm"><ItemStyle Width="50" /></asp:CommandField>

        </Columns>
</asp:GridView>
                         <br /><br />
                     </asp:Panel>
                    <asp:Label runat="server" ID="hold"></asp:Label>
                    <asp:Button runat="server" class="btn btn-default"  text="Return" OnClick="GoBack"/>
                   
                </div>
            </div>
        </form>
    </main>
    <footer>
	
		<div class="links-generalinfo">
			<div class="container">
				<small><i>Copyright &copy; 2017 Kelley School of Business. <a href=""></i>All rights reserved</a>. Various trademarks held by their respective owners.
				<br>iupui.edu, inc. SomeAddress St, Suite 000, Indianapolis, IN 00000, United States</small>
				<h5> <a href="">Privacy Statement</a> | <a href="">Privacy Disclosure</a> |<a href=""> Site Map</a></h5>
			</div>
		</div>
	
	</footer>

</body>
</html>