<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Subject.aspx.cs" Inherits="WebApplication4.Subject" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 46%;
            height: 379px;
        }
        .auto-style2 {
            height: 23px;
            width: 108px;
        }
        .auto-style3 {
            width: 162px;
        }
        .auto-style5 {
            height: 23px;
            width: 60px;
        }
        .auto-style6 {
            width: 60px;
        }
        .auto-style7 {
            width: 108px;
        }
        .auto-style8 {
            width: 162px;
            height: 23px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style6">
                        <asp:Label ID="Label1" runat="server" Text="SubjectName"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style3" colspan="2" rowspan="3">
                        <asp:GridView ID="GridView1" runat="server" Height="160px" Width="286px" AutoGenerateColumns="False" DataKeyNames="SubjectName" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:BoundField DataField="SubjectName" HeaderText="SubjectName" ReadOnly="True" SortExpression="SubjectName" />
                                <asp:BoundField DataField="TeachersFIO" HeaderText="TeachersFIO" SortExpression="TeachersFIO" />
                                <asp:BoundField DataField="Department" HeaderText="Department" SortExpression="Department" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Students & TasksConnectionString %>" DeleteCommand="SubjectDeleteProc" DeleteCommandType="StoredProcedure" InsertCommand="SubjectInsertProc" InsertCommandType="StoredProcedure" SelectCommand="SubjectSelectProc" SelectCommandType="StoredProcedure" UpdateCommand="SubjectUpdateProc" UpdateCommandType="StoredProcedure">
                            <DeleteParameters>
                                <asp:ControlParameter ControlID="TextBox1" Name="SubjectName" PropertyName="Text" Type="String" />
                                <asp:ControlParameter ControlID="TextBox2" Name="TeachersFIO" PropertyName="Text" Type="String" />
                                <asp:ControlParameter ControlID="TextBox3" Name="Department" PropertyName="Text" Type="String" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:ControlParameter ControlID="TextBox1" Name="SubjectName" PropertyName="Text" Type="String" />
                                <asp:ControlParameter ControlID="TextBox2" Name="TeachersFIO" PropertyName="Text" Type="String" />
                                <asp:ControlParameter ControlID="TextBox3" Name="Department" PropertyName="Text" Type="String" />
                            </InsertParameters>
                            <UpdateParameters>
                                <asp:ControlParameter ControlID="TextBox1" Name="SubjectName" PropertyName="Text" Type="String" />
                                <asp:ControlParameter ControlID="TextBox2" Name="TeachersFIO" PropertyName="Text" Type="String" />
                                <asp:ControlParameter ControlID="TextBox3" Name="Department" PropertyName="Text" Type="String" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">
                        <asp:Label ID="Label3" runat="server" Text="Teacher"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label2" runat="server" Text="Department"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Button ID="Button8" runat="server" Text="Добавить" OnClick="Button8_Click" />
                    </td>
                    <td class="auto-style2">
                        <asp:Button ID="Button7" runat="server" Text="Удалить" OnClick="Button7_Click" />
                    </td>
                    <td class="auto-style8">
                        <asp:Button ID="Button6" runat="server" Text="Изменить" OnClick="Button6_Click" />
                    </td>
                    <td class="auto-style8">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Button ID="Button9" runat="server" Text="Student" />
                        <asp:Button ID="Button10" runat="server" Text="Button" />
                        <asp:Button ID="Button11" runat="server" Text="Button" />
                        <asp:Button ID="Button12" runat="server" Text="Button" />
                        <asp:Button ID="Button13" runat="server" Text="Button" />
                        <asp:Button ID="Button14" runat="server" Text="Button" />
                    </td>
                </tr>
                <tr>
                    <td aria-orientation="vertical" colspan="4" >
                        <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center" Height="171px">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Пустая строка предмета!" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
                            <br/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Пустая строка учителя!" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
                            <br/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Пустая строка кафедры!" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>
                            <br/>
                            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Слишком длинное название предмета!" ControlToValidate="TextBox1" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                            <br/>
                            <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="Слишком длинное ФИО учителя!" ControlToValidate="TextBox2" OnServerValidate="CustomValidator2_ServerValidate"></asp:CustomValidator>
                            <br/>
                            <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="Слишком длинное название кафедры" ControlToValidate="TextBox3" OnServerValidate="CustomValidator3_ServerValidate"></asp:CustomValidator>
                            <br/>
                        </asp:Panel>
                    </td>
                </tr>
                </table>
        </div>
    </form>
</body>
</html>
