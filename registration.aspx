<%@ Page Language="C#" AutoEventWireup="true" CodeFile="registration.aspx.cs" Inherits="_Registration" %>

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
    <!-- div 1 begin -->
    <div><h2>Kelley School Of Business</h2></div>
    <!-- div 1 end -->
    <nav class="navbar navbar-default">
     <!-- div 2 begin -->
        <div class="container-fluid">
            <!-- div 3 begin -->
            <div class="navbar-header">
                <a class="navbar-brand" href="index.aspx">IUPUI</a>
            </div>
            <!-- div 3 end -->
            <!-- div 4 begin -->
            <div class="collapse navbar-collapse" id="navbar-collapse-1">
                <ul class="nav navbar-nav">
                    <li><a href="#">KSB Home</a></li>
                    <li><a href="#">Admin Login</a></li>
                </ul>
            </div>
            <!-- div 4 end -->
        </div>
        <!-- div 2 end -->
    </nav>

    <main>
        <!-- form begin -->
        <form id="form1" runat="server" class="form-horizontal"> 
            <!-- div 1 begin -->
            <div style="background-color:#990000" class="container" id="registration-page">
                <!-- div 2 begin -->
                <div class="container" id="registration-main">
                    <!-- div 3 begin -->
                    <div class="page-header">
                        <h1>Fill the information below to request an appointment:</h1>
                    </div>
                    <!-- div 3 end -->
                    <!-- div 4 begin -->
                    <div>
                        <asp:ValidationSummary runat="server" ID="summary" Style="color: Red" DisplayMode="BulletList" HeaderText="<b>Please review the following errors:</b>" />
                    </div>
                    <!-- div 4 end -->
                    <!-- div 5 begin -->
                    <div id="registration-forms" class="container-small">
                       
                       <asp:Panel runat="server" ID="StudentInformation">
                            <h3>Student Information</h3>
                             <!-- div 6 begin -->
                            <div id="name-address">
                            <div class="form-group">
                                <asp:Label Text="First Name" runat="server" />
                                <asp:TextBox ID="FirstName_Form" runat="server" class="form-control" Value="Test"/>
                                <asp:RequiredFieldValidator ID="ValidateName" Display="dynamic" Style="color: Red" ErrorMessage="*First Name is Required" SetFocusOnError="true" ControlToValidate="FirstName_Form" runat="server" Text="*" />
                           
                                <asp:Label Text="Last Name" runat="server" />
                                <asp:TextBox ID="LastName_Form" runat="server" class="form-control" Value="Test"/>
                                <asp:RequiredFieldValidator ID="ValidateName2" ErrorMessage="*Last Name is Required" Style="color: Red" Display="dynamic" SetFocusOnError="true" ControlToValidate="LastName_Form" runat="server" Text="*"/>
                          
                                <asp:Label Text="Username" runat="server" />
                                <asp:TextBox ID="UserName_Form" runat="server" class="form-control" Value="Test"/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="*Username is Required" Style="color: Red" Display="dynamic" SetFocusOnError="true" ControlToValidate="LastName_Form" runat="server" Text="*"/>
                          
                                <asp:Label Text="Major" runat="server" />
                                <asp:DropDownList ID="Major_Form" runat="server" class="form-control">  </asp:DropDownList>
                          
                                <asp:Label Text="Email" runat="server" />
                                <asp:TextBox ID="Email_Form" runat="server" class="form-control"  Value="Test@test.com"/>
                                <asp:RequiredFieldValidator  ErrorMessage="*Email is Required" Display="Dynamic" ControlToValidate="Email_Form" runat="server" Style="color: Red" Text="*" />
                                <asp:RegularExpressionValidator ErrorMessage="Email is not in the correct format" ControlToValidate="Email_Form" ValidationExpression=".*@.{2,}\..{2,}" runat="server" Style="color: Red" Text="*"/>
                               
                                <asp:Label Text="Phone" runat="server" />
                                <asp:TextBox ID="Phone_Form" runat="server" class="form-control" Value="Test"/>
                                <asp:RequiredFieldValidator  ErrorMessage="Phone is Required" ControlToValidate="Phone_Form" runat="server" Style="color: Red" Text="*"/>
                            
                                <asp:Label Text="Student ID" runat="server" />
                                <asp:TextBox ID="SUID_Form" runat="server" class="form-control" Value="Test"/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="*Password is Required" Style="color: Red" Display="dynamic" SetFocusOnError="true" ControlToValidate="LastName_Form" runat="server" Text="*"/>
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
                                <asp:DropDownList ID="Advisor_Form" runat="server" class="form-control" AutoPostBack ="true" OnSelectedIndexChanged="drpChange_Time">
                                
                                </asp:DropDownList>
                                </td>
                                </tr>
                                <tr>
                                <td>
                                <asp:Label Text="Appointment Time" runat="server" />
                                </td>
                                <td>
                                <asp:DropDownList ID="TimeSlots_Form" runat="server" class="form-control"  >
                                    
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator  ErrorMessage="*Time Slot is Required" Display="Dynamic" ControlToValidate="TimeSlots_Form" runat="server" Style="color: Red" Text="*" />
                                </td>
                                </tr>
               
                           </table>

                                 <div style="text-align:right;" id="register-button"> 
                                   <asp:Button ID="btnSubmit" Text="Submit" runat="server" OnClick="btnSubmit_Click" />
                                   <asp:Label ID="lblInfo" runat="server"></asp:Label>
                                 </div>
                                
                            </asp:Panel>
                            <br />
                        </div>
                    </div>

                   </div>
                   
                </div>
        </form>
    </main>
    <div class="links-generalinfo">
			<div class="container">
				<small><i>Copyright &copy; 2017 Kelley School of Business. </i><a href="#">All rights reserved</a>. Various trademarks held by their respective owners.
				<br/>iupui.edu, inc. SomeAddress St, Suite 000, Indianapolis, IN 00000, United States</small>
				<h5> <a href="www.registration.aspx">Privacy Statement</a> | <a href="#">Privacy Disclosure</a> |<a href="#"> Site Map</a></h5>
			</div>
		</div>
</body>
</html>
