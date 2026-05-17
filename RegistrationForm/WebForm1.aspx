<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebRegistration.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Form</title>

    <style>

        body {
            font-family: Arial;
            background-color: #f2f2f2;
        }

        .container {
            width: 450px;
            margin: 50px auto;
            padding: 25px;
            background-color: white;
            border-radius: 10px;
            box-shadow: 0px 0px 10px gray;
        }

        h2 {
            text-align: center;
            margin-bottom: 20px;
        }

        table {
            width: 100%;
        }

        td {
            padding: 10px;
        }

        .textbox {
            width: 100%;
            padding: 8px;
            border-radius: 5px;
            border: 1px solid #ccc;
        }

        .btn {
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            color: white;
            cursor: pointer;
        }

        .register-btn {
            background-color: green;
        }

        .reset-btn {
            background-color: red;
        }

    </style>

    <script>

        function validateForm() {

            var name =
                document.getElementById('<%= TextBox1.ClientID %>').value;

            var phone =
                document.getElementById('<%= TextBox3.ClientID %>').value;

            var email =
                document.getElementById('<%= TextBox4.ClientID %>').value;

            var username =
                document.getElementById('<%= TextBox5.ClientID %>').value;

            var password =
                document.getElementById('<%= TextBox6.ClientID %>').value;

            if (name == "") {
                alert("Enter Full Name");
                return false;
            }

            if (phone == "") {
                alert("Enter Phone Number");
                return false;
            }

            if (email == "") {
                alert("Enter Email");
                return false;
            }

            if (username == "") {
                alert("Enter Username");
                return false;
            }

            if (password == "") {
                alert("Enter Password");
                return false;
            }

            return true;
        }

    </script>

</head>

<body>

    <form id="form1" runat="server">

        <div class="container">

            <h2>Registration Form</h2>

            <table>

                <tr>
                    <td>Full Name</td>
                    <td>
                        <asp:TextBox ID="TextBox1"
                            runat="server"
                            CssClass="textbox">
                        </asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>Address</td>
                    <td>
                        <asp:TextBox ID="TextBox2"
                            runat="server"
                            TextMode="MultiLine"
                            CssClass="textbox">
                        </asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>Gender</td>
                    <td>

                        <asp:RadioButton ID="RadioButton1"
                            runat="server"
                            Text="Male"
                            GroupName="Gender" />

                        <asp:RadioButton ID="RadioButton2"
                            runat="server"
                            Text="Female"
                            GroupName="Gender" />

                    </td>
                </tr>

                <tr>
                    <td>Phone</td>
                    <td>
                        <asp:TextBox ID="TextBox3"
                            runat="server"
                            CssClass="textbox">
                        </asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>Email</td>
                    <td>
                        <asp:TextBox ID="TextBox4"
                            runat="server"
                            CssClass="textbox">
                        </asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>Username</td>
                    <td>
                        <asp:TextBox ID="TextBox5"
                            runat="server"
                            CssClass="textbox">
                        </asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>Password</td>
                    <td>
                        <asp:TextBox ID="TextBox6"
                            runat="server"
                            TextMode="Password"
                            CssClass="textbox">
                        </asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td colspan="2" align="center">

                        <asp:Button ID="Button1"
                            runat="server"
                            Text="Register"
                            CssClass="btn register-btn"
                            OnClick="Button1_Click"
                            OnClientClick="return validateForm();" />

                        <asp:Button ID="Button2"
                            runat="server"
                            Text="Reset"
                            CssClass="btn reset-btn"
                            OnClick="Button2_Click" />

                    </td>
                </tr>

            </table>

        </div>

    </form>

</body>
</html>