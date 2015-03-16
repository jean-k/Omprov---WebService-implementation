<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Message.aspx.cs" Inherits="The_web_app.Message" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Arbetsprov</title>
</head>
<body>
    <form id="frmMessage" runat="server">
    <div>
    
        <br />
        <asp:GridView ID="grdViewMessages" runat="server" AllowSorting="True" AutoGenerateColumns="False" OnSorting="grdViewMessages_Sorting">
           <Columns>
               <asp:BoundField  DataField="Message" HeaderText="Meddelanden" SortExpression="Message"/>
               <asp:BoundField  DataField="Date" HeaderText="Datum" SortExpression="Date"/>
           </Columns>
        </asp:GridView>
      <br />
        <asp:Button runat="server" ID="btnGetMessages" Text="Hämta meddelanden" OnClick="btnGetMessages_Click"/>
    </div>
    </form>
</body>
</html>
