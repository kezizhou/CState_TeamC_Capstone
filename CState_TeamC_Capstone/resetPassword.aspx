<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="resetPassword.aspx.cs" Inherits="CState_TeamC_Capstone.resetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <!-- Required meta tags -->
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <!-- Font Awesome Icons -->
    <script src="https://kit.fontawesome.com/65ffd49b86.js" crossorigin="anonymous"></script>

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous"/>
    
    <!-- Custom CSS -->
    <link rel="stylesheet" type="text/css" href="Content/Site.css" media="screen"/>
    <link rel="stylesheet" type="text/css" href="Content/resetPassword.css" media="screen"/>

    <title>Near Miss Reporting - Reset Password</title>
</head>

<body>
    <header>
        <div class="header">
            <img class="logo" src="Media/logo.png"/>
        </div>
    </header>

    <main role="main" class="container-fluid">

        <h2>Norwood Safety Near Miss Reporting</h2>
        <h5>Please set your new password.</h5>

        <div class="container center2">
            <form name="frmNewPassword" id="frmNewPassword" method="post" action="#" runat="server" onsubmit="return $('#frmNewPassword').valid()">
                <div class="form-group">
                    <label for="txtUsername" class="control-label">Username:</label>             
                    <input id="txtUsername" type="text" name="txtUsername" class="form-control populated" readonly="readonly" runat="server"/>
                </div>
                <div class="form-group" id="firstNameDiv">
                    <label for="txtPassword" class="control-label">New Password:</label>
                    <input id="txtPassword" name="txtPassword" class="form-control" type="password" required="required" runat="server"/>
                </div>

                <div class="form-group" id="lastNameDiv">
                    <label for="txtConfirmedPassword" class="control-label">Confirm New Password:</label>
                    <input id="txtConfirmedPassword" name="txtConfirmedPassword" class="form-control" type="password" required="required" runat="server"/>
                </div>

                <div class="container">
                    <button type="submit" id="btnResetPassword" class="btn btn-primary btn-sm center" onserverclick="btnResetPassword_Click" runat="server">
                        <i class="fas fa-sign-in-alt"></i> Reset Credentials
                    </button>
                </div>
                        
                <div class="center2">
                    <a href="~/signIn.aspx" runat="server">Return to Sign In</a>
                </div>
            </form>
        </div>
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
    <script src="Scripts/resetPassword.js"></script>
</body>

</html>
