<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormReport.aspx.cs" Inherits="AbstractUniversityClientView.WebFormReport" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

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
			width: 401px;
		}
		.auto-style3 {
			width: 213%;
		}
		.auto-style4 {
			width: 35px;
		}
		.auto-style5 {
			width: 60px;
		}
		.auto-style6 {
			width: 95px;
		}
		.auto-style7 {
			width: 96px;
		}
		.auto-style8 {
			width: 249px;
		}
		.auto-style9 {
			width: 83px;
		}
	</style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
				<tr>
					<td class="auto-style4">
						<table class="auto-style3">
							<tr>
								<td class="auto-style9">&nbsp;</td>
								<td class="auto-style5">&nbsp;</td>
								<td class="auto-style6">&nbsp;</td>
							</tr>
							<tr>
								<td class="auto-style9">&nbsp;</td>
								<td class="auto-style5">&nbsp;</td>
								<td class="auto-style6">&nbsp;</td>
							</tr>
							<tr>
								<td class="auto-style9">
									<asp:Button ID="ButtonReport" runat="server" OnClick="ButtonReport_Click" Text="Отчет" Width="93px" />
								</td>
								<td class="auto-style5">&nbsp;</td>
								<td class="auto-style6">
									<asp:Button ID="ButtonCancel" runat="server" OnClick="ButtonCancel_Click" Text="Вернуться" Width="93px" />
								</td>
							</tr>
							<tr>
								<td class="auto-style9">&nbsp;</td>
								<td class="auto-style5">&nbsp;</td>
								<td class="auto-style6">&nbsp;</td>
							</tr>
							<tr>
								<td class="auto-style9">&nbsp;</td>
								<td class="auto-style5">&nbsp;</td>
								<td class="auto-style6">&nbsp;</td>
							</tr>
						</table>
						<asp:ScriptManager ID="ScriptManager1" runat="server">
						</asp:ScriptManager>
					</td>
					<td class="auto-style8">&nbsp;</td>
					<td class="auto-style2">
						<rsweb:ReportViewer ID="ReportViewer" runat="server" Font-Names="Verdana" Font-Size="8pt" Width="930px">
                <LocalReport ReportPath="ReportCoursePlace.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource Name="DataSetCoursePlace" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
					</td>
					<td class="auto-style7">&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td class="auto-style4">c<asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="16px" Width="148px">
						<DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
						<NextPrevStyle VerticalAlign="Bottom" />
						<OtherMonthDayStyle ForeColor="#808080" />
						<SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
						<SelectorStyle BackColor="#CCCCCC" />
						<TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
						<TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
						<WeekendDayStyle BackColor="#FFFFCC" />
						</asp:Calendar>
						по<asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="159px" Width="131px">
							<DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
							<NextPrevStyle VerticalAlign="Bottom" />
							<OtherMonthDayStyle ForeColor="#808080" />
							<SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
							<SelectorStyle BackColor="#CCCCCC" />
							<TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
							<TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
							<WeekendDayStyle BackColor="#FFFFCC" />
						</asp:Calendar>
					</td>
					<td class="auto-style8">&nbsp;</td>
					<td class="auto-style2">&nbsp;</td>
					<td class="auto-style7">&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td class="auto-style4">&nbsp;</td>
					<td class="auto-style8">&nbsp;</td>
					<td class="auto-style2">&nbsp;</td>
					<td class="auto-style7">&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
			</table>
        </div>
    </form>
</body>
</html>
