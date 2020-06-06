<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormCreateCourse.aspx.cs" Inherits="AbstractUniversityClientView.WebFormCreateCourse" %>

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
		.auto-style12 {
			width: 19px;
		}
		.auto-style13 {
			width: 10px;
		}
		.auto-style14 {
			width: 33px;
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
					<td class="auto-style2" style="font-family: 'Times New Roman', Times, serif; font-size: 30px; font-weight: bold;">Создание курса</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
			</table>
        </div>
    	<table class="auto-style1">
			<tr>
				<td class="auto-style4">&nbsp;</td>
				<td class="auto-style5"></td>
				<td class="auto-style6">Название:</td>
				<td class="auto-style8">
					<asp:TextBox ID="TextBoxName" runat="server" Width="150px"></asp:TextBox>
				</td>
				<td class="auto-style5"></td>
				<td class="auto-style5"></td>
				<td class="auto-style5"></td>
			</tr>
			<tr>
				<td class="auto-style3">&nbsp;</td>
				<td>&nbsp;</td>
				<td class="auto-style7">&nbsp;</td>
				<td class="auto-style9">&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
			</tr>
			<tr>
				<td class="auto-style3">&nbsp;</td>
				<td>&nbsp;</td>
				<td class="auto-style7">Цена:</td>
				<td class="auto-style9">
					<asp:TextBox ID="TextBoxPrice" runat="server" Width="150px" ReadOnly="True" AutoPostBack="True"></asp:TextBox>
				</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
			</tr>
			<tr>
				<td class="auto-style3">&nbsp;</td>
				<td>&nbsp;</td>
				<td class="auto-style7">&nbsp;</td>
				<td class="auto-style9">&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
			</tr>
		</table>
		<table class="auto-style1">
			<tr>
				<td>&nbsp;</td>
				<td class="auto-style12">&nbsp;</td>
				<td class="auto-style14">&nbsp;</td>
				<td class="auto-style10">
					<asp:Button ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" Text="Добавить" Width="110px" />
				</td>
				<td class="auto-style13">&nbsp;</td>
				<td class="auto-style10">
					<asp:Button ID="ButtonChange" runat="server" Text="Изменить" Width="110px" OnClick="ButtonChange_Click" />
				</td>
				<td class="auto-style13">&nbsp;</td>
				<td class="auto-style10">
					<asp:Button ID="ButtonDelete" runat="server" Text="Удалить" Width="110px" OnClick="ButtonDelete_Click" />
				</td>
				<td class="auto-style13">&nbsp;</td>
				<td class="auto-style10">
					<asp:Button ID="ButtonUpdate" runat="server" Text="Обновить" Width="110px" OnClick="ButtonUpd_Click" />
				</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td class="auto-style12">&nbsp;</td>
				<td class="auto-style14">&nbsp;</td>
				<td class="auto-style10">&nbsp;</td>
				<td class="auto-style13">&nbsp;</td>
				<td class="auto-style10">&nbsp;</td>
				<td class="auto-style13">&nbsp;</td>
				<td class="auto-style10">&nbsp;</td>
				<td class="auto-style13">&nbsp;</td>
				<td class="auto-style10">&nbsp;</td>
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
					<asp:GridView ID="dataGridView" runat="server" ShowHeaderWhenEmpty="True" OnRowDataBound="dataGridView_RowDataBound" OnSelectedIndexChanged="dataGridView_SelectedIndexChanged">
						<Columns>
							 <asp:CommandField ShowSelectButton="true" SelectText=">>" />
						</Columns>
						<SelectedRowStyle BackColor="#CCCCCC" />
					</asp:GridView>
				</td>
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
				<td>&nbsp;</td>
				<td class="auto-style10">&nbsp;</td>
				<td>&nbsp;</td>
				<td class="auto-style10">&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td class="auto-style17">&nbsp;</td>
				<td>&nbsp;</td>
				<td class="auto-style10">
					<asp:Button ID="ButtonSave" runat="server" Text="Сохранить" Width="110px" OnClick="ButtonSave_Click" />
				</td>
				<td>&nbsp;</td>
				<td class="auto-style10">
					<asp:Button ID="ButtonCancel" runat="server" Text="Отмена" Width="110px" OnClick="ButtonCancel_Click" />
				</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
			</tr>
		</table>
    </form>
</body>
</html>
