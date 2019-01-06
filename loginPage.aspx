<%@ Page Language="C#" AutoEventWireup="true" CodeFile="loginPage.aspx.cs" Inherits="LoginPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Login</title>
    <link href="App_Themes/Default/styleWithAsrafviCodeGeneratedPage.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="loginWrapper">
		<div style="margin:auto;width:333px;">
            <table>
                    <tr>
                    <td colspan="2">
                    <h1>IEB Employee Login</h1>
                    </td>
                    </tr>
                     <tr>
                    <td>
                    
                      User Name: </td><td> <asp:TextBox ID="txtLoginName" runat="server"></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td>
                    Password</td><td>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                
                </tr>
                <tr>
                <td></td>
                <td>
           
                <asp:Button ID="btnLogin" runat="server" Text="Log In" 
                     ValidationGroup="login"
                    onclick="btnLogin_OnClick"/>
            
                    </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                         <span class="fpassword">
                <span style="width:30px;padding-left:90px;"><asp:CheckBox ID="chkRememberme" Checked="true" Visible="false" runat="server" Text="Remember me"/></span>
                    <%--<br /><br />
            	<a href="#">Forgot your password?</a> | <a href="#">Sign Up</a>--%>
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </span>
            
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:RegularExpressionValidator id="RegularExpressionValidator1" 
                     ControlToValidate="txtLoginName"
                     ValidationExpression="[a-zA-Zs0-9]{1,40}$"
                     AutoPostBack="true"
                     ValidationGroup="login"
                     Display="Static"
                     ErrorMessage="Username must contain only Alpha-Numeric Characters"
                     EnableClientScript="False" 
                     runat="server"/>
                     <asp:RegularExpressionValidator id="RegularExpressionValidator2" 
                     ControlToValidate="txtPassword"
                     ValidationExpression="[a-zA-Zs0-9]{1,40}$"
                     ValidationGroup="login"
                     AutoPostBack="true"
                     Display="Static"
                     ErrorMessage="Password must contain only Alpha-Numeric Characters"
                     EnableClientScript="False" 
                     runat="server"/>
                        </td>
                    </tr>
            </table>
            
            
            <%--<div class="clear"></div>
        </div>
        <div class="loginbg">--%>
        
            
        </div><!-- END CLASS LOGINBG -->    
    
    </div><!-- END ID LOGINWRAPPER -->

    </form>
</body>
</html>
