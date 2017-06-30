<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Settings.ascx.cs" Inherits="FWS.Modules.SurveyBox.Settings" %>


<!-- uncomment the code below to start using the DNN Form pattern to create and update settings -->


<%@ Register TagName="label" TagPrefix="dnn" Src="~/controls/labelcontrol.ascx" %>
<style>
    .pnlBasicHelp{
        float:right;
        width:85vw;
        margin: 15px;
        padding:10px;
        background-color: aliceblue;
    }

</style>

	<h2 id="dnnSitePanel-BasicHelp" class="dnnFormSectionHead"><a href="" class="dnnSectionExpanded"><%=LocalizeString("BasicHelp")%></a></h2>
	<fieldset>
        <div class="dnnFormItem">
            <dnn:label  ID="lblBasicHelp" runat="server" />
            <asp:Panel ID="pnlBasicHelp" CssClass="pnlBasicHelp" runat="server"><%=LocalizeString("pnlBasicHelp") %></asp:Panel>

        </div>
    </fieldset>

	<h2 id="dnnSitePanel-BasicUserID" class="dnnFormSectionHead"><a href="" class="dnnSectionExpanded"><%=LocalizeString("BasicUserID")%></a></h2>
	<fieldset>
        <div class="dnnFormItem">
            <dnn:Label ID="lblUserID" runat="server" /> 
 
            <asp:TextBox ID="txtUserID" ReadOnly="true" runat="server" />
        </div>

          <div class="dnnFormItem">
            <dnn:label ID="lblUserIDDdl" runat="server" />
            <asp:DropDownList ID="ddlUsers" AutoPostBack="true" OnSelectedIndexChanged="ddlUsers_SelectedIndexChanged" runat="server"></asp:DropDownList>
        </div>
    </fieldset>


	<h2 id="dnnSitePanel-BasicSurveyID" class="dnnFormSectionHead"><a href="" class="dnnSectionExpanded"><%=LocalizeString("BasicSurveyID")%></a></h2>
	<fieldset>
        <div class="dnnFormItem">
            <dnn:Label ID="lblSurveyID" runat="server" /> 
 
            <asp:TextBox ID="txtSurveyID" ReadOnly="true" runat="server" />
        </div>

          <div class="dnnFormItem">
            <dnn:label ID="lblSurveyIDDdl" runat="server" />
            <asp:DropDownList ID="ddlSurveys" AutoPostBack="true" OnSelectedIndexChanged="ddlSurveys_SelectedIndexChanged" runat="server"></asp:DropDownList>
        </div>
    </fieldset>


