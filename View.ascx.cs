/*
' Copyright (c) 2014  FryslanWebservices.com
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Localization;
using DotNetNuke.Entities.Users;
using Votations.NSurvey.WebControls;
using Votations.NSurvey.DataAccess;

using Votations.NSurvey.Constants;
using Votations.NSurvey.Data;
using Votations.NSurvey.WebAdmin.NSurveyAdmin;
using Votations.NSurvey.WebAdmin.UserControls;
using System.Web.UI.WebControls;
using Votations.NSurvey.WebAdmin;
using FWS.Modules.SurveyBox.Components;

namespace FWS.Modules.SurveyBox
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The View class displays the content
    /// 
    /// Typically your view control would be used to display content or functionality in your module.
    /// 
    /// View may be the only control you have in your project depending on the complexity of your module
    /// 
    /// Because the control inherits from SurveyBoxModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class View : SurveyBoxModuleBase, IActionable
    {

        protected SurveyLayoutData _userSettings;

        /// <summary>
        /// SurveyID as set in DNN module Settings
        /// </summary>
        /// <returns>id = SurveyID</returns>
        private int SurveyID()
        {
            object id = base.Settings["SurveyID"];
            if (id == null) return -1;
            return Convert.ToInt32(id);
        }

        protected Int64 GetSurveyId()
        {
            //string sp_surveyid = Convert.ToString(SurveyID());
            int sp_surveyid = SurveyID();
            return sp_surveyid;
        }

        /// <summary>
        /// UserID as set in DNN module Settings
        /// </summary>
        /// <returns>id = UserID</returns>
        private int UserID()
        {
            object id = base.Settings["UserID"];
            if (id == null) return 0;
            return Convert.ToInt32(id);
        }

        protected String GetSpUserId()
        {
            string sp_userid = Convert.ToString(UserID());
            return sp_userid;
        }


        protected override void OnInit(EventArgs e)
        {
            //Jquery CSS files
            Page.Header.Controls.Add(new LiteralControl(Environment.NewLine));

            //Jquery UI 1.11.4 css:
            HtmlGenericControl css = new HtmlGenericControl("link");
            css.Attributes.Add("rel", "stylesheet");
            css.Attributes.Add("type", "text/css");
            css.Attributes.Add("href", ResolveUrl("~/DesktopModules/SurveyBox/Content/themes/base/base.css"));
            Page.Header.Controls.Add(css);

            //jQuery(necessary for Bootstrap's JavaScript plugins) + answerfieldslideritem, answerfieldcalendar

            Page.Header.Controls.Add(new LiteralControl(Environment.NewLine));

            HtmlGenericControl javascriptControl = new HtmlGenericControl("script");

            //Commented out: conflicting with DNN older versions of Jquery:

            //javascriptControl.Attributes.Add("id", "jq311");
            //javascriptControl.Attributes.Add("src", ResolveUrl("~/DesktopModules/SurveyBox/Scripts/jquery-3.1.1.min.js"));
            //Page.Header.Controls.Add(javascriptControl);

            //Page.Header.Controls.Add(new LiteralControl(Environment.NewLine));

            //javascriptControl = new HtmlGenericControl("script");
            //javascriptControl.Attributes.Add("src", ResolveUrl("~/DesktopModules/SurveyBox/Scripts/jquery-ui-1.12.1.min.js"));
            //Page.Header.Controls.Add(javascriptControl);

            //Page.Header.Controls.Add(new LiteralControl(Environment.NewLine));

            javascriptControl = new HtmlGenericControl("script");
            javascriptControl.Attributes.Add("src", ResolveUrl("~/DesktopModules/SurveyBox/Scripts/jquery-ui-i18n.min.js"));
            Page.Header.Controls.Add(javascriptControl);

            Page.Header.Controls.Add(new LiteralControl(Environment.NewLine));

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                LocalizePage();

                if (!IsPostBack)
                {
                    //on initial pageload get SurveyId from DNN module settings; if null int 0 is returned;

                    SurveyControl.SurveyId = SurveyID();

                    ModuleSecurity ms = new ModuleSecurity(this.ModuleConfiguration);

                        if (ms.HasPermission2 && UserID() != 0)
                        {
                            ShowSurveyDDL();
                            SurveyControl.Visible = false;
                        }
                        else
                        {


                            if(SurveyID() >= 1)
                            {
                                SurveyControl.Visible = true;

                            Votations.NSurvey.SQLServerDAL.SurveyLayout u = new Votations.NSurvey.SQLServerDAL.SurveyLayout();

                            _userSettings = u.SurveyLayoutGet(SurveyControl.SurveyId);

                            if (!(_userSettings == null || _userSettings.SurveyLayout.Count == 0))
                            {
                                if (!string.IsNullOrEmpty(_userSettings.SurveyLayout[0].SurveyCss))
                                {
                                    defaultCSS.InnerHtml = "@import url(\"desktopmodules/surveybox/Css/" + SurveyControl.SurveyId.ToString() + "/" + _userSettings.SurveyLayout[0].SurveyCss + "\")";

                                }

                            }

                            }
                        else
                        {   //test:

                                SurveyControl.SurveyId = 0;
                                SurveyControl.Visible = false;
                        }

                    }             

                }

                //Votations.NSurvey.SQLServerDAL.SurveyLayout u = new Votations.NSurvey.SQLServerDAL.SurveyLayout();
                ////_userSettings = u.SurveyLayoutGet(((PageBase)Page).getSurveyId());
                ////test set surveyid to 1
                //_userSettings = u.SurveyLayoutGet(SurveyControl.SurveyId);

                //if (!(_userSettings == null || _userSettings.SurveyLayout.Count == 0))
                //{
                //    if (!string.IsNullOrEmpty(_userSettings.SurveyLayout[0].SurveyCss))
                //    {
                //        defaultCSS.InnerHtml = "@import url(\"desktopmodules/surveybox/Css/" + SurveyControl.SurveyId.ToString() + "/" + _userSettings.SurveyLayout[0].SurveyCss + "\")";

                //    }

                //}

                //Used if surveyid is taken from DNN module settings
                // should depend on module permissions
                //SurveyControl.SurveyId = SurveyID();
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException("A Friendly testmessage explaining things?!", this, exc, true);
            }

        }

        private void ShowSurveyDDL()
        {
            //show list of surveys from SP based on DNN Module setting UserID
            var surveys = new Surveys().GetAssignedSurveysList(Convert.ToInt32(Settings["UserID"]));

            if (surveys.Surveys.Count == 1) { InitiateSurvey(surveys.Surveys[0].SurveyId); return; }
            //if there are no surveys in SP connected to the UserID, get the SurveyID from DNN module settings; if null int 0 returned
            if (surveys.Surveys.Count == 0) { SurveyControl.SurveyId = Convert.ToInt32(Settings["SurveyID"]); return; }
            ddlSurveys.Items.Clear();
            ddlSurveys.Items.Add(new ListItem("Please Choose Survey", "-1"));
            ddlSurveys.AppendDataBoundItems = true;
            ddlSurveys.DataSource = surveys.Surveys;
            ddlSurveys.DataTextField = "Title";
            ddlSurveys.DataValueField = "SurveyId";
            ddlSurveys.DataBind();
            ddlSurveys.Visible = true;
            ChooseSurveyLabel.Visible = true;
        }

        protected void ddlSurveys_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (ddlSurveys.SelectedValue != "-1")
            {
                //((PageBase)Page).SurveyId = int.Parse(ddlSurveys.SelectedValue);
                //SurveyControl.SurveyId = int.Parse(ddlSurveys.SelectedValue);
                InitiateSurvey(int.Parse(ddlSurveys.SelectedValue));

            }

        }

        private void InitiateSurvey(int surveyId = -1)
        {
            if (surveyId > -1 || (ddlSurveys.Visible == true && ddlSurveys.SelectedValue != "-1"))
            {
                SurveyControl.SurveyId = surveyId > -1 ? surveyId : int.Parse(ddlSurveys.SelectedValue);

            }
            else return;

            ddlSurveys.Visible = false;
            ChooseSurveyLabel.Visible = false;

            // custom CSS:
            Votations.NSurvey.SQLServerDAL.SurveyLayout u = new Votations.NSurvey.SQLServerDAL.SurveyLayout();
            _userSettings = u.SurveyLayoutGet(SurveyControl.SurveyId);

            if (!(_userSettings == null || _userSettings.SurveyLayout.Count == 0))
            {
                if (!string.IsNullOrEmpty(_userSettings.SurveyLayout[0].SurveyCss))
                {

                    defaultCSS.InnerHtml = "@import url(\"desktopmodules/surveybox/Css/" + SurveyControl.SurveyId.ToString() + "/" + _userSettings.SurveyLayout[0].SurveyCss + "\")";

                }

            }


            SurveyControl.Visible = true;          

        }

        private void LocalizePage()
        {
            //TakeSurveyTitle.Text = GetPageResource("TakeSurveyTitle");
            ChooseSurveyLabel.Text = "Choose a Survey";

        }


        protected void Page_PreRender(object sender, EventArgs e)
        {
            Session["DnnPortalIdSessionValue"] = GetPortalId();
            Session["DnnUserIdSessionValue"] = GetUserId();
            Session["DnnUserNameSessionValue"] = GetUserName();
            Session["DnnUserEmailSessionValue"] = GetUserEmail();

            //Session["SpSurveyIdSessionValue"] = GetSurveyId();
            //Session["SpUserIdSessionValue"] = GetSpUserId();

            //Default session timeout = after 20 min. of inactivity session will terminate;

        }

        public UserInfo _currentUser =
                           //DotNetNuke.Entities.Users.UserController.GetCurrentUserInfo();
                           DotNetNuke.Entities.Users.UserController.Instance.GetCurrentUserInfo();

        protected String GetPortalId()
        {
            int PortalID = _currentUser.PortalID;
            return PortalID.ToString();
        }

        protected String GetUserId()
        {
            int UserID = _currentUser.UserID;
            return UserID.ToString();
        }

        protected String GetUserName()
        {
            string Username = _currentUser.Username;
            return Username;
        }

        protected String GetUserEmail()
        {
            string UserEmail = _currentUser.Email;
            return UserEmail;
        }

        public ModuleActionCollection ModuleActions
        {
            get
            {
                var actions = new ModuleActionCollection
                    {
                        {
                            GetNextActionID(), Localization.GetString("EditModule", LocalResourceFile), "", "", "",
                            EditUrl(), false, SecurityAccessLevel.Edit, true, false
                        }
                    };
                return actions;
            }
        }
    }
}