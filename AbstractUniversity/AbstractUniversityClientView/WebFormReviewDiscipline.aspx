<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormReviewDiscipline.aspx.cs" Inherits="AbstractUniversityClientView.WebFormReviewDiscipline" %>

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
			width: 402px;
		}
		.auto-style3 {
			width: 80px;
		}
		.auto-style4 {
			width: 80px;
			height: 23px;
		}
		.auto-style5 {
			height: 23px;
		}
		.auto-style6 {
			height: 23px;
			width: 111px;
		}
		.auto-style7 {
			width: 111px;
		}
		.auto-style8 {
			height: 23px;
			width: 152px;
		}
		.auto-style9 {
			width: 152px;
		}
		.auto-style10 {
			width: 110px;
		}
		.auto-style15 {
			width: 174px;
		}
		.auto-style16 {
			width: 99px;
		}
		.auto-style17 {
			width: 109px;
		}
		.auto-style18 {
			width: 271px;
		}
		.auto-style19 {
			width: 195px;
		}
		.auto-style20 {
			height: 23px;
			width: 274px;
		}
		.auto-style21 {
			width: 274px;
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
					<td>&nbsp;</td>
					<td class="auto-style2" style="font-family: 'Times New Roman', Times, serif; font-size: 30px; font-weight: bold;">Дисциплина</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
			</table>
        </div>
    	<table class="auto-style1">
			<tr>
				<td class="auto-style4">&nbsp;</td>
				<td class="auto-style20"></td>
				<td class="auto-style6">Название:</td>
				<td class="auto-style8">
					<asp:TextBox ID="TextBoxName" runat="server" ReadOnly="True" Width="150px"></asp:TextBox>
				</td>
				<td class="auto-style5"></td>
				<td class="auto-style5"></td>
				<td class="auto-style5"></td>
			</tr>
			<tr>
				<td class="auto-style3">&nbsp;</td>
				<td class="auto-style21">&nbsp;</td>
				<td class="auto-style7">&nbsp;</td>
				<td class="auto-style9">&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
			</tr>
			<tr>
				<td class="auto-style3">&nbsp;</td>
				<td class="auto-style21">&nbsp;</td>
				<td class="auto-style7">Количество:</td>
				<td class="auto-style9">
					<asp:TextBox ID="TextBoxCount" runat="server" Width="150px" ReadOnly="True" AutoPostBack="True"></asp:TextBox>
				</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
			</tr>
			<tr>
				<td class="auto-style3">&nbsp;</td>
				<td class="auto-style21">&nbsp;</td>
				<td class="auto-style7">&nbsp;</td>
				<td class="auto-style9">&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
			</tr>
			<tr>
				<td class="auto-style3">&nbsp;</td>
				<td class="auto-style21">&nbsp;</td>
				<td class="auto-style7">Цена:</td>
				<td class="auto-style9">
					<asp:TextBox ID="TextBoxPrice" runat="server" Width="150px" ReadOnly="True" AutoPostBack="True"></asp:TextBox>
				</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
			</tr>
		</table>
		<table class="auto-style1">
			<tr>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
				<td class="auto-style16">&nbsp;</td>
				<td>&nbsp;</td>
				<td class="auto-style15">
					&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
			</tr>
		</table>
		<table class="auto-style1">
			<tr>
				<td>&nbsp;</td>
				<td class="auto-style17">&nbsp;</td>
				<td class="auto-style19">&nbsp;</td>
				<td>&nbsp;</td>
				<td class="auto-style18">&nbsp;</td>
				<td class="auto-style10">&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td class="auto-style17">&nbsp;</td>
				<td class="auto-style19">&nbsp;</td>
				<td>
					&nbsp;</td>
				<td class="auto-style18">
					<asp:Button ID="ButtonCancel" runat="server" Text="Отмена" Width="110px" OnClick="ButtonCancel_Click" />
				</td>
				<td class="auto-style10">
					&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
			</tr>
		</table>
    </form>
</body>
</html>
