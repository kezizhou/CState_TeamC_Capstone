<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signIn.aspx.cs" Inherits="CState_TeamC_Capstone.signIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <!-- Required meta tags -->
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous"/>
    
    <!-- Custom CSS -->
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

        <form name="frmSignIn" id="frmSignIn" method="post" action="#" runat="server">
            <h2>Norwood Safety Near Miss Reporting</h2>
            <h5>Please sign in.</h5>

            <div class="incompleteInput" id="incompleteWrapper">
                <span>Please correct the following:</span>
                <ul id="incompleteInput">
                    <!-- Validation message from Jquery goes here -->
                </ul>
            </div>

            <table class="signInTable">
                <tr>
                    <td>
                        <label for="txtUsername">Username:</label>
                    </td>
                    <td>
                        <input id="txtUsername" type="text" name="txtUsername" required="required"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="txtPassword">Password:</label>
                    </td>
                    <td>
                        <input id="txtPassword" type="password" name="txtPassword" required="required"/>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <button type="submit" id="btnSubmit" class="btn btn-primary btn-sm center">Login</button>
                    </td>
                </tr>
                <tr>
                    <td colspan="2"  id="forgotCredentials" class="text-center">
                        <a href="#">Forgot Username or Password?</a>
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

    <!-- Validation JQuery -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.19.2/jquery.validate.min.js"></script>
    <script src="Scripts/signIn.js"></script>

</body>

</html>


<script>
    function invalidCredentials() {
        document.getElementById("incompleteInput").style.display = "block";
    }
</script>