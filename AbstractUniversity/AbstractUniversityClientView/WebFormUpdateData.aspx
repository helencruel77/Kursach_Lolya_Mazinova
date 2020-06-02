<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormUpdateData.aspx.cs" Inherits="AbstractUniversityClientView.WebFormUpdateData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
	<style type="text/css">
		.auto-style1 {
			width: 763px;
		}
		.auto-style2 {
			width: 80px;
		}
		.auto-style7 {
			width: 48px;
		}
		.auto-style8 {
			width: 76px;
		}
		.auto-style9 {
			width: 80px;
			height: 29px;
		}
		.auto-style11 {
			width: 48px;
			height: 29px;
			font-family: "Times New Roman", Times, serif;
			font-weight: bold;
			font-size: 30px;
		}
		.auto-style12 {
			width: 76px;
			height: 29px;
		}
	</style>
</head>
<body>
     <form id="form1" runat="server">
        <table cellspacing="5" class="auto-style1">
			<tr>
				<td class="auto-style9"></td>
				<td class="auto-style9"></td>
				<td class="auto-style12"></td>
				<td class="auto-style11" style="font-family: 'Times New Roman', Times, serif; font-size: 30px; font-weight: bold;">Изменение данных</td>
				<td class="auto-style12"></td>
				<td class="auto-style12"></td>
				<td class="auto-style12"></td>
			</tr>
			<tr>
				<td class="auto-style2">&nbsp;</td>
				<td class="auto-style2">&nbsp;</td>
				<td class="auto-style8">&nbsp;</td>
				<td class="auto-style7">&nbsp;</td>
				<td class="auto-style8">&nbsp;</td>
				<td class="auto-style8">&nbsp;</td>
				<td class="auto-style8">&nbsp;</td>
			</tr>
			<tr>
				<td class="auto-style2">&nbsp;</td>
				<td class="auto-style2">&nbsp;</td>
				<td class="auto-style8">
					<asp:Label ID="LabelLastname" runat="server" Text="Фамилия:"></asp:Label>
				</td>
				<td class="auto-style7">
					<asp:TextBox ID="TextBoxLastName" runat="server" Width="195px"></asp:TextBox>
				</td>
				<td class="auto-style8">&nbsp;</td>
				<td class="auto-style8">&nbsp;</td>
				<td class="auto-style8">&nbsp;</td>
			</tr>
			<tr>
				<td class="auto-style2"></td>
				<td class="auto-style2"></td>
				<td class="auto-style8">
					<asp:Label ID="LabelName" runat="server" Text="Имя:"></asp:Label>
				</td>
				<td class="auto-style7">
					<asp:TextBox ID="TextBoxName" runat="server" Width="195px"></asp:TextBox>
				</td>
				<td class="auto-style8"></td>
				<td class="auto-style8"></td>
				<td class="auto-style8"></td>
			</tr>
			<tr>
				<td class="auto-style2">&nbsp;</td>
				<td class="auto-style2">&nbsp;</td>
				<td class="auto-style8">Почта:</td>
				<td class="auto-style7">
					<asp:TextBox ID="TextBoxEmail" runat="server" Width="195px"></asp:TextBox>
				</td>
				<td class="auto-style8">&nbsp;</td>
				<td class="auto-style8">&nbsp;</td>
				<td class="auto-style8">&nbsp;</td>
			</tr>
			<tr>
				<td class="auto-style2">&nbsp;</td>
				<td class="auto-style2">&nbsp;</td>
				<td class="auto-style8">Пароль:</td>
				<td class="auto-style7">
					<asp:TextBox ID="TextBoxPassword" runat="server" Width="195px"></asp:TextBox>
				</td>
				<td class="auto-style8">&nbsp;</td>
				<td class="auto-style8">&nbsp;</td>
				<td class="auto-style8">&nbsp;</td>
			</tr>
			<tr>
				<td class="auto-style2">&nbsp;</td>
				<td class="auto-style2">&nbsp;</td>
				<td class="auto-style8">
						<asp:Button ID="ButtonUpdate" runat="server" OnClick="ButtonUpdate_Click" Text="Изменить" Width="116px" />
					</td>
				<td class="auto-style7">
						<asp:Button ID="ButtonBack" runat="server" Text="Назад" Width="116px" OnClick="ButtonEnter_Click" Height="25px" style="margin-left: 88px" />
					</td>
				<td class="auto-style8">&nbsp;</td>
				<td class="auto-style8">&nbsp;</td>
				<td class="auto-style8">&nbsp;</td>
			</tr>
			<tr>
				<td class="auto-style2">&nbsp;</td>
				<td class="auto-style2">&nbsp;</td>
				<td class="auto-style8">&nbsp;</td>
				<td class="auto-style7">
					&nbsp;</td>
				<td class="auto-style8">&nbsp;</td>
				<td class="auto-style8">&nbsp;</td>
				<td class="auto-style8">&nbsp;</td>
			</tr>
		</table>
    </form>
</body>
</html>
