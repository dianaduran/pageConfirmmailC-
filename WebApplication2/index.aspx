<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebApplication2.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
</head>
<body>
    <h3 align="center">Iluma Agency</h3>
    <br />
    <form id="form1" runat="server">
        <table style="background-color:#eeeeee; width:60%" align="center" cellpadding="10px" >
            <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox ="true" runat="server"  /> 
            <tr>
                <td rowspan="1">Name</td>
                <td>
                     <asp:TextBox ID="txtName" runat="server" Width="99%"></asp:TextBox>
                </td>
                <td style="color:red">
                         <asp:requiredfieldvalidator 
                             id="RequiredFieldValidator1" 
                             runat="server" 
                             controltovalidate="txtName"
                             errormessage="Please enter name" 
                             Display="Dynamic">*
                           </asp:requiredfieldvalidator>
                      </td>
           </tr>
            <tr>
                <td>Last Name</td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server" Width="99%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Company</td>
                <td>
                    <asp:TextBox ID="txtCompany" runat="server" Width="99%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Email</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" Width="99%"></asp:TextBox>
                </td>
                 <td style="color:red">
                         <asp:requiredfieldvalidator 
                             id="RequiredFieldValidator2" 
                             runat="server" 
                             controltovalidate="txtEmail"
                             errormessage="Please enter email" 
                             Display="Dynamic">*
                           </asp:requiredfieldvalidator>
                      </td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Send" />
            </tr>
           </table>
    </form>
</body>
</html>
