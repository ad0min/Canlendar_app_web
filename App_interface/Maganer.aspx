<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Maganer.aspx.cs" Inherits="app.Maganer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" Height="150px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="370px">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="User" HeaderText="User" SortExpression="User" />
                <asp:BoundField DataField="Pass" HeaderText="Pass" SortExpression="Pass" />
                <asp:BoundField DataField="Mail" HeaderText="Mail" SortExpression="Mail" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DataConnectionString %>" SelectCommand="SELECT * FROM [Account]" OnSelecting="SqlDataSource1_Selecting"></asp:SqlDataSource>
    </form>
</body>
</html>
