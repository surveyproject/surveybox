<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit.ascx.cs" Inherits="FWS.Modules.SurveyBox.Edit" %>

<!-- button to add additional SurveyBox Permission options to the DNN permissionstable-->
<asp:Button ID="secBtn" OnClick="button_Click" CssClass="btn-primary" Width="150" Text="Security" runat="server"/>
<br /><br />
<!-- Test label made visible throught the Surveybox DNN permission settings -->
<asp:label id="secTestLabel" Visible="False" Text="My Secret Message" runat="server"></asp:label>
<br /><br />

