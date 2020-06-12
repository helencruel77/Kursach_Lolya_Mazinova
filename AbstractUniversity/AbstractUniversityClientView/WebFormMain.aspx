<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormMain.aspx.cs" Inherits="AbstractUniversityClientView.WebFormMain" %>

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
		.auto-style5 {
			width: 150px;
		}
		.auto-style6 {
			width: 322px;
		}
		.auto-style7 {
			width: 196px;
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
					<td class="auto-style7">&nbsp;</td>
					<td class="auto-style5">
						<asp:Button ID="ButtonCreateCourse" runat="server" OnClick="ButtonCreateCourse_Click" Text="Создать курс" Width="150px" />
					</td>
					<td class="auto-style5">
						<asp:Button ID="ButtonReviewCourse" runat="server" OnClick="ButtonReviewCourse_Click" Text="Показать курс" Width="150px" />
					</td>
					<td class="auto-style5">
						<asp:Button ID="ButtonCourseReservation" runat="server" OnClick="ButtonCourseReservation_Click" Text="Зарезервировать" Width="150px" />
					</td>
					<td class="auto-style5">
						<asp:Button ID="ButtonGetDoc" runat="server" OnClick="ButtonGetDoc_Click" Text="Отчет doc на почту" Width="150px" />
					</td>
					<td class="auto-style5">
						<asp:Button ID="ButtonGetXls" runat="server" OnClick="ButtonGetXls_Click" Text="Отчет xls на почту" Width="150px" />
					</td>
					<td>
						<asp:Button ID="ButtonGetPdf" runat="server" OnClick="ButtonGetPdf_Click" Text="Отчет pdf" Width="150px" />
					</td>
				</tr>
			</table>
        </div>
    	<table class="auto-style1">
			<tr>
				<td class="auto-style6">&nbsp;</td>
				<td>
					<asp:GridView ID="dataGridView" runat="server" AutoGenerateColumns="False">
						<Columns>
							 <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
							 <asp:BoundField DataField="CourseName" HeaderText="Наименование" SortExpression="CourseName" />
							<asp:BoundField DataField="DateCreate" HeaderText="Дата" SortExpression="DateCreate" />
							<asp:BoundField DataField="Price" HeaderText="Стоимость" SortExpression="Price" />
							<asp:BoundField DataField="isReserved" HeaderText="Бронь" SortExpression="isReserved" />
                <asp:CommandField ShowSelectButton="true" SelectText="<<" />
						</Columns>
						<SelectedRowStyle BackColor="#CCCCCC" />
					</asp:GridView>
				</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
			</tr>
			<tr>
				<td class="auto-style6">&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
			</tr>
			<tr>
				<td class="auto-style6">&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
			</tr>
			<tr>
				<td class="auto-style6">&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
			</tr>
		</table>
    </form>
</body>
</html>
