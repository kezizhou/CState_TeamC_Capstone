<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signIn.aspx.cs" Inherits="CState_TeamC_Capstone.signIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta charset="utf-8"/>
    <script src="http://cdnjs.cloudflare.com/ajax/libs/html5shiv/3.6/html5shiv.min.js"></script>
    <link rel="stylesheet" type="text/css" href="Content/Site.css" media="screen"/>
    <link rel="stylesheet" type="text/css" href="Content/signIn.css" media="screen"/>

    <title>Near Miss Reporting - Sign In</title>
</head>

<body>
    <header>
        <div class="header">
            <img class="logo" src="Media/logo.png"/>
        </div>
    </header>

    <main role="main" class="container-fluid">

        <form name="frmSignIn" method="get" action="#" runat="server">
            <h2>Norwood Safety Near Miss Reporting</h2>
            <h5>Please sign in.</h5>

            <div id="invalidInput" class="incompleteInput center">
                Incorrect username or password entered.
            </div>

            <table class="signInTable">
                <tr>
                    <td>
                        <label for="txtUsername">Username:</label>
                    </td>
                    <td>
                        <input id="txtUsername" type="text" name="txtUsername"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="txtPassword">Password:</label>
                    </td>
                    <td>
                        <input id="txtPassword" type="password" name="txtOperator"/>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <button type="button" id="btnSubmit" class="center" onclick="invalidCredentials()">Login</button>
                    </td>
                </tr>
            </table>

        </form>

    </main>

    <footer class="footer">
        <div class="container-fluid">
            Copyright © 2020 Cincinnati State Capstone Team C
        </div>
    </footer>

    <!-- JavaScript for Bootstrap -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js" integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous"></script>

</body>

</html>


<script>
    function invalidCredentials() {
        var x = document.getElementById("invalidInput");
        if (x.style.display === "none") {
            x.style.display = "block";
        } else {
            x.style.display = "none";
        }

        window.scrollTo(0, 0);
    }
</script>