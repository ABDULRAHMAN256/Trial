<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Patients.aspx.cs" Inherits="Hospital_System.Patients" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Patients</h2>
    <asp:Label ID="lblMsg" runat="server"></asp:Label>

    <div class="form-group">
        <label>Full name</label>
        <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label>Gender</label>
        <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control">
            <asp:ListItem>Male</asp:ListItem>
            <asp:ListItem>Female</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="form-group">
        <label>Date of birth (yyyy-mm-dd)</label>
        <asp:TextBox ID="txtDob" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label>Phone</label>
        <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label>Address</label>
        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label>Next of kin</label>
        <asp:TextBox ID="txtKin" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
    <asp:Button ID="btnSearch" runat="server" Text="Search by phone" CssClass="btn btn-info" OnClick="btnSearch_Click" />
    <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-secondary" OnClick="btnClear_Click" />

    <hr />
    <asp:GridView ID="gvPatients" runat="server" CssClass="table table-striped" GridLines="None"></asp:GridView>
</asp:Content>
