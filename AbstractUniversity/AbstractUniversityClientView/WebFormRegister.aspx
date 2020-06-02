<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormRegister.aspx.cs" Inherits="AbstractUniversityClientView.WebFormRegister" %>

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
			width: 77px;
		}
		.auto-style3 {
			height: 26px;
		}
		.auto-style4 {
			width: 77px;
			height: 26px;
		}
		.auto-style5 {
			width: 153px;
		}
		.auto-style6 {
			height: 26px;
			width: 153px;
		}
		.auto-style7 {
			width: 153px;
			font-size: xx-large;
		}
		.auto-style8 {
			width: 80px;
		}
		.auto-style9 {
			height: 26px;
			width: 80px;
		}
	</style>
</head>
<body>
    <form id="form1" runat="server">
        <table cellspacing="5" class="auto-style1">
			<tr>
				<td>&nbsp;</td>
				<td class="auto-style8">&nbsp;</td>
				<td class="auto-style2">&nbsp;</td>
				<td class="auto-style7">Регистрация</td>
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
				<td>&nbsp;</td>
				<td class="auto-style8">&nbsp;</td>
				<td class="auto-style2">
					<asp:Label ID="LabelLastname" runat="server" Text="Фамилия:"></asp:Label>
				</td>
				<td class="auto-style5">
					<asp:TextBox ID="TextBoxLastName" runat="server" Width="195px"></asp:TextBox>
				</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
			</tr>
			<tr>
				<td class="auto-style3"></td>
				<td class="auto-style9"></td>
				<td class="auto-style2">
					<asp:Label ID="LabelName" runat="server" Text="Имя:"></asp:Label>
				</td>
				<td class="auto-style5">
					<asp:TextBox ID="TextBoxName" runat="server" Width="195px"></asp:TextBox>
				</td>
				<td class="auto-style3"></td>
				<td class="auto-style3"></td>
				<td class="auto-style3"></td>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td class="auto-style8">&nbsp;</td>
				<td class="auto-style2">Почта:</td>
				<td class="auto-style6">
					<asp:TextBox ID="TextBoxEmail" runat="server" Width="195px"></asp:TextBox>
				</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td class="auto-style8">&nbsp;</td>
				<td class="auto-style4">Пароль:</td>
				<td class="auto-style5">
					<asp:TextBox ID="TextBoxPassword" runat="server" Width="195px"></asp:TextBox>
				</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td class="auto-style8">&nbsp;</td>
				<td class="auto-style2">&nbsp;</td>
				<td class="auto-style5">
					&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td class="auto-style8">&nbsp;</td>
				<td class="auto-style2">&nbsp;</td>
				<td class="auto-style5">
					<asp:Button ID="ButtonRegister" runat="server" Text="Регистрация" Width="148px" OnClick="ButtonRegister_Click" />
				</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
			</tr>
		</table>
    </form>
</body>
</html>