
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Doctors.aspx.cs" Inherits="Hospital_System.Doctors" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Doctors</h2>
    <asp:Label ID="lblMsg" runat="server"></asp:Label>

    <div class="form-group">
        <label>Full name</label>
        <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label>Specialization</label>
        <asp:TextBox ID="txtSpec" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label>Phone</label>
        <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label>Department</label>
        <asp:DropDownList ID="ddlDept" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>

    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
    <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-secondary" OnClick="btnClear_Click" />

    <hr />
    <asp:GridView ID="gvDoctors" runat="server" CssClass="table table-striped" GridLines="None"></asp:GridView>
</asp:Content>
