<%@ Page Language="C#" MasterPageFile="~/Login/AdminMaster.master" AutoEventWireup="true"
    CodeFile="AdminInv_IssueDetailDisplay.aspx.cs" Inherits="AdminInv_IssueDetailDisplay" Title="Display Inv_IssueDetail By Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .gridCss
        {
            width: 100%;
            padding: 20px 10px 10px 10px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
        <asp:GridView ID="gvInv_IssueDetail" runat="server" AutoGenerateColumns="false" CssClass="gridCss">
            <Columns>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbSelect" runat="server" CommandArgument='<%#Eval("Inv_IssueDetailID") %>' OnClick="lbSelect_Click">
                            Select
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ItemID">
                    <ItemTemplate>
                        <asp:Label ID="lblItemID" runat="server" Text='<%#Eval("ItemID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("Quantity") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ApproximateQuantity">
                    <ItemTemplate>
                        <asp:Label ID="lblApproximateQuantity" runat="server" Text='<%#Eval("ApproximateQuantity") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ProductID">
                    <ItemTemplate>
                        <asp:Label ID="lblProductID" runat="server" Text='<%#Eval("ProductID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AdditionalWithIssueDetailID">
                    <ItemTemplate>
                        <asp:Label ID="lblAdditionalWithIssueDetailID" runat="server" Text='<%#Eval("AdditionalWithIssueDetailID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField1">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField1" runat="server" Text='<%#Eval("ExtraField1") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField2">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField2" runat="server" Text='<%#Eval("ExtraField2") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField3">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField3" runat="server" Text='<%#Eval("ExtraField3") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField4">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField4" runat="server" Text='<%#Eval("ExtraField4") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ExtraField5">
                    <ItemTemplate>
                        <asp:Label ID="lblExtraField5" runat="server" Text='<%#Eval("ExtraField5") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AddedBy">
                    <ItemTemplate>
                        <asp:Label ID="lblAddedBy" runat="server" Text='<%#Eval("AddedBy") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AddedDate">
                    <ItemTemplate>
                        <asp:Label ID="lblAddedDate" runat="server" Text='<%#Eval("AddedDate") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="UpdatedBy">
                    <ItemTemplate>
                        <asp:Label ID="lblUpdatedBy" runat="server" Text='<%#Eval("UpdatedBy") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="UpdatedDate">
                    <ItemTemplate>
                        <asp:Label ID="lblUpdatedDate" runat="server" Text='<%#Eval("UpdatedDate") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="RowStatusID">
                    <ItemTemplate>
                        <asp:Label ID="lblRowStatusID" runat="server" Text='<%#Eval("RowStatusID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("Inv_IssueDetailID") %>' OnClick="lbDelete_Click">
                            Delete
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
