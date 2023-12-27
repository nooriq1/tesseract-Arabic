<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfirmIdentity.aspx.cs" Inherits="myproject.ConfirmIdentity" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
	<link rel="preconnect" href="https://fonts.gstatic.com">
<link href="https://fonts.googleapis.com/css2?family=Caro&display=swap" rel="stylesheet">


</head>
<body>

	
<div class="container">
	<div class="screen">
		<div class="screen__content">
			<form class="login" id="form1" runat="server">
				<div class="login__field">
					<asp:FileUpload ID="FileUpload1" runat="server" />
				</div>
				<div class="login__field">
					<i class="login__icon fas fa-user"></i>
					<asp:TextBox ID="TextBox1" runat="server" CssClass="login__input" placeholder="name : "></asp:TextBox>
				</div>
				<asp:Button ID="Button1" runat="server" Text="check" CssClass="button login__submit" OnClick="Button1_Click" />
			</form>
			<div class="social-login">
				<h3>
					<asp:Label ID="Label1" runat="server" Text=""></asp:Label></h3>

			</div>
		</div>
		
	</div>	
	
</div>


</body>
</html>
