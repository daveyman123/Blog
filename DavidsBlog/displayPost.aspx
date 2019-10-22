<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="displayPost.aspx.cs" Inherits="Blog.displayPost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div>  
        <h1>Display the posts.</h1>  
        <asp:DropDownList ID="drpPosts" runat="server"></asp:DropDownList><br />  
        <asp:Button ID="btnDisplay" runat="server" Text="Display Post" OnClick="btnDisplay_Click" />  
        <asp:FormView ID="frmPosts" runat="server">  
            <ItemTemplate>  
                <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("PostTitle") %>'></asp:Label><br />  
                <asp:Label ID="DatePosted" runat="server" Text='<%# Eval("DatePosted") %>'></asp:Label><br />  
                <asp:Label ID="lblAuth" runat="server" Text='<%# Eval("PostAuthor") %>'></asp:Label><br />  
                <asp:Label ID="lblCont" runat="server" Text='<%# Eval("PostContent") %>'></asp:Label><br />  
            </ItemTemplate>  
        </asp:FormView>  
    </div>  
    
    <div>  
        <h1>Comments</h1>  
        <div style="width:50%; float:left;">  
            <h3>Add a comment</h3>  
            <label>Name:</label><br />  
            <asp:TextBox ID="txtName" runat="server" TextMode="SingleLine"></asp:TextBox><br />  
            <label>Comment:</label>  
            <asp:TextBox ID="txtComm" runat="server" TextMode="MultiLine" Rows="10"></asp:TextBox> <br />  
            <asp:Button ID="btnAddComm" runat="server" Text="Add Comment!" OnClick="btnAddComm_Click" />  
        </div>  
        <div style="width:50%;float:left;">  
            <asp:Repeater ID="rptComments" runat="server">  
                <ItemTemplate>  
                    <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>  
                    <asp:Label ID="lblDateCom" runat="server" Text='<%# Eval("CommentDate") %>'></asp:Label>  
                    <br />  
                    <asp:Label ID="lblComm" runat="server" Text='<%# Eval("Comment") %>'></asp:Label>  
                    <hr />  
                </ItemTemplate>  
            </asp:Repeater>  
        </div>  
    </div>  

</asp:Content>
