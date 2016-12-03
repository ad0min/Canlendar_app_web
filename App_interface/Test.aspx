<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="app.App_interface.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="Expr1" HeaderText="Expr1" ReadOnly="True" SortExpression="Expr1" />
                <asp:BoundField DataField="Todo" HeaderText="Todo" SortExpression="Todo" />
                <asp:BoundField DataField="Day" HeaderText="Day" SortExpression="Day" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DataConnectionString %>" SelectCommand="SELECT USER AS Expr1, Todo.Todo, Todo.Day FROM Account INNER JOIN Todo ON Account.Id = Todo.accID WHERE (Account.[User] = @user ) AND (Todo.Day = @date)">
            <SelectParameters>
                <asp:SessionParameter Name="user" SessionField="Username" />
                <asp:Parameter Name="date" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
