﻿<%@ Master Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 
    1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server" >
    <title>Master page title</title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
           <tr>
               <td><asp:contentplaceholder id="Main" runat="server" /></td>
               <td><asp:contentplaceholder id="Footer" runat="server" /></td>
           </tr>
        </table>
    </form>
</body>
</html>