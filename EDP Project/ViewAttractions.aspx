<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewAttractions.aspx.cs" Inherits="EDP_Project.ViewAttractions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <asp:GridView ID="gvAttractions" runat="server" AutoGenerateColumns="False" CellPadding="0" CssClass="myDatagrid" OnSelectedIndexChanged="gvProduct_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="_ID" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="_Name" HeaderText="Name" ReadOnly="True" />
                <asp:BoundField DataField="_Desc" HeaderText="Department" ReadOnly="True" />
                <asp:BoundField DataField="_unitPrice"  HeaderText="Unit Price" ReadOnly="True" />
                <asp:BoundField DataField="_Image" HeaderText="Image" ReadOnly="True" />

                <asp:CommandField ShowSelectButton="True" />
                <asp:ButtonField ButtonType="Button" CommandName="Buy"
                Text="Buy" />
                



            </Columns>
        </asp:GridView>
                <td>
                <asp:Button ID="btnAdd" runat="server"  OnClick="btnAdd_Click" Text="Add a new attraction to the list" Width="281px" />
            </td>
</asp:Content>
