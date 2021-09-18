<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="WebApplication4.Student" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 41%;
        }
        .auto-style2 {
            width: 173px;
        }
        .auto-style3 {
            width: 186px;
        }
        .auto-style4 {
            width: 173px;
            height: 25px;
        }
        .auto-style5 {
            width: 186px;
            height: 25px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style4">
                    <asp:Label ID="Label1" runat="server" Text="Номер зачётной книжки    "></asp:Label>
                    </td>
                    <td class="auto-style5">
                    <asp:TextBox ID="TextBox1" runat="server" Width="178px"></asp:TextBox>
                    </td>
                    <td rowspan="3">
                       
                        <asp:Panel ID="Panel5" runat="server" ScrollBars="Vertical" BorderStyle="Solid" style="max-height:200px">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="NumberOfCreditBook" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                    <asp:BoundField DataField="NumberOfCreditBook" HeaderText="NumberOfCreditBook" ReadOnly="True" SortExpression="NumberOfCreditBook" />
                                    <asp:BoundField DataField="Group_2_GroupNum" HeaderText="Group_2_GroupNum" SortExpression="Group_2_GroupNum" />
                                    <asp:BoundField DataField="FIO" HeaderText="FIO" SortExpression="FIO" />
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Students & TasksConnectionString %>" DeleteCommand="StudentDeleteProc" DeleteCommandType="StoredProcedure" InsertCommand="StudentInsertProc" InsertCommandType="StoredProcedure" SelectCommand="StudentSelectProc" SelectCommandType="StoredProcedure" UpdateCommand="StudentUpdateProc" UpdateCommandType="StoredProcedure">
                                <DeleteParameters>
                                    <asp:ControlParameter ControlID="TextBox1" Name="NumberOfCreditBook" PropertyName="Text" Type="Int32" />
                                </DeleteParameters>
                                <InsertParameters>
                                    <asp:ControlParameter ControlID="TextBox1" Name="NumberOfCreditBook" PropertyName="Text" Type="Int32" />
                                    <asp:ControlParameter ControlID="TextBox2" Name="NewGroupNum" PropertyName="Text" Type="String" />
                                    <asp:ControlParameter ControlID="TextBox3" Name="NewFIO" PropertyName="Text" Type="String" />
                                </InsertParameters>
                                <UpdateParameters>
                                    <asp:ControlParameter ControlID="TextBox1" Name="NumberOfCreditBook" PropertyName="Text" Type="Int32" />
                                    <asp:ControlParameter ControlID="TextBox2" Name="NewGroupNum" PropertyName="Text" Type="String" />
                                    <asp:ControlParameter ControlID="TextBox3" Name="NewFIO" PropertyName="Text" Type="String" />
                                </UpdateParameters>
                            </asp:SqlDataSource>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                    <asp:Label ID="Label2" runat="server" Text="Номер группы  "></asp:Label>
                    </td>
                    <td class="auto-style3">
                    <asp:TextBox ID="TextBox2" runat="server" Width="178px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                    <asp:Label ID="Label3" runat="server" Text="ФИО"></asp:Label>
                    </td>
                    <td class="auto-style3">
                    <asp:TextBox ID="TextBox3" runat="server" Width="178px"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        
        <asp:Panel ID="Panel2" runat="server" Width="612px">
            <asp:Button ID="Button1" runat="server" Text="Добавить" OnClick="Button1_Click" style="height: 25px" />
            <asp:Button ID="Button2" runat="server" Text="Удалить" OnClick="Button2_Click" />
            <asp:Button ID="Button3" runat="server" Text="Изменить" OnClick="Button3_Click" />
            <asp:Panel ID="Panel4" runat="server" Width="610px">

                <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Button" />

                <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Button" />

            </asp:Panel>
        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server" Height="241px" HorizontalAlign="Center" Width="611px">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ErrorMessage="Пустое поле зачётной книжки!" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
             <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Пустое поле номера группы!" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
             <br />
            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Некорректный номер!" ControlToValidate="TextBox1" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
             <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Пустое поле ФИО" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>
            <br/>
            <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="Слишком длинное название группы" OnServerValidate="CustomValidator2_ServerValidate"></asp:CustomValidator>
            <br/>
            <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="Слишком длинное ФИО" OnServerValidate="CustomValidator3_ServerValidate"></asp:CustomValidator>
            <br/>
        </asp:Panel>
          
    </form>
</body>
</html>
