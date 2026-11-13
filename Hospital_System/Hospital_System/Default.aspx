<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Hospital_System.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Dashboard</h2>
    <asp:Button ID="btnTest" runat="server" Text="Test Connection" CssClass="btn btn-primary" OnClick="btnTest_Click" />
    <br /><br />
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
</asp:Content>