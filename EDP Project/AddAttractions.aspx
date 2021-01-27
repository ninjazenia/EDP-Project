<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddAttractions.aspx.cs" Inherits="EDP_Project.AddAttractions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div>
    <h3>Create Attraction</h3>
    <table style="width:100%;">
        <tr>
            <td class="auto-style1" style="width: 134px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1" style="width: 134px">ID</td>
            <td>
                <asp:TextBox ID="tbID" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_ID" runat="server" ControlToValidate="tbID" ErrorMessage="Please enter Attraction ID" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1" style="width: 134px">Name:</td>
            <td>
                <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
            </td>
             <td>
                <asp:RequiredFieldValidator ID="rfv_Name" runat="server" ControlToValidate="tbName" ErrorMessage="Please enter a name for the attraction" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1" style="width: 134px">Description</td>
            <td>
                <asp:TextBox ID="tbDescription" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1" style="width: 134px">Unit price:</td>
            <td>
                <asp:TextBox ID="tbunitprice" runat="server" TextMode="Number" Operator="DataTypeCheck" Type="Double"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td class="auto-style1" style="width: 134px">image:</td>
            <td class="auto-style4">
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="auto-style1" style="width: 134px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:Label ID="lbl_Result" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1" style="width: 134px">&nbsp;</td>
            <td>
                <asp:Button ID="btnAdd" runat="server"  OnClick="btnAdd_Click" Text="Add" Width="77px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style1" style="width: 134px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1" style="width: 134px">&nbsp;</td>
            <td>
                <asp:Label ID="lbMsg" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>

</div>
</asp:Content>
