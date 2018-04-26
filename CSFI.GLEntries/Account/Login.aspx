<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="CSFI.GLEntries.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login | CSFI GL Entries</title>
    <link rel="stylesheet" type="text/css" href="../../Content/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="../../Content/Styles.css" />
    <script type="text/javascript" src="../../Scripts/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="../../Scripts/bootstrap.min.js"></script>
    <%: System.Web.Optimization.Styles.Render("~/bundles/css-login") %>
</head>
<body>
    <form id="form1" runat="server">
        <br /><br /><br /><br />
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <div class="overlay" align="center">
                    <div class="overlay-image">
                        <img src="../../images/loader.gif" alt="Loading" />
                    </div>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="container body-content v-spacer-20">
                    <div class="row">
                        <div class="col-md-4 col-md-offset-4">                            
                            <div class="panel panel-primary">

                                <div class="panel-heading" align="center">
                                    <img src="../../images/logo-w256.png" />
                                    <br /><br />
                                    <h2 class="panel-title text-center">LOGIN</h2>
                                </div>

                                <div class="panel-body">
                                    <div class="row">

                                        <div class="col-md-10 col-md-offset-1">
                                            <div id="divSuccess" runat="server" class="alert alert-success alert-dismissable" visible="false" />
                                            <div id="divError" runat="server" class="alert alert-danger alert-dismissable" visible="false" />
                                        </div>
                                        
                                        <div class="col-md-10 col-md-offset-1 v-spacer-10">
                                            <asp:Label runat="server" AssociatedControlID="txtUsername" CssClass="control-label">Username</asp:Label>
                                            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>                                            
                                        </div>

                                        <div class="col-md-10 col-md-offset-1">
                                            <asp:Label runat="server" AssociatedControlID="txtPassword" CssClass="control-label">Password</asp:Label>
                                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvPassword"
                                                runat="server"
                                                ErrorMessage="Password is required."
                                                ControlToValidate="txtPassword"
                                                ValidationGroup="SignIn"
                                                EnableClientScript="true"
                                                SetFocusOnError="true"
                                                CssClass="text-danger" />
                                        </div>

                                        <div class="col-md-10 col-md-offset-1 v-spacer-30">
                                            <asp:Button ID="btnLogin" runat="server" Text="Login" ValidationGroup="SignIn" CssClass="btn btn-primary btn-block" OnClick="btnLogin_Click" />
                                        </div>

                                    </div>
                                </div>

                                <div class="panel-footer">
                                    <div class="row">
                                        <div class="col-md-10 col-md-offset-1 v-spacer-20 text-center">
                                            <h6>&copy; 2018 CSFI | Application Team - All Rights Reserved &reg;</h6>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    
    </form>
</body>
</html>


