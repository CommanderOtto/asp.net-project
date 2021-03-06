﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="registration.aspx.cs" Inherits="_Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>KSB - UserRegistration</title>
    <meta charset="utf-8"/>
    <meta name="Register" content="register, form" />
    <link rel="stylesheet" type="text/css" href="css/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="css/main.css"/>
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
        <form id="form1" runat="server" class="form-horizontal"> 
            <div style="background-color:#990000" class="container" id="registration-page">
                <div class="container" id="registration-main">
                    <div class="page-header">
                        <h1>Fill the information below to request an appointment:</h1>
                    </div>
                    <div>
                        <asp:ValidationSummary runat="server" ID="summary" Style="color: Red" DisplayMode="BulletList" HeaderText="<b>Please review the following errors:</b>" />
                    </div>

                    <div id="registration-forms" class="container-small">
                        <div id="name-address">
                            <asp:Panel runat="server" ID="StudentInformation">
                            <h3>Student Information</h3>
                            <div class="form-group">
                                <asp:Label Text="First Name" runat="server" />
                                <asp:TextBox ID="FirstName_Form" runat="server" class="form-control" />
                                <asp:RequiredFieldValidator ID="ValidateName" Display="dynamic" Style="color: Red" ErrorMessage="*First Name is Required" SetFocusOnError="true" ControlToValidate="FirstName_Form" runat="server" Text="*" />
                            </div>

                            <div class="form-group">
                                <asp:Label Text="Last Name" runat="server" />
                                <asp:TextBox ID="LastName_Form" runat="server" class="form-control"/>
                                <asp:RequiredFieldValidator ID="ValidateName2" ErrorMessage="*Last Name is Required" Style="color: Red" Display="dynamic" SetFocusOnError="true" ControlToValidate="LastName_Form" runat="server" Text="*"/>
                            </div>
                            

                            <div class="form-group">
                                <asp:Label Text="Major" runat="server" />
                                <asp:DropDownList ID="Major_Form" runat="server" class="form-control">
                                    <asp:ListItem Value="MU" Text="Major Undecided" />
                                    <asp:ListItem Value="AC" Text="Accounting" />
                                    <asp:ListItem Value="MA" Text="Management" />
                                    <asp:ListItem Value="FI" Text="Finance" />
                                    <asp:ListItem Value="LO" Text="Logistics" />
                                </asp:DropDownList>
                            </div>
                            
                            <div id="email">
                                <div class="form-group">
                                    <asp:Label Text="Email" runat="server" />
                                    <asp:TextBox ID="Email_Form" runat="server" class="form-control" />
                                    <asp:RequiredFieldValidator  ErrorMessage="*Email is Required" Display="Dynamic" ControlToValidate="Email_Form" runat="server" Style="color: Red" Text="*" />
                                    <asp:RegularExpressionValidator ErrorMessage="Email is not in the correct format" ControlToValidate="Email_Form" ValidationExpression=".*@.{2,}\..{2,}" runat="server" Style="color: Red" Text="*"/>
                                </div>
                                <div class="form-group">
                                    <asp:Label Text="Phone" runat="server" />
                                    <asp:TextBox ID="Phone_Form" runat="server" class="form-control" />
                                    <asp:RequiredFieldValidator  ErrorMessage="Phone is Required" ControlToValidate="Phone_Form" runat="server" Style="color: Red" Text="*"/>
                                </div>
                            </div>

                            <div id="NextButton" style="text-align:right;">
                                <asp:Button runat="server" ID="btnNext" Text="Next" Onclick="btnNext_Click"/>
                            </div>
                            </asp:Panel>

                           
                            <asp:Panel runat="server" ID="ContactInformation">
                                  
                            <h3>Appointment Reasons</h3>
                            <div class="form-group">
                               <div class="container-small">
                               <asp:CheckBoxList ID="Reason_Form" runat="server" class="checkbox">
                                    <asp:ListItem Value="1" Text="Change Major" />
                                    <asp:ListItem Value="2" Text="Withdraw from Course" />
                                    <asp:ListItem Value="3" Text="Degree Planning" />
                                    <asp:ListItem Value="3" Text="Transfer Credits" />
                                </asp:CheckBoxList>
                                </div>
                            </div>
                            <br /><br />
                            <h3>Appointment Information</h3>
                            <table class="table" style="border-top:none;border-bottom:none;">
                                <tr>
                                <td>
                                <asp:Label Text="Advisor" runat="server" />
                                </td>
                                <td>
                                <asp:DropDownList ID="Advisor_Form" runat="server" class="form-control">
                                    <asp:ListItem Value="1" Text="AdvisorName1" />
                                    <asp:ListItem Value="2" Text="AdvisorName2" />
                                    <asp:ListItem Value="3" Text="AdvisorName3" />
                                    <asp:ListItem Value="4" Text="AdvisorName4" />
                                </asp:DropDownList>
                                </td>
                                </tr>
                                <tr>
                                <td>
                                <asp:Label Text="Appointment Time" runat="server" />
                                </td>
                                <td>
                                <asp:DropDownList ID="TimeSlots_Form" runat="server" class="form-control">
                                    <asp:ListItem Value="MU" Text="10:30-11:00" />
                                    <asp:ListItem Value="AC" Text="11:00-12:30" />
                                    <asp:ListItem Value="MA" Text="12:30-1:00" />
                                    <asp:ListItem Value="FI" Text="1:00-1:30" />
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator  ErrorMessage="*Time Slot is Required" Display="Dynamic" ControlToValidate="TimeSlots_Form" runat="server" Style="color: Red" Text="*" />
                                </td>
                                </tr>
               
                           </table>

                                 <div style="text-align:right;" id="register-button"> 
                                   <asp:Button ID="btnSubmit" Text="Submit" runat="server" OnClick="btnSubmit_Click" />
                                 </div>
                                
                            </asp:Panel>
                            <br />
                        </div>
                    </div>

                   
                   
                </div>
        </form>
    </main>
    <div class="links-generalinfo">
			<div class="container">
				<small><i>Copyright &copy; 2017 Kelley School of Business. <a href=""></i>All rights reserved</a>. Various trademarks held by their respective owners.
				<br>iupui.edu, inc. SomeAddress St, Suite 000, Indianapolis, IN 00000, United States</small>
				<h5> <a href="">Privacy Statement</a> | <a href="">Privacy Disclosure</a> |<a href=""> Site Map</a></h5>
			</div>
		</div>
</body>
</html>
