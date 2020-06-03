<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormCourseDiscipline.aspx.cs" Inherits="AbstractUniversityClientView.WebFormCourseDiscipline" %>

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
			width: 116px;
		}
		.auto-style3 {
			width: 283px;
		}
		.auto-style4 {
			width: 87px;
		}
	</style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        	<table class="auto-style1">
				<tr>
					<td class="auto-style2">&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td class="auto-style2">Дисциплина:</td>
					<td class="auto-style3">
						<asp:DropDownList ID="DropDownList" runat="server" Width="285px">
						</asp:DropDownList>
					</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td class="auto-style2">&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td class="auto-style2">&nbsp;</td>
					<td class="auto-style3">&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td class="auto-style2">&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td class="auto-style2">Количество:</td>
					<td class="auto-style3">
						<asp:TextBox ID="TextBoxCount" runat="server" Width="275px"></asp:TextBox>
					</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td class="auto-style2">&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td class="auto-style2">&nbsp;</td>
					<td class="auto-style3">&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td class="auto-style2">&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td class="auto-style2">Сумма:</td>
					<td class="auto-style3">
						<asp:TextBox ID="TextBoxSum" runat="server" Width="275px"></asp:TextBox>
					</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td class="auto-style2">&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td class="auto-style2">&nbsp;</td>
					<td class="auto-style3">&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
			</table>
        </div>
    	<table class="auto-style1">
			<tr>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
				<td class="auto-style4">
					<asp:Button ID="ButtonSave" runat="server" OnClick="ButtonSave_Click" Text="Сохранить" Width="90px" />
				</td>
				<td>&nbsp;</td>
				<td class="auto-style4">
					<asp:Button ID="ButtonCancel" runat="server" OnClick="ButtonSave_Click" Text="Отмена" Width="90px" />
				</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
			</tr>
		</table>
    </form>
</body>
</html>
