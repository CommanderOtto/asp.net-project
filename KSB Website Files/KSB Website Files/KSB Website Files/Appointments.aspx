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
                                <button class="btn btn-default" type="button">Go!</button>
                                </span>
                                <input type="text" class="form-control" placeholder="Search for..."/>
                            </div>
                        </div>
                    </div>
                    
                    <h3>Search Appointments (by Date)</h3>
                    <asp:Panel runat="server" ID="SingleDate" >
                    <div class="row">
                        <div class="col-lg-6">
                         <div class="input-group">
                         <span class="input-group-btn">
                            <asp:button runat="server" class="btn btn-default" type="button" Text="Go!"></asp:button>
                         </span>
                         <input type="text" id="datepicker" class="form-control" placeholder="Search for..."/>
                        </div>
                        </div>
                        </div>
                    </asp:Panel>

                    <asp:Panel runat ="server" ID ="RangeDate">
                        <div class="row">
                        <div class="col-lg-6">
                         <div class="input-group">
                         <span class="input-group-btn">
                            <asp:button runat="server" class="btn btn-default" type="button" Text="Go!"></asp:button>
                         </span>
                         <table>
                             <tr>
                                 <td><input type="text" id="datepickerFrom" class="form-control" style="width:120px;" placeholder="From..."/> &nbsp; &nbsp;</td>
                                 <td><input type="text" id="datepickerTo" class="form-control" style="width:120px;" placeholder="To..." /></td>
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
                    <table class="manage-table responsive-table">
			            <tr>
				            <th><i class="fa fa-file-text"></i> Time Slot</th>
				            <th><i class="fa fa-calendar"></i>Student Name</th>
				            <th><i class="fa fa-calendar"></i>Advisor Name</th>
			            </tr>
                        <tr>
				            <td><a href="#">11:00-12:30</a></td>
				            <td>Jose D.</td>
				            <td>CoolAdvisor</td>
				            <td class="action">
					            <a href="#"><i class="fa fa-pencil"></i> Edit</a>
					            <a href="#"><i class="fa  fa-check "></i> Mark Filled</a>
					            <a href="#" class="delete"><i class="fa fa-remove"></i> Delete</a>
				            </td>
			            </tr>
                        <tr>
				            <td><a href="#">11:00-12:30</a></td>
				            <td>Josh B.</td>
				            <td>CoolAdvisor</td>
				            <td class="action">
					            <a href="#"><i class="fa fa-pencil"></i> Edit</a>
					            <a href="#"><i class="fa  fa-check "></i> Mark Filled</a>
					            <a href="#" class="delete"><i class="fa fa-remove"></i> Delete</a>
				            </td>
			            </tr>
                        <tr>
				            <td><a href="#">11:00-12:30</a></td>
				            <td>Jonathan</td>
				            <td>CoolAdvisor</td>
				            <td class="action">
					            <a href="#"><i class="fa fa-pencil"></i> Edit</a>
					            <a href="#"><i class="fa  fa-check "></i> Mark Filled</a>
					            <a href="#" class="delete"><i class="fa fa-remove"></i> Delete</a>
				            </td>
			            </tr>
		            </table>
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