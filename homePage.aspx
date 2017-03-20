<%@ Page Language="C#" AutoEventWireup="false" CodeFile="homePage.aspx.cs" Inherits="KSB_Website_Files_homePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!--- Linking to the bootstrap --->
    <title>Kelly School Of Business Advising</title>
    <meta charset="utf-8" />
    <meta name="Register" content="register, form" />
    <link rel="stylesheet" type="text/css" href="css/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="css/main.css"/>
</head>
<body>
    <header>
        <div><h2>Kelley School of Business</h2></div>
    </header>


<main>
        <form id="form1" runat="server">
            <div style="background-color:#990000" class="container" id="registration-page">
                <div class="container" id="registration-main">
                    <div class="page-header">
                        <h1 style="text-align:center">Choose an Option</h1>
                    </div>
                <div style ="text-align:center">
                                <asp:button runat ="server" borderwidth="5px" bordercolor="#990000" backgroundcolor="white" width="200px" height="125px" Text ="Advisor Login" OnClick ="AdvisorLogin"></asp:button>
                    <br/><br />


								<asp:button runat ="server" borderwidth="5px" bordercolor="#990000" backgroundcolor="white" width="200px" height="125px" Text ="Student Login" OnClick="loginButton_Click"></asp:button>
                    <br /><br />

								<p><asp:button runat ="server" borderwidth="5px" bordercolor="#990000" width="200px" height="125px" Text ="Guest Login" OnClick="GuestLogin_Click" ></asp:button></p>
                    </div>
                    <br />
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
