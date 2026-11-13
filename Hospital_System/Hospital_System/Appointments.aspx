<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Appointments.aspx.cs" Inherits="Hospital_System.Appointments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Appointments</h2>
    <asp:Label ID="lblMsg" runat="server"></asp:Label>

    <div class="form-group">
        <label>Patient</label>
        <asp:DropDownList ID="ddlPatient" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>
    <div class="form-group">
        <label>Doctor</label>
        <asp:DropDownList ID="ddlDoctor" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>
    <div class="form-group">
        <label>Date (yyyy-mm-dd)</label>
        <asp:TextBox ID="txtDate" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label>Time (e.g. 09:30)</label>
        <asp:TextBox ID="txtTime" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label>Reason</label>
        <asp:TextBox ID="txtReason" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label>Status</label>
        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
            <asp:ListItem>Pending</asp:ListItem>
            <asp:ListItem>Done</asp:ListItem>
            <asp:ListItem>Cancelled</asp:ListItem>
        </asp:DropDownList>
    </div>

    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
    <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-secondary" OnClick="btnClear_Click" />

    <hr />
    <asp:GridView ID="gvAppointments" runat="server" CssClass="table table-striped" GridLines="None"></asp:GridView>
</asp:Content>
