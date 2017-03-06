<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdvisorPortal.aspx.cs" Inherits="AdvisorPortal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>KSB - Advisor Portal</title>
    <meta charset="utf-8" />
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
        <form id="form1" runat="server">
            <div style="background-color:#990000" class="container" id="registration-page">
                <div class="container" id="registration-main">
                    <div class="page-header">
                        <h1>Advisor Portal</h1>
                    </div>
                   <div class="col-sm-6 col-md-4">
						<div class="thumbnail1">
							<div class="caption">
								<h3>Appointments</h3>
								<p>View, Edit or Cancel current appointments.</p>
                                <br /><br/>
								<p>
                                <asp:Button runat="server" ID="appointmentLink" CssClass="btn btn-default" Text="Go" OnClick="ToAppointments"/>
								</p>
							</div>
						</div>
					</div>

                    <div class="col-sm-6 col-md-4">
						<div class="thumbnail1">
							<div class="caption">
								<h3>Advising Reports</h3>
								<p>Download Advising Data for Analysis.</p>
                                <br /><br />
								<p><a href="#" class="btn btn-default" role="button">Go</a></p>
							</div>
						</div>
					</div>


                    <div class="col-sm-6 col-md-4">
						<div class="thumbnail1">
							<div class="caption">
								<h3>Advising Portal</h3>
								<p>Edit the information students view on the advising portal.</p>
                                <br />
								<p><a href="#" class="btn btn-default" role="button">Go</a></p>
							</div>
						</div>
					</div>
                    <br />
                    
                   <div class="container-fluid" id="register-button">
                        <br />
                        <asp:Button ID="btnSubmit" class="btn btn-default" Text="Logout" runat="server" OnClick="btnSubmit_Click" />
                   </div>

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