<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Group.aspx.cs" Inherits="WebApplication4.Group" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
     
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 3px;
        }
        .auto-style7 {
            height: 244px;
            width: 661px;
        }
        .auto-style12 {
            width: 347px;
            height: 5px;
        }
        .auto-style14 {
            width: 347px;
            height: 30px;
        }
        .auto-style18 {
            width: 347px;
            height: 28px;
        }
        .auto-style21 {
            width: 347px;
        }
    </style>
</head>
<body style="height: 724px">
    <form id="form1" runat="server" class="auto-style7">
        <table class="auto-style1">
            <tr>
                <td class="auto-style12">
                    <asp:Label ID="Label1" runat="server" Text="Номер группы"></asp:Label>
&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox3" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td rowspan="4" class="auto-style21" >
                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" BorderStyle="Solid" style="max-height:200px">

                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="GroupNum" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" BorderStyle="Solid" MaxHeight="250px" MinHeight="0px">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:BoundField DataField="GroupNum" HeaderText="GroupNum" ReadOnly="True" SortExpression="GroupNum" />
                                <asp:BoundField DataField="MajorName" HeaderText="MajorName" SortExpression="MajorName" />
                                <asp:BoundField DataField="Year_2" HeaderText="Year_2" SortExpression="Year_2" />
                            </Columns>
                        </asp:GridView>

                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Students & TasksConnectionString %>" DeleteCommand="Group_2DeleteProc" DeleteCommandType="StoredProcedure" InsertCommand="Group_2InsertProc" InsertCommandType="StoredProcedure" OnInserting="SqlDataSource1_Inserting" SelectCommand="Group_2SelectProc" SelectCommandType="StoredProcedure" UpdateCommand="GroupUpdateProc" UpdateCommandType="StoredProcedure">
                            <DeleteParameters>
                                <asp:ControlParameter ControlID="TextBox3" Name="GroupNum" PropertyName="Text" Type="String" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:ControlParameter ControlID="TextBox3" Name="GroupNum" PropertyName="Text" Type="String" />
                                <asp:ControlParameter ControlID="TextBox2" Name="MajorName" PropertyName="Text" Type="String" />
                                <asp:ControlParameter ControlID="TextBox4" Name="Year" PropertyName="Text" DbType="Date" />
                            </InsertParameters>
                            <UpdateParameters>
                                <asp:ControlParameter ControlID="TextBox3" Name="GroupNum" PropertyName="Text" Type="String" />
                                <asp:ControlParameter ControlID="TextBox2" Name="NewMajorName" PropertyName="Text" Type="String" />
                                <asp:ControlParameter ControlID="TextBox4" DbType="Date" Name="Year" PropertyName="Text" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td class="auto-style18">
                    <asp:Label ID="Label2" runat="server" Text="Специальность"></asp:Label>
&nbsp;&nbsp;
&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox2" runat="server" Width="143px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style21">
                    <asp:Label ID="Label3" runat="server" Text="Год поступления"></asp:Label>
&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox4" runat="server" Width="143px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style14" rowspan="2" aria-disabled="False">
&nbsp;&nbsp;&nbsp;
                    </td>
            </tr>

        </table>
        
        <asp:Panel ID="Panel2" runat="server">
            <asp:Button ID="Button1" runat="server" Text="Добавить" OnClick="Button1_Click" style="height: 25px" />
            <asp:Button ID="Button2" runat="server" Text="Удалить" OnClick="Button2_Click" />
            <asp:Button ID="Button3" runat="server" Text="Изменить" OnClick="Button3_Click" />
            <asp:Panel ID="Panel4" runat="server">
                <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Student" />
                <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Complex" />
                <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="Subject" />
                <asp:Button ID="Button8" runat="server" OnClick="Button8_Click" Text="Student_Has_Task" />
                <asp:Button ID="Button9" runat="server" OnClick="Button9_Click" Text="Tasks" />
                <asp:Button ID="Button10" runat="server" OnClick="Button10_Click" Text="Curriculum" />
            </asp:Panel>
        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server" Height="241px" HorizontalAlign="Center">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ErrorMessage="Пустое поле группы!" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>
             <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Пустое поле даты!" ControlToValidate="TextBox4"></asp:RequiredFieldValidator>
             <br />
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="TextBox4" ErrorMessage="Некорректная дата!" Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
             <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Пустое поле специальности!" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
            <br/>
            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Слишком длинное название группы!" ControlToValidate="TextBox3" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
            <br/>
            <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="Слишком длинное название специальности!" ControlToValidate="TextBox2" OnServerValidate="CustomValidator2_ServerValidate"></asp:CustomValidator>
            <br/>
        </asp:Panel>
          
    </form>
</body>
   
</html>
