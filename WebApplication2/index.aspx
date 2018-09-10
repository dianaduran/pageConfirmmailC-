<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebApplication2.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>

            <asp:Label ID="lblLastname" runat="server" Text="Last Name"></asp:Label>
            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>

            <asp:Label ID="lblCompany" runat="server" Text="Company"></asp:Label>
            <asp:TextBox ID="txtCompany" runat="server"></asp:TextBox>

            <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
           
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Send" />

        </div>
    </form>
</body>
</html>
