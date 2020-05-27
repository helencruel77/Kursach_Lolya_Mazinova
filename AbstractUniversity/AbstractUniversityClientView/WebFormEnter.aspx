<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormEnter.aspx.cs" Inherits="AbstractUniversityClientView.WebFormEnter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
	<style type="text/css">
		.auto-style1 {
			width: 100%;
		}
		.auto-style2 {
			width: 132px;
		}
		.auto-style7 {
			width: 175px;
			font-size: xx-large;
		}
		.auto-style5 {
			width: 175px;
		}
		.auto-style3 {
			height: 26px;
		}
		.auto-style4 {
			width: 132px;
			height: 26px;
		}
		.auto-style6 {
			height: 26px;
			width: 175px;
		}
		.auto-style8 {
			width: 80px;
		}
		.auto-style9 {
			width: 80px;
			height: 26px;
		}
		.auto-style10 {
			margin-left: 13px;
		}
		.auto-style11 {
			height: 28px;
		}
		.auto-style12 {
			width: 80px;
			height: 28px;
		}
		.auto-style13 {
			width: 132px;
			height: 28px;
		}
		.auto-style14 {
			width: 175px;
			height: 28px;
		}
		.auto-style15 {
			height: 25px;
		}
		.auto-style16 {
			width: 80px;
			height: 25px;
		}
		.auto-style17 {
			width: 132px;
			height: 25px;
		}
		.auto-style18 {
			width: 175px;
			height: 25px;
		}
	</style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        	<table cellspacing="5" class="auto-style1">
				<tr>
					<td>&nbsp;</td>
					<td class="auto-style8">&nbsp;</td>
					<td class="auto-style2">&nbsp;</td>
					<td class="auto-style7">Вход</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td class="auto-style8">&nbsp;</td>
					<td class="auto-style2">&nbsp;</td>
					<td class="auto-style5">&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td class="auto-style11"></td>
					<td class="auto-style12"></td>
					<td class="auto-style13">Логин:</td>
					<td class="auto-style14">
						<asp:TextBox ID="TextBoxLogin" runat="server" Width="195px" OnTextChanged="TextBoxLogin_TextChanged"></asp:TextBox>
					</td>
					<td class="auto-style11"></td>
					<td class="auto-style11"></td>
					<td class="auto-style11"></td>
				</tr>
				<tr>
					<td class="auto-style3"></td>
					<td class="auto-style9"></td>
					<td class="auto-style4">Пароль:</td>
					<td class="auto-style6">
						<asp:TextBox ID="TextBoxPassword" runat="server" Width="195px"></asp:TextBox>
					</td>
					<td class="auto-style3"></td>
					<td class="auto-style3"></td>
					<td class="auto-style3"></td>
				</tr>
				<tr>
					<td class="auto-style15"></td>
					<td class="auto-style16"></td>
					<td class="auto-style17"></td>
					<td class="auto-style18"></td>
					<td class="auto-style15"></td>
					<td class="auto-style15"></td>
					<td class="auto-style15"></td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td class="auto-style8">&nbsp;</td>
					<td class="auto-style2">
						<asp:Button ID="ButtonRegister" runat="server" OnClick="ButtonRegister_Click" Text="Регистрация" Width="116px" />
					</td>
					<td class="auto-style5">
						<asp:Button ID="ButtonEnter" runat="server" CssClass="auto-style10" Text="Вход" Width="116px" OnClick="ButtonEnter_Click" />
					</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td class="auto-style8">&nbsp;</td>
					<td class="auto-style2">&nbsp;</td>
					<td class="auto-style5">&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
			</table>
        </div>
    </form>
</body>
</html>
