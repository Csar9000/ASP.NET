<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tasks.aspx.cs" Inherits="WebApplication4.Tasks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 78%;
        }
        .auto-style2 {
            margin-top: 0px;
        }
        .auto-style3 {
            width: 98px;
        }
        .auto-style4 {
            width: 160px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style4">
                        id задания</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style2"></asp:TextBox>
                    </td>
                    <td rowspan="4">
                        <asp:Panel ID="Panel1" runat="server" style="max-height:200px" ScrollBars="Vertical" >
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="idTaskNumber" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                    <asp:BoundField DataField="idTaskNumber" HeaderText="idTaskNumber" ReadOnly="True" SortExpression="idTaskNumber" />
                                    <asp:BoundField DataField="TaskNumber" HeaderText="TaskNumber" SortExpression="TaskNumber" />
                                    <asp:BoundField DataField="Subject_SubjectName" HeaderText="Subject_SubjectName" SortExpression="Subject_SubjectName" />
                                    <asp:BoundField DataField="Summary" HeaderText="Summary" SortExpression="Summary" />
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Students & TasksConnectionString %>" DeleteCommand="TasksDELETEProc" DeleteCommandType="StoredProcedure" InsertCommand="TasksInsertProc" InsertCommandType="StoredProcedure" SelectCommand="TasksSelectProc" SelectCommandType="StoredProcedure" UpdateCommand="TasksUPDATEProc" UpdateCommandType="StoredProcedure">
                                <DeleteParameters>
                                    <asp:ControlParameter ControlID="TextBox1" Name="idTaskNumber" PropertyName="Text" Type="Int32" />
                                    <asp:ControlParameter ControlID="TextBox2" Name="TaskNumber" PropertyName="Text" Type="Int16" />
                                    <asp:ControlParameter ControlID="TextBox3" Name="Subject_SubjectName" PropertyName="Text" Type="String" />
                                    <asp:ControlParameter ControlID="TextBox4" Name="Summary" PropertyName="Text" Type="String" />
                                </DeleteParameters>
                                <InsertParameters>
                                    <asp:ControlParameter ControlID="TextBox1" Name="idTaskNumber" PropertyName="Text" Type="Int32" />
                                    <asp:ControlParameter ControlID="TextBox2" Name="TaskNumber" PropertyName="Text" Type="Int16" />
                                    <asp:ControlParameter ControlID="TextBox3" Name="Subject_SubjectName" PropertyName="Text" Type="String" />
                                    <asp:ControlParameter ControlID="TextBox4" Name="Summary" PropertyName="Text" Type="String" />
                                </InsertParameters>
                                <UpdateParameters>
                                    <asp:ControlParameter ControlID="TextBox1" Name="idTaskNumber" PropertyName="Text" Type="Int32" />
                                    <asp:ControlParameter ControlID="TextBox2" Name="TaskNumber" PropertyName="Text" Type="Int16" />
                                    <asp:ControlParameter ControlID="TextBox3" Name="Subject_SubjectName" PropertyName="Text" Type="String" />
                                    <asp:ControlParameter ControlID="TextBox4" Name="Summary" PropertyName="Text" Type="String" />
                                </UpdateParameters>
                            </asp:SqlDataSource>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        Номер задания</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        Название предмета</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        Краткое опписание</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Button ID="Button1" runat="server" Text="Добавить" OnClick="Button1_Click" />
                        <asp:Button ID="Button2" runat="server" Text="Удалить" OnClick="Button2_Click" />
                        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Изменить" />
                        <asp:Button ID="Button4" runat="server" Text="Найти" OnClick="Button4_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Button ID="Button5" runat="server" Text="Student" />
                        <asp:Button ID="Button6" runat="server" Text="Subject" />
                        <asp:Button ID="Button7" runat="server" Text="StudentHasTask" />
                        <asp:Button ID="Button8" runat="server" Text="Curriculum" />
                        <asp:Button ID="Button9" runat="server" Text="Complex" />
                        <asp:Button ID="Button10" runat="server" Text="Group" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:Panel ID="Panel2" runat="server" Height="157px" Width="697px" HorizontalAlign="Center">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Пустое поле id задания!!" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
            <br/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Пустое поле номера задания!" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
            <br/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Пустое поле названия предмета!" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>
            <br/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Пустое поле краткого описания!" ControlToValidate="TextBox4"></asp:RequiredFieldValidator>
            <br/>
            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Некорректный номер id задания!!!" ControlToValidate="TextBox1" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
            <br/>
            <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="Слишком длинное название!" ControlToValidate="TextBox3" OnServerValidate="CustomValidator2_ServerValidate"></asp:CustomValidator>
            <br/>
            <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="Слишком большое опписание!!!" ControlToValidate="TextBox4" OnServerValidate="CustomValidator3_ServerValidate"></asp:CustomValidator>
            <br/>
            <asp:CustomValidator ID="CustomValidator4" runat="server" ControlToValidate="TextBox2" ErrorMessage="Некорректный номер задания!" OnServerValidate="CustomValidator4_ServerValidate"></asp:CustomValidator>
        </asp:Panel>
    </form>
</body>
</html>
