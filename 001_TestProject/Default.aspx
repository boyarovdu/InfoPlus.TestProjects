<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_001_TestProject.Default" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <telerik:RadGrid runat="server" ID="CommonGrid"
                AllowPaging="true"
                AllowSorting="true"
                AllowFilteringByColumn="true"
                AllowAutomaticInserts="True"
                AllowAutomaticUpdates="true"
                AllowAutomaticDeletes="true"
                AutoGenerateColumns="false"
                EnableLinqExpressions="false"
                GridLines="None">
                <%--OnItemCreated="CommonGrid_ItemCreated">--%>
                <ItemStyle Height="28px" />
                <AlternatingItemStyle Height="28px" />
                <EditItemStyle Height="80px" />
                <PagerStyle AlwaysVisible="true" />
                <MasterTableView DataKeyNames="Counter"
                    AllowFilteringByColumn="True"
                    EnableViewState="False"
                    EnableColumnsViewState="True"
                    CommandItemDisplay="Top"
                    ClientDataKeyNames="Counter"
                    InsertItemDisplay="Top"
                    InsertItemPageIndexAction="ShowItemOnFirstPage"
                    Width="100%"
                    RowIndicatorColumn-Reorderable="False">
                    <RowIndicatorColumn Visible="True" />
                    <FilterItemStyle BorderColor="#CC99FF" Font-Bold="True" />
                    <%--<CommandItemTemplate>
                        <asp:Panel ID="btnOpenHeaderContextMenu" runat="server" CssClass="CommandItemTemplateDiv" Visible="true" onclick="OpenHeaderContextMenu(event);">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Grid/SelectionFieldsToView.png" />
                        </asp:Panel>
                        <asp:Panel ID="btnNewItem" runat="server" CssClass="CommandItemTemplateDiv" Visible="true" onclick="CreateNewItem();">
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Grid/AddRecord.gif" />
                            <asp:Literal ID="litNewRecord" runat="server" Text="New record" />
                        </asp:Panel>
                        <asp:Panel ID="btnOpenTheFirst" runat="server" CssClass="CommandItemTemplateDiv" Visible="true" onclick="OpenTheFirst();">
                            <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/Grid/open.png" />
                            <asp:Literal ID="litOpenTheFirst" runat="server" Text="OpenTheFirst" />
                        </asp:Panel>
                        <asp:Panel ID="btnOtherItem" runat="server" CssClass="CommandItemTemplateDiv" Visible="true" />
                        <asp:Panel ID="btnShowAll" runat="server" CssClass="CommandItemTemplateDiv" Visible="true" onclick="IsFilter('SetFilterStateForControlTab');">
                            <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/Grid/Filter.gif" />
                            <asp:Label ID="btnShowAll2" runat="server" Text="AskodGridButton_ShowAll"></asp:Label>
                        </asp:Panel>
                        <asp:Panel ID="btnAddAdresses" runat="server" CssClass="CommandItemTemplateDiv" Visible="true" onclick="AddAdresses();">
                            <asp:Image ID="Image5" runat="server" ImageUrl="~/Images/Grid/Users.gif" />
                            <asp:Literal ID="Literal1" runat="server" Text="ChartsOfEstablishments" />
                        </asp:Panel>
                        <asp:Panel ID="btnFilter" runat="server" CssClass="CommandItemTemplateDiv" Visible="true" onclick="showFilter();">
                            <asp:Image ID="Image6" runat="server" ImageUrl="~/Images/Grid/Filter.gif" />
                            <asp:Literal ID="litFilters" runat="server" Text="Filters" />
                        </asp:Panel>
                        <asp:Panel ID="clearFilter" runat="server" CssClass="CommandItemTemplateDiv" Visible="true" onclick="ClearHeaderFilter();">
                            <asp:Image ID="Image7" runat="server" ImageUrl="~/Images/Grid/ClearFilter.gif" />
                            <asp:Literal ID="Literal2" runat="server" Text="uplClear" />
                        </asp:Panel>
                        <asp:Panel ID="btnSearchConstructor" runat="server" CssClass="CommandItemTemplateDiv" Visible="true" onclick="showSearchConstructor('static');">
                            <asp:Image ID="Image8" runat="server" ImageUrl="~/Images/Grid/FilterConstructor.gif" />
                            <asp:Literal ID="Literal3" runat="server" Text="SearchConstructor" />
                        </asp:Panel>
                        <asp:Panel ID="btnReport" runat="server" CssClass="CommandItemTemplateDiv" Visible="true" onclick="CreateReport();">
                            <asp:Image ID="Image9" runat="server" ImageUrl="~/Images/Grid/Word.gif" />
                        </asp:Panel>
                        <asp:Panel ID="btnDeleteGroupOfCards" runat="server" CssClass="CommandItemTemplateDiv" Visible="true" onclick="DeleteGroupOfCards();">
                            <asp:Image ID="Image10" runat="server" ImageUrl="~/Images/Grid/Delete.gif" />
                            <asp:Literal ID="litDeleteGroup" runat="server" Text="DeleteCheckedItemsTitle" />
                        </asp:Panel>
                        <asp:Panel ID="btnQuickFilter" runat="server" CssClass="CommandItemTemplateDiv" Visible="true" />
                        <asp:Panel ID="groupRadioControl" runat="server" CssClass="CommandItemTemplateDiv" Visible="true">
                        </asp:Panel>
                        <asp:Panel ID="regCardFilter" runat="server" CssClass="CommandItemTemplateDiv" Visible="true">
                            <span class="CommandRegDateItem">
                                <asp:Literal ID="Literal4" runat="server" Text="DateReg" />
                                <asp:Literal ID="Literal5" runat="server" Text="lblFrom" />
                            </span>
                            <span style="width: 100px; float: left;">
                                <telerik:RadDatePicker ID="regDateFrom" runat="server" ShowPopupOnFocus="true" Width="100px">
                                    <DateInput DisplayDateFormat="dd.MM.yyyy" DateFormat="dd.MM.yyyy" CausesValidation="false"></DateInput>
                                </telerik:RadDatePicker>
                            </span>
                            <span class="CommandRegDateItem">
                                <asp:Literal ID="Literal6" runat="server" Text="lblTill" />
                            </span>
                            <span style="width: 100px; float: left;">
                                <telerik:RadDatePicker ID="regDateTill" runat="server" ShowPopupOnFocus="true" Width="100px">
                                    <DateInput DisplayDateFormat="dd.MM.yyyy" DateFormat="dd.MM.yyyy" CausesValidation="false"></DateInput>
                                </telerik:RadDatePicker>
                            </span>
                            <img id="img1" alt="" class="imgFilter" style="cursor: pointer;" src="Images/Grid/Filter.gif" onclick="ApplyRegDateFilter();" />
                            <img id="img2" alt="" class="imgCancel" style="cursor: pointer;" src="Images/Grid/CancelFilter.gif" onclick="CancelRegDateFilter(true);" />
                        </asp:Panel>
                        <asp:Panel ID="groupRadioMyRoom" runat="server" CssClass="CommandItemTemplateDiv" Visible="true" />
                        <asp:Panel ID="AcceptedDeclineButtons" runat="server" CssClass="CommandItemTemplateDiv" Visible="true">
                            <asp:Panel ID="AcceptedButton" runat="server" Visible="true" CssClass="acceptedDeclinedButtons">
                                <asp:RadioButton ID="RadioButton1" runat="server" GroupName="AcceptedNotAcceptedButtons" Text="btnAcceptedReceipt" onclick="AcceptedButton_Click(this);" />
                            </asp:Panel>
                            <asp:Panel ID="NotAcceptedButton" runat="server" Visible="true" CssClass="acceptedDeclinedButtons" Style="margin-left: 5px;">
                                <asp:RadioButton ID="RadioButton2" runat="server" GroupName="AcceptedNotAcceptedButtons" Text="btnNotAcceptedReceipt" onclick="NotAcceptedButton_Click(this);" />
                            </asp:Panel>
                            <asp:Panel ID="AllReceiptsButton" runat="server" Visible="true" CssClass="acceptedDeclinedButtons" Style="margin-left: 5px;">
                                <asp:RadioButton ID="RadioButton3" runat="server" GroupName="AcceptedNotAcceptedButtons" Checked="true" Text="btnAllReceipts" onclick="AllReceiptsButton_Click(this);" />
                            </asp:Panel>
                        </asp:Panel>
                        <asp:Panel ID="AcceptButton" runat="server" CssClass="CommandItemTemplateDiv" Visible="true" onclick="HandleSelectedArrivalRks(true);">
                            <asp:Image ID="Image11" runat="server" ImageUrl="~/Images/Grid/Accept.png" />
                            <asp:Literal ID="Literal7" runat="server" Text="btnAcceptReceipt" />
                        </asp:Panel>
                        <asp:Panel ID="DeclineButton" runat="server" CssClass="CommandItemTemplateDiv" Visible="true" onclick="HandleSelectedArrivalRks(false);">
                            <asp:Image ID="Image12" runat="server" ImageUrl="~/Images/Grid/Decline.png" />
                            <asp:Literal ID="Literal8" runat="server" Text="btnReturnReceipt" />
                        </asp:Panel>
                        <asp:Panel ID="ToNoteAsViewedButton" runat="server" CssClass="CommandItemTemplateDiv" Visible="true" onclick="HandleNoteAsViewedButton();">
                            <asp:Image ID="Image13" runat="server" ImageUrl="~/Images/Grid/Accept.png" />
                            <asp:Literal ID="Literal9" runat="server" Text="MarkAsViewed" />
                        </asp:Panel>
                        <asp:Panel ID="pnlReceiveEmail" runat="server" CssClass="CommandItemTemplateDiv" Visible="true" onclick="HandleReceiveEmail();">
                            <asp:Image ID="Image14" runat="server" ImageUrl="~/Images/Grid/Accept.png" />
                            <asp:Literal ID="Literal10" runat="server" Text="btnAcceptReceipt" />
                        </asp:Panel>
                        <asp:Panel ID="ShowActualPanel" runat="server" CssClass="CommandItemTemplateDiv VerticalMiddle" Visible="true">
                            <div>
                                <asp:CheckBox ID="ShowActualCheckBox" runat="server" onclick="ShowActualNomenclature.ShowActualNomenclCheckBoxHandler();" />
                                <div onclick="ShowActualNomenclature.ShowActualNomenclDivHandler();" style="display: inline;">
                                    <asp:Label ID="Label1" runat="server" Text="AskodGridButton_ShowActual" />
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="DuplicatePanel" runat="server" CssClass="CommandItemTemplateDiv VerticalMiddle" Visible="true" onclick="DuplicateItem();">
                            <asp:Image ID="Image15" runat="server" ImageUrl="~/Images/Grid/Duplicate.png" />
                            <asp:Literal ID="Literal11" runat="server" Text="btnDuplicate" />
                        </asp:Panel>
                        <asp:Panel ID="AddStatusPanel" runat="server" CssClass="CommandItemTemplateDiv" Visible="true" onclick="AddStatus();">
                            <asp:Image ID="AddStatusImg" runat="server" ImageUrl="~/Images/Grid/addStatus.png" />
                            <asp:Literal ID="AddStatusLiteral" runat="server" Text="AddStatus" />
                        </asp:Panel>
                        <asp:Panel ID="RemoveStatusPanel" runat="server" CssClass="CommandItemTemplateDiv" Visible="true" onclick="RemoveStatus();">
                            <asp:Image ID="Image16" runat="server" ImageUrl="~/Images/Grid/removeStatus.png" />
                            <asp:Literal ID="Literal12" runat="server" Text="RemoveStatus" />
                        </asp:Panel>
                    </CommandItemTemplate>--%>
                </MasterTableView>
                <GroupingSettings CaseSensitive="False" />
                <ClientSettings EnableRowHoverStyle="true" AllowColumnHide="true" ColumnsReorderMethod="Reorder" AllowColumnsReorder="true" ReorderColumnsOnClient="true">
                    <Selecting AllowRowSelect="true" EnableDragToSelectRows="false" />
<%--                    <ClientEvents
                        OnDataBound="OnGridDataBound"
                        OnDataBindingFailed="CommonGrid_DataBindingFailed"
                        OnCommand="RaiseCommand"
                        OnDataBinding="CommonGrid_DataBinding"
                        OnRowDataBound="CommonGrid_RowBound"
                        OnRowMouseOut="OnRowMouseOutForAskodGrid"
                        OnRowMouseOver="OnRowMouseOverForAskodGrid"
                        OnRowContextMenu="OnRowContextMenuForAskodGrid"
                        OnFilterMenuShowing="filterMenuShowing"
                        OnMasterTableViewCreated="MasterTableViewCreated"
                        OnColumnSwapping="OnColumnSwapping"
                        OnColumnResizing="OnColumnResizing"
                        OnColumnResized="OnColumnResized"
                        OnColumnMovingToLeft="OnColumnMovingToLeft"
                        OnColumnMovedToLeft="OnColumnMovedToLeft"
                        OnColumnMovingToRight="OnColumnMovingToRight"
                        OnColumnMovedToRight="OnColumnMovedToRight"
                        OnGridCreated="GridCreated"
                        OnDataSourceResolved="OnDataSourceResolved" />--%>
                    <DataBinding ResponseType="JSON" SelectMethod="GetData" SortParameterType="List" FilterParameterType="List" EnableCaching="false" />
                    <Scrolling AllowScroll="True" UseStaticHeaders="true" SaveScrollPosition="true" />
                </ClientSettings>
               <%-- <FilterMenu OnClientShown="MenuShowing" OnClientItemClicking="CommonGrid_FilterMenu_ItemClicking" />--%>
                <FilterItemStyle Font-Bold="False" />
            </telerik:RadGrid>

        </div>
    </form>
</body>
</html>
