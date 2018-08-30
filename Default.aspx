<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="scraping3.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 629px;
            width: 1361px;
            margin-bottom: 5px;
        }
    </style>
</head>
<body style="height: 629px; width: 1358px; margin-left: 0px; margin-bottom: 3px">
    <form id="form1" runat="server">
    <div style="height: 629px; width: 1351px; margin-right: 0px; margin-left: 0px;">
        <asp:Label ID="Label6" runat="server" Text="Enter new height and width :" style="position:absolute; top: 321px; left: 46px; height: 25px; width: 403px; font-weight: 700;" Visible="False" ForeColor="White" Font-Size="Large"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" style="position:absolute; top: 362px; left: 319px;" Visible="False"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" Text="Do you want to resize image before downloading?"  style="position:absolute; top: 188px; left: 49px; width: 405px; height: 27px; font-weight: 700;" ForeColor="White" Font-Size="Large"></asp:Label>
        <asp:ListBox ID="ListBox1" runat="server" style="position:absolute; top: 254px; left: 742px; width: 372px; height: 232px;"></asp:ListBox>
    
        <asp:Button ID="Button1" runat="server" Text="Download" style="position:absolute; top: 508px; left: 1024px; width: 159px; right: 148px; height: 32px;" OnClick="Button1_Click" ForeColor="Black"/>
    
        <asp:Button ID="Button2" runat="server" Text="Stop" style="position:absolute; top: 586px; left: 904px; width: 150px; height: 30px; margin-bottom: 0px;" OnClick="Button2_Click" />
    
    
        <asp:Label ID="Label2" runat="server" Text="Select category and click download to download the news:"   style="position:absolute; top: 203px; left: 727px; width: 417px; height: 24px; font-weight: 700;" ForeColor="White" Font-Size="Large"></asp:Label>
    
        <asp:RadioButtonList ID="RadioButtonList1" runat="server"  style="position:absolute; top: 214px; left: 50px; width: 28px; height: 43px;" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" ForeColor="White">
            <asp:ListItem>Yes</asp:ListItem>
            <asp:ListItem>No</asp:ListItem>
        </asp:RadioButtonList>
    
        <asp:TextBox ID="TextBox1" runat="server" style="position:absolute; top: 361px; left: 103px; right: 688px;" Visible="False"></asp:TextBox>
    
        <asp:Label ID="Label4" runat="server" Text="Height" style="position:absolute; top: 365px; left: 49px; height: 19px; width: 51px;" Visible="False" ForeColor="White"></asp:Label>
        <asp:Label ID="Label5" runat="server" Text="Width" style="position:absolute; top: 364px; left: 278px; height: 23px; width: 41px; right: 780px;" Visible="False" ForeColor="White"></asp:Label>
    
        <asp:Label ID="Label7" runat="server" style="position:absolute; top: 39px; left: 357px; width: 556px;" Text=" News Downloader" Font-Size="50pt" ForeColor="White"></asp:Label>
    
        <asp:TextBox ID="TextBox3"  runat="server" style="position:absolute; top: 508px; left: 801px; width: 190px; height: 25px;"></asp:TextBox>
    
        <asp:Label ID="Label8" runat="server" Text="ENTER PATH:" style="position:absolute; top: 515px; left: 668px; width: 112px; height: 24px; font-weight: 700;" ForeColor="White"></asp:Label>
    
        <asp:Image ID="Image1" runat="server"
            style=" top: 15px; left: 10px; margin-top: 0px; margin-bottom: 0px; font-weight: 700; font-size: xx-large;" Height="630px" Width="1355px" ForeColor="White" ImageUrl="~/images/Abstract-Purple-Background-Wallpaper-HD-1152x720.jpg" />
    </div>
    </form>
</body>
</html>
