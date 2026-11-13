<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Billing.aspx.cs" Inherits="Hospital_System.Billing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Billing</h2>
    <asp:Label ID="lblMsg" runat="server"></asp:Label>

    <div class="form-group">
        <label>Patient</label>
        <asp:DropDownList ID="ddlPatient" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>
    <div class="form-group">
        <label>Service</label>
        <asp:TextBox ID="txtService" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label>Amount</label>
        <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label>Paid</label>
        <asp:DropDownList ID="ddlPaid" runat="server" CssClass="form-control">
            <asp:ListItem>No</asp:ListItem>
            <asp:ListItem>Yes</asp:ListItem>
        </asp:DropDownList>
    </div>

    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
    <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-secondary" OnClick="btnClear_Click" />

    <hr />
    <h5>Total unpaid: <asp:Label ID="lblUnpaid" runat="server" Text="0"></asp:Label></h5>
    <asp:GridView ID="gvBilling" runat="server" CssClass="table table-striped" GridLines="None"></asp:GridView>
</asp:Content>
