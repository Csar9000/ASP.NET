<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Complex.aspx.cs" Inherits="WebApplication4.Complex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 59%;
        }
        .auto-style2 {
            width: 133px;
            height: 25px;
        }
        .auto-style5 {
            height: 23px;
        }
        .auto-style6 {
            width: 133px;
            height: 23px;
        }
        .auto-style8 {
            width: 115px;
            height: 25px;
        }
        .auto-style9 {
            width: 153px;
            height: 25px;
        }
        .auto-style10 {
            width: 66px;
            height: 25px;
        }
        .auto-style13 {
            width: 66px;
            height: 23px;
        }
        .auto-style14 {
            width: 115px;
            height: 23px;
        }
        .auto-style15 {
            width: 153px;
            height: 23px;
        }
        .auto-style19 {
            height: 25px;
            width: 45px;
        }
        .auto-style20 {
            height: 23px;
            width: 45px;
        }
        .auto-style22 {
            height: 25px;
            width: 218px;
        }
        .auto-style23 {
            height: 23px;
            width: 218px;
        }
        .auto-style24 {
            width: 81%;
        }
        .auto-style25 {
            width: 527px;
        }
        .auto-style26 {
            width: 284px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style23">
                        <asp:Label ID="Label2" runat="server" Text="GroupNum"></asp:Label>
                    </td>
                    <td class="auto-style20">
                        &nbsp;</td>
                    <td class="auto-style6">
                        <asp:Label ID="Label6" runat="server" Text="Current Date"></asp:Label>
                    </td>
                    <td class="auto-style13">
                        <asp:Label ID="Label3" runat="server" Text="TaskCount"></asp:Label>
                    </td>
                    <td class="auto-style14" colspan="2">
                        <asp:Label ID="Label4" runat="server" Text="Subject"></asp:Label>
                    </td>
                    <td class="auto-style15">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style22">
                        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style19">
                        &nbsp;</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="TextBoxDate" runat="server" Width="120px"></asp:TextBox>
                    </td>
                    <td class="auto-style10">
                        <asp:TextBox ID="TextBoxTaskCount" runat="server" Width="122px"></asp:TextBox>
                    </td>
                    <td class="auto-style8" colspan="2">
                        <asp:TextBox ID="TextBoxSubject" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style9">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style23" rowspan="4">
                        <asp:GridView ID="GridView1" runat="server" Width="526px">
                        </asp:GridView>
                    </td>
                    <td class="auto-style5">
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Complete TaskOne" />
                    </td>
                    <td class="auto-style5" rowspan="4"></td>
                    <td class="auto-style5" colspan="2" rowspan="4">
                        <asp:GridView ID="GridView2" runat="server" Width="386px">
                        </asp:GridView>
                    </td>
                    <td class="auto-style5" colspan="2">
                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Complete TaskTwo" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5"></td>
                    <td class="auto-style5" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style5" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style5" colspan="2">
                        &nbsp;</td>
                </tr>
            </table>
        </div>
        <table class="auto-style24">
            <tr>
                <td class="auto-style25">
                    <asp:Button ID="Button3" runat="server" Text="ToExcel" OnClick="Button3_Click" />
                    <input id="File1" type="file" runat="server" /></td>
                <td class="auto-style26">&nbsp;</td>
                <td>
                    <asp:Button ID="Button5" runat="server" Text="ToExcel" OnClick="Button5_Click" />
                    <input id="File3" type="file" runat="server"/></td>
            </tr>
            <tr>
                <td class="auto-style25">
                    <asp:Button ID="Button4" runat="server" Text="FromExcel" OnClick="Button4_Click" />
                    <input id="File2" type="file" runat="server" /></td>
                <td class="auto-style26">&nbsp;</td>
                <td>
                    <asp:Button ID="Button6" runat="server" Text="FromExcel" OnClick="Button6_Click" style="height: 25px" />
                    <input id="File4" type="file" runat="server"/></td>
            </tr>
            <tr>
                <td class="auto-style5" colspan="3">
                    <asp:Button ID="Button7" runat="server" Text="Group" />
                    <asp:Button ID="Button8" runat="server" Text="Student" />
                    <asp:Button ID="Button9" runat="server" Text="Button" />
                    <asp:Button ID="Button10" runat="server" Text="Button" />
                    <asp:Button ID="Button11" runat="server" Text="Button" />
                    <asp:Button ID="Button12" runat="server" Text="Button" />
                </td>
            </tr>
        </table>
        <asp:Panel ID="Panel5" runat="server" Width="1203px" HorizontalAlign="Center">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Пустое поле группы" ControlToValidate="TextBox6"></asp:RequiredFieldValidator>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxDate" ErrorMessage="Пустое поле даты"></asp:RequiredFieldValidator>
             <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxTaskCount" ErrorMessage="Пустое поле количества заданий"></asp:RequiredFieldValidator>
             <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxSubject" ErrorMessage="Пустое поле предмета"></asp:RequiredFieldValidator>
             <br />
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="TextBoxDate" ErrorMessage="Неорректная дата" Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
             <br />
            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Слишком длинное название группы" ControlToValidate="TextBox6" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
            <br />
            <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="Некорректное число!" ControlToValidate="TextBoxTaskCount" OnServerValidate="CustomValidator2_ServerValidate"></asp:CustomValidator>
            <br />
            <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="Слишком длинное название предмета" OnServerValidate="CustomValidator3_ServerValidate"></asp:CustomValidator>
            <br />

        </asp:Panel>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    </form>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</body>
</html>
