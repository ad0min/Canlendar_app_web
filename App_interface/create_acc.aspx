<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="create_acc.aspx.cs" Inherits="app.CreateAcc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>NEW ACCOUNT</title>
    <style type="text/css">
    body{
    margin: 0 auto;
    width: 53%
        }
    ul{
        font-family: Comic;
        text-align: center;
        color: #45a049;
        font-size: 300%;
    }
    a.one:link {
        color: #B4B4B4;
        background-color: transparent;
        text-decoration: none;
    }
    a.one:visited {
        color: #B4B4B4;
        background-color: transparent;
        text-decoration: none;
    }
    a.one:hover {
        color: white;
        background-color: #B4B4B4;
        text-decoration: none;
    }
    a.one:active {
        color: #B4B4B4;
        background-color: transparent;
        text-decoration: none;
    }
    input[type=text], select {
    width: 100%;
    padding: 12px 20px;
    margin: 8px 0;
    display: inline-block;
    border: 1px solid #ccc;
    border-radius: 4px;
    box-sizing: border-box;
    }
    input[type=submit] {
    width: 100%;
    background-color: #4CAF50;
    color: white;
    padding: 14px 20px;
    margin: 8px 0;
    border: none;
    border-radius: 4px;
    cursor: pointer;
    }
    input[type=submit]:hover {
    background-color: #45a049;
    }
    input[type=password]{
    width: 100%;
    padding: 12px 20px;
    margin: 8px 0;
    display: inline-block;
    border: 1px solid #ccc;
    border-radius: 4px;
    box-sizing: border-box;
    }
    div {
    border-radius: 5px;
    background-color: #f2f2f2;
    padding: 20px;
    }
    </style>
</head>
<body>
    <p class="one">
        <ul>CREATE AN COUNT</ul>
    </p>
    <form id="form1" runat="server">
    <div>
        &nbsp;User name :<br />
        <asp:TextBox ID="TextboxUser" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextboxUser" ErrorMessage="User name is required" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextboxUser" ErrorMessage="Username is existed" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        E-mail :
        <asp:TextBox ID="TextboxMail" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextboxMail" ErrorMessage="E-mail is required" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextboxMail" ErrorMessage="You must enter valid e-mail." ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <br />
        Password : <asp:TextBox ID="TextboxPass" TextMode="Password" runat="server"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextboxPass" ErrorMessage="Password is required" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        Comfirm Password : <br />
        <asp:TextBox ID="TextboxComfirmpass" TextMode="Password" runat="server"></asp:TextBox>

        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextboxComfirmpass" ErrorMessage="Comfirm Password is required" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextboxPass" ControlToValidate="TextboxComfirmpass" ErrorMessage="The comfirm password must same with password." ForeColor="Red"></asp:CompareValidator>
        <br />

        <asp:Button ID="ButtonCreateacc" runat="server" Text="CREATE " OnClick="ButtonCreateacc_Click" />
        <a href="Login.aspx">Login Page</a>
    </div>
    </form>
</body>
</html>
