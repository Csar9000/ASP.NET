<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Curriculum.aspx.cs" Inherits="WebApplication4.WebForm1" %>

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
            width: 109px;
        }
        .auto-style3 {
            height: 22px;
        }
        .auto-style5 {
            width: 120px;
        }
        .auto-style9 {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label1" runat="server" Text="Номер группы"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="6" rowspan="3">
                        <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Group_2_GroupNum,Subject_SubjectName" DataSourceID="SqlDataSource1">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                    <asp:BoundField DataField="Group_2_GroupNum" HeaderText="Group_2_GroupNum" ReadOnly="True" SortExpression="Group_2_GroupNum" />
                                    <asp:BoundField DataField="Subject_SubjectName" HeaderText="Subject_SubjectName" ReadOnly="True" SortExpression="Subject_SubjectName" />
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Students & TasksConnectionString %>" DeleteCommand="CurriculumDeleteProc" DeleteCommandType="StoredProcedure" InsertCommand="CurriculumInsertProc1" InsertCommandType="StoredProcedure" SelectCommand="CurriculumSelectProc" SelectCommandType="StoredProcedure" UpdateCommand="CurriculumUpdateProc" UpdateCommandType="StoredProcedure">
                                <DeleteParameters>
                                    <asp:ControlParameter ControlID="TextBox1" Name="GroupNum" PropertyName="Text" Type="String" />
                                    <asp:ControlParameter ControlID="TextBox2" Name="SubjectName" PropertyName="Text" Type="String" />
                                </DeleteParameters>
                                <InsertParameters>
                                    <asp:ControlParameter ControlID="TextBox1" Name="GroupNum" PropertyName="Text" Type="String" />
                                    <asp:ControlParameter ControlID="TextBox2" Name="SubjectName" PropertyName="Text" Type="String" />
                                </InsertParameters>
                                <UpdateParameters>
                                    <asp:ControlParameter ControlID="TextBox1" Name="GroupNum" PropertyName="Text" Type="String" />
                                    <asp:ControlParameter ControlID="TextBox2" Name="SubjectName" PropertyName="Text" Type="String" />
                                    <asp:ControlParameter ControlID="DropDownList1" Name="NewSubjectName" PropertyName="SelectedValue" Type="String" />
                                </UpdateParameters>
                            </asp:SqlDataSource>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label2" runat="server" Text="Предмет"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label3" runat="server" Text="Новое название предмета"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" DataTextField="SubjectName" DataValueField="SubjectName">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Students & TasksConnectionString %>" SelectCommand="SELECT [SubjectName] FROM [Subject]"></asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" colspan="3">
                        <asp:Button ID="Button2" runat="server" Text="Добавить" OnClick="Button2_Click" />
                        <asp:Button ID="Button1" runat="server" Text="Удалить" OnClick="Button1_Click" />
                        <asp:Button ID="Button3" runat="server" Text="Изменить" OnClick="Button3_Click" />
                        <asp:Button ID="Button4" runat="server" Text="Найти" OnClick="Button4_Click" />
                    </td>
                    <td class="auto-style3"></td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style3"></td>
                    <td class="auto-style3"></td>
                    <td class="auto-style3"></td>
                </tr>
                <tr>
                    <td class="auto-style9" colspan="8">
                        <asp:Button ID="Button5" runat="server" Text="Student" OnClick="Button5_Click" />
                        <asp:Button ID="Button6" runat="server" Text="Group" OnClick="Button6_Click" />
                        <asp:Button ID="Button7" runat="server" Text="Tasks" OnClick="Button7_Click" />
                        <asp:Button ID="Button8" runat="server" Text="StudentHasTasks" OnClick="Button8_Click" />
                        <asp:Button ID="Button9" runat="server" Text="Subject" OnClick="Button9_Click" />
                        <asp:Button ID="Button10" runat="server" Text="Complex" OnClick="Button10_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:Panel ID="Panel2" runat="server" Height="141px" HorizontalAlign="Center" Width="548px">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Пустая строка GroupNum!" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
            <br/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Пустая строка предмета!" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
            <br/>
            <br/>
            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Слишком длинное название группы!" ControlToValidate="TextBox1" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
            <br/>
            <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="Слишком длинное название предмета!" ControlToValidate="TextBox2" OnServerValidate="CustomValidator2_ServerValidate"></asp:CustomValidator>
            <br/>
        </asp:Panel>
    </form>
</body>
</html>
