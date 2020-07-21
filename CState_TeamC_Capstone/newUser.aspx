<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newUser.aspx.cs" Inherits="CState_TeamC_Capstone.newUser" %>

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
    <link rel="stylesheet" type="text/css" href="Content/newUser.css" media="screen"/>

    <title>Near Miss Reporting - New User</title>
</head>

<body>
    <header>
        <div class="header">
            <img class="logo" src="Media/logo.png"/>
        </div>
    </header>

    <main role="main" class="container-fluid">

        <h2>Norwood Safety Near Miss Reporting</h2>
 
        <div class="container center2">
            <form name="frmNewUser" id="frmNewUser" method="post" action="#" onsubmit="return $('#frmNewUser').valid()" runat="server">
                <fieldset class="form-group">
                </fieldset>

                <div class="form-group" id="firstNameDiv">
                    <label for="txtFirstName" class="control-label">First Name:</label>
                    <input id="txtFirstName" name="txtFirstName" class="form-control" type="text" required="required"/>
                </div>

                <div class="form-group" id="middleNameDiv">
                    <label for="txtMiddleName" class="control-label">Middle Name:</label>
                    <input id="txtMiddleName" name="txtMiddleName" class="form-control" type="text" required="required"/>
                </div>

                <div class="form-group" id="lastNameDiv">
                    <label for="txtLastName" class="control-label">Last Name:</label>
                    <input id="txtLastName" name="txtLastName" class="form-control" type="text" required="required"/>
                </div>
                
                <div class="form-group" id="employeeIDDiv">
                    <label for="txtemployeeID" class="control-label">Employee ID (6-digit):</label>
                    <input id="txtemployeeID" name="txtemployeeID" class="form-control" type="text" required="required"/>
                </div>

                <div class="form-group" id="emailDiv">
                    <label for="txtEmail" class="control-label">Email:</label>
                    <input id="txtEmail" name="txtEmail" class="form-control" type="text" required="required"/>
                </div>

                <div class="form-group" id="departmentDiv">
                    <label for="sltDepartment" class="control-label">Department:</label>
                    <select id="sltDepartment" name="sltDepartment" class="required form-control">
                        <option value="" selected="selected" disabled="disabled" hidden="hidden">Select Production Area</option>
                        <option value="value">These will be populated from database</option>
                    </select>
                </div>

                <div class="form-group" id="usernameDiv">
                    <label for="txtUsername" class="control-label">Username:</label>
                    <input id="txtUsername" name="txtUsername" class="form-control" type="text" required="required"/>
                </div>

                <div class="form-group" id="passwordDiv">
                    <label for="txtPassword" class="control-label">Password:</label>
                    <input id="txtPassword" name="txtPassword" class="form-control" type="password" required="required"/>
                </div>

                <div class="container">
                    <button type="submit" id="btnSubmitNewUser" class="btn btn-primary btn-sm center"  runat="server">
                        <i class="fas fa-sign-in-alt"></i> Submit New User
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
    <script src="Scripts/newUser.js"></script>
</body>

</html>
