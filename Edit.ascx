<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit.ascx.cs" Inherits="FWS.Modules.SurveyBox.Edit" %>


<br /><br />
<div style="margin:15px 25px 15px 25px;">
    <h5>SurveyBox Module Settings Information</h5> <br />

<u>Current DNN Userinfo</u><br /> 
    PortalID: <% =GetPortalId()%> <br />
    UserID: <% =GetUserId()%> <br />
    User Name: <% =GetUserName()%> <br />
    User Email:  <% =GetUserEmail()%> 
    <br /><br />
<u>Current SurveyProject info</u><br /> 
    SurveyID: <%=GetSurveyId() %><br />
    UserID: <%=GetSpUserId() %>
    </div>