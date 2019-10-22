
<%@ Page Title="addPost" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addPost.aspx.cs" Inherits="Blog.addPost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>

<html>
<head>
    <title></title>
</head>
<body>
    
    <div>
        <h1>Add Post</h1>
        <label>Title</label>
        <asp:TextBox ID="txtTitle" runat="server" TextMode="SingleLine"></asp:TextBox><br />
        <label>Author</label>
        <asp:TextBox ID="txtAuth" runat="server" TextMode="SingleLine"></asp:TextBox><br />
        <label>Post Content</label>
        <asp:TextBox ID="txtCont" runat="server" TextMode="MultiLine"></asp:TextBox><br />
      
    </div>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="adsf"/>
        </p>

</body>
</html>

    </asp:Content>