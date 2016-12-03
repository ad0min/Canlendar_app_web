<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manager.aspx.cs" Inherits="app.App_interface.Manageraspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" Width="369px">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="User" HeaderText="User" SortExpression="User" />
                <asp:BoundField DataField="Pass" HeaderText="Pass" SortExpression="Pass" />
                <asp:BoundField DataField="Mail" HeaderText="Mail" SortExpression="Mail" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [ID], [User], [Pass], [Mail] FROM [Account]"></asp:SqlDataSource>
    </form>
</body>
</html>
