<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="FWS.Modules.SurveyBox.View" %>

<%@ Register TagPrefix="vts" Namespace="Votations.NSurvey.WebControls" Assembly="Votations.NSurvey.WebControls" %>

    <!-- Bootstrap CSS see module.css import trail-->

 <div style="position: absolute; width: 650px; text-align: center; margin-left: 57px; top: 15px;">
 <asp:Label ID="MessageLabel" runat="server"  CssClass="ErrorMessage" Visible="False"></asp:Label>
                </div>

Current User: <% =GetUserId()%> &amp; <% =GetUserName()%> &amp; <% =GetUserEmail()%> 
<br /><br />
                            <asp:Label Width="45%" ID="ChooseSurveyLabel" AssociatedControlID="ddlSurveys" runat="server" Visible="false"></asp:Label>

                            <asp:DropDownList ID="ddlSurveys" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSurveys_SelectedIndexChanged1"
                                Visible="false">
                            </asp:DropDownList>

                    <div class="container panel panel-default" style="margin-top:15px;">

                <vts:SurveyBox ID="SurveyControl" CssClass="surveybox" Visible="false" EnableValidation="true" runat="server">
                    <QuestionStyle CssClass="questionStyle"></QuestionStyle>
                    <QuestionValidationMessageStyle CssClass="qvmStyle"></QuestionValidationMessageStyle>
                    <QuestionValidationMarkStyle CssClass="icon-warning-sign"></QuestionValidationMarkStyle>
                    <ConfirmationMessageStyle CssClass="cmStyle"></ConfirmationMessageStyle>
                    <SectionOptionStyle CssClass="soStyle"></SectionOptionStyle>
                    <ButtonStyle CssClass="btn btn-primary btn-xs bw"></ButtonStyle>
                    <AnswerStyle CssClass="answerStyle"></AnswerStyle>
                    <MatrixStyle CssClass="matrixStyle "></MatrixStyle>
                    <MatrixHeaderStyle CssClass="mhStyle"></MatrixHeaderStyle>
                    <MatrixItemStyle CssClass="miStyle"></MatrixItemStyle>
                    <MatrixAlternatingItemStyle CssClass="maiStyle"></MatrixAlternatingItemStyle>
                    <SectionGridAnswersItemStyle CssClass="sgiStyle"></SectionGridAnswersItemStyle>
                    <SectionGridAnswersAlternatingItemStyle CssClass="sgaaisStyle"></SectionGridAnswersAlternatingItemStyle>
                    <SectionGridAnswersStyle CssClass="sgaStyle"></SectionGridAnswersStyle>
                    <SectionGridAnswersHeaderStyle CssClass="sgahStyle"></SectionGridAnswersHeaderStyle>
                    <FootStyle CssClass="footStyle"></FootStyle>
                </vts:SurveyBox>

      </div>
