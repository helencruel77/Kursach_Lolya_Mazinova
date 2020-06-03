﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormMain.aspx.cs" Inherits="AbstractUniversityClientView.WebFormMain" %>

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
			width: 80px;
		}
		.auto-style3 {
			width: 202px;
		}
		.auto-style4 {
			width: 183px;
		}
		.auto-style5 {
			width: 150px;
		}
	</style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        	<table class="auto-style1">
				<tr>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td class="auto-style2">&nbsp;</td>
					<td>&nbsp;</td>
					<td class="auto-style3" style="font-family: 'Times New Roman', Times, serif; font-size: 30px; font-weight: bold;">Главное меню</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
				</table>
        	<table class="auto-style1">
				<tr>
					<td>&nbsp;</td>
					<td class="auto-style5">
						<asp:Button ID="ButtonUpdateData" runat="server" OnClick="ButtonChangeData_Click" Text="Изменить данные" Width="150px" />
					</td>
					<td class="auto-style5">
						<asp:Button ID="ButtonCreateCourse" runat="server" OnClick="ButtonCreateCourse_Click" Text="Создать курс" Width="150px" />
					</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
			</table>
        </div>
    	<table class="auto-style1">
			<tr>
				<td class="auto-style4">&nbsp;</td>
				<td>
					<asp:GridView ID="dataGridView" runat="server">
					</asp:GridView>
				</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
			</tr>
			<tr>
				<td class="auto-style4">&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
			</tr>
			<tr>
				<td class="auto-style4">&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
			</tr>
			<tr>
				<td class="auto-style4">&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
			</tr>
		</table>
    </form>
</body>
</html>
