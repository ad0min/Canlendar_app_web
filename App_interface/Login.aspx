<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="app.Login" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LOGIN</title>
    <style type="text/css">
    body{
    margin: 0 auto;
    width: 30%
    }
    p.one{
        position: relative;
        background-color: white;
        text-align: center;
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
        <ul>LOGIN</ul>
    </p>
    <form id="form1" runat="server">
    <div>
        User name
        :
        <asp:TextBox ID="TextboxUser" runat="server" OnTextChanged="user_TextChanged"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextboxUser" ErrorMessage="Username is required" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        Password :
        <asp:TextBox ID="TextboxPass" TextMode="Password" runat="server"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextboxPass" ErrorMessage="Password is required" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:Button ID="btnsubmit" runat="server" Text="LOGIN" OnClick="btnsubmit_Click" />
        <a href="create_acc.aspx" class="one">Create new User </a>
    </div>
    </form>
</body>
</html>
