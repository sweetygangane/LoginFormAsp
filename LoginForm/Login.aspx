<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LoginFormWebApp.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Form</title>

    <style>
        body {
            font-family: Arial;
            background-color: #f2f2f2;
        }

        .login-container {
            width: 350px;
            margin: 100px auto;
            padding: 30px;
            background-color: white;
            border-radius: 10px;
            box-shadow: 0px 0px 10px gray;
        }

        .title {
            text-align: center;
            font-size: 28px;
            font-weight: bold;
            margin-bottom: 20px;
        }

        .form-group {
            margin-bottom: 15px;
        }

        .label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
        }

        .textbox {
            width: 100%;
            padding: 8px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        .btn {
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        .login-btn {
            background-color: #007bff;
            color: white;
        }

        .cancel-btn {
            background-color: #dc3545;
            color: white;
        }

        .button-group {
            text-align: center;
            margin-top: 20px;
        }

        .show-password {
            margin-top: 10px;
        }
    </style>

</head>

<body>

    <form id="form1" runat="server">

        <div class="login-container">

            <div class="title">
                Login Form
            </div>

            <div class="form-group">

                <asp:Label ID="Label1"
                    runat="server"
                    Text="Username"
                    CssClass="label">
                </asp:Label>

                <asp:TextBox ID="TextBox1"
                    runat="server"
                    CssClass="textbox">
                </asp:TextBox>

            </div>

            <div class="form-group">

                <asp:Label ID="Label2"
                    runat="server"
                    Text="Password"
                    CssClass="label">
                </asp:Label>

                <asp:TextBox ID="TextBox2"
                    runat="server"
                    TextMode="Password"
                    CssClass="textbox">
                </asp:TextBox>

                <div class="show-password">
                    <input type="checkbox"
                        onclick="togglePassword()" />
                    Show Password
                </div>

            </div>

            <div class="button-group">

                <asp:Button ID="Button1"
                    runat="server"
                    Text="Login"
                    CssClass="btn login-btn"
                    OnClick="Button1_Click" />

                <asp:Button ID="Button2"
                    runat="server"
                    Text="Cancel"
                    CssClass="btn cancel-btn"
                    OnClick="Button2_Click" />

            </div>

        </div>

    </form>

    <script>

        function togglePassword() {

            var passwordBox =
                document.getElementById('<%= TextBox2.ClientID %>');

            if (passwordBox.type === "password") {
                passwordBox.type = "text";
            }
            else {
                passwordBox.type = "password";
            }
        }

    </script>

</body>
</html>