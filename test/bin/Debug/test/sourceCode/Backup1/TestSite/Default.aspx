<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestSite._Default" %>

<%@ Register assembly="Google" namespace="Google" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <cc1:GoogleMaps ID="GoogleMaps1" runat="server" Long="-115.814431" 
            Lat="37.242303" Zoom="4" Height="500px" Width="500px" />
    </div>
    </form>
</body>
</html>
