<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_002_TestProject.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <asp:Button ID="btnPostBack" runat="server" Text="PostBack" />
            <asp:PlaceHolder ID="phGrid" runat="server"></asp:PlaceHolder>
        </div>
    </form>
</body>
</html>
