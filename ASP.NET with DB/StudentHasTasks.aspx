<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentHasTasks.aspx.cs" Inherits="WebApplication4.StudentHasTasks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 69%;
        }
        .auto-style2 {
            width: 94px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Номер зачётной книжки"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                    <td rowspan="4">
                        <asp:Panel ID="Panel2" runat="server" ScrollBars="Vertical" style="max-height:200px">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Student_NumberOfCreditBook,Tasks_idTaskNumber" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                    <asp:BoundField DataField="Student_NumberOfCreditBook" HeaderText="Student_NumberOfCreditBook" ReadOnly="True" SortExpression="Student_NumberOfCreditBook" />
                                    <asp:BoundField DataField="Tasks_idTaskNumber" HeaderText="Tasks_idTaskNumber" ReadOnly="True" SortExpression="Tasks_idTaskNumber" />
                                    <asp:BoundField DataField="TaskPassDate" HeaderText="TaskPassDate" SortExpression="TaskPassDate" />
                                    <asp:BoundField DataField="TaskGetDate" HeaderText="TaskGetDate" SortExpression="TaskGetDate" />
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Students & TasksConnectionString %>" DeleteCommand="Student&amp;TaskDeleteProc" DeleteCommandType="StoredProcedure" InsertCommand="Student&amp;TaskInsertProc" InsertCommandType="StoredProcedure" SelectCommand="Student&amp;TaskSelectProc" SelectCommandType="StoredProcedure" UpdateCommand="Student&amp;TaskUpdateProc" UpdateCommandType="StoredProcedure">
                                <DeleteParameters>
                                    <asp:ControlParameter ControlID="TextBox1" Name="Student_NumberOfCreditBook" PropertyName="Text" Type="Int32" />
                                    <asp:ControlParameter ControlID="TextBox2" Name="Tasks_idTaskNumber" PropertyName="Text" Type="Int32" />
                                </DeleteParameters>
                                <InsertParameters>
                                    <asp:ControlParameter ControlID="TextBox1" Name="Student_NumberOfCreditBook" PropertyName="Text" Type="Int32" />
                                    <asp:ControlParameter ControlID="TextBox2" Name="Tasks_idTaskNumber" PropertyName="Text" Type="Int32" />
                                    <asp:ControlParameter ControlID="TextBox3" DbType="Date" Name="TaskPassDate" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="TextBox4" DbType="Date" Name="TaskGetDate" PropertyName="Text" />
                                </InsertParameters>
                                <UpdateParameters>
                                    <asp:ControlParameter ControlID="TextBox1" Name="Student_NumberOfCreditBook" PropertyName="Text" Type="Int32" />
                                    <asp:ControlParameter ControlID="TextBox2" Name="Tasks_idTaskNumber" PropertyName="Text" Type="Int32" />
                                    <asp:ControlParameter ControlID="TextBox3" DbType="Date" Name="TaskPassDate" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="TextBox4" DbType="Date" Name="TaskGetDate" PropertyName="Text" />
                                </UpdateParameters>
                            </asp:SqlDataSource>
                            <asp:Label ID="Label5" runat="server" Text="DateTimeNow"></asp:Label>
                            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="id задания"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Дата получения"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Дата сдачи"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Button ID="Button1" runat="server" Text="Добавить" OnClick="Button1_Click" />
                        <asp:Button ID="Button2" runat="server" Text="Удалить" OnClick="Button2_Click" />
                        <asp:Button ID="Button3" runat="server" Text="Изменить" OnClick="Button3_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Button ID="Button5" runat="server" Text="Student" OnClick="Button5_Click" />
                        <asp:Button ID="Button6" runat="server" Text="StudentHasTask" OnClick="Button6_Click" />
                        <asp:Button ID="Button7" runat="server" Text="Subject" OnClick="Button7_Click" />
                        <asp:Button ID="Button8" runat="server" Text="Curriculum" OnClick="Button8_Click" />
                        <asp:Button ID="Button9" runat="server" Text="Group" OnClick="Button9_Click" />
                        <asp:Button ID="Button10" runat="server" Text="Complex" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:Panel ID="Panel1" runat="server" Width="1027px" HorizontalAlign="Center">
            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="*" ControlToValidate="TextBox1" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
            <br/>
            <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="*" ControlToValidate="TextBox2" OnServerValidate="CustomValidator2_ServerValidate"></asp:CustomValidator>
             <br/>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Некорректная дата получения" Type="Date" ControlToValidate="TextBox3" Operator="DataTypeCheck"></asp:CompareValidator>
             <br/>
            <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Некорректная дата сдачи" Type="Date" ControlToValidate="TextBox4" Operator="DataTypeCheck"></asp:CompareValidator>
            <br/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Пустое поле даты получения" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>
            <br/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Пустое поле даты сдачи" ControlToValidate="TextBox4"></asp:RequiredFieldValidator>
            <br/>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Пустое поле зачётки!" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
            <br/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Пустое поле id" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
            <br/>
             <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="Дата сдачи не может быть раньше даты получения!" ControlToValidate="TextBox4" OnServerValidate="CustomValidator3_ServerValidate"></asp:CustomValidator>
            <br/>
             <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="TextBox4" ErrorMessage="Дата сдачи не может быть больше текущей!" OnLoad="CompareValidator3_Load" Operator="LessThan" Type="Date"></asp:CompareValidator>
             <br/>
        </asp:Panel>
    </form>
</body>
</html>
