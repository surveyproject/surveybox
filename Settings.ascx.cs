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
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;

using Votations.NSurvey.Constants;
using Votations.NSurvey.Data;
using Votations.NSurvey.UserProvider;
using Votations.NSurvey.DataAccess;
using Votations.NSurvey.WebAdmin.NSurveyAdmin;
using Votations.NSurvey.WebAdmin.UserControls;
using Votations.NSurvey.WebControls;

using System.Web.UI.WebControls;

namespace FWS.Modules.SurveyBox
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The Settings class manages Module Settings
    /// 
    /// Typically your settings control would be used to manage settings for your module.
    /// There are two types of settings, ModuleSettings, and TabModuleSettings.
    /// 
    /// ModuleSettings apply to all "copies" of a module on a site, no matter which page the module is on. 
    /// 
    /// TabModuleSettings apply only to the current module on the current page, if you copy that module to
    /// another page the settings are not transferred.
    /// 
    /// If you happen to save both TabModuleSettings and ModuleSettings, TabModuleSettings overrides ModuleSettings.
    /// 
    /// Below we have some examples of how to access these settings but you will need to uncomment to use.
    /// 
    /// Because the control inherits from SurveyBoxSettingsBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class Settings : SurveyBoxModuleSettingsBase
    {
        #region Base Method Implementations

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// LoadSettings loads the Module settings from the Database and displays them
        /// </summary>
        /// -----------------------------------------------------------------------------
        public override void LoadSettings()
        {
            Votations.NSurvey.SQLServerDAL.User UsersData;

            try
            {
                if (Page.IsPostBack == false)
                {

                    UsersData = new Votations.NSurvey.SQLServerDAL.User();

                    //Check for existing settings and use those on this page
                    //Settings["SettingName"]

                    /* uncomment to load saved settings in the text boxes */

                    //surveyid:
                    if (Settings.Contains("SurveyID"))
                        txtSurveyID.Text = Settings["SurveyID"].ToString();
			
                    //UserId
                    if (Settings.Contains("UserID"))
                        txtUserID.Text = Settings["UserID"].ToString();


                    ShowSurveyDDL();
                    ShowUserDDL();


                }
                if (Settings.Contains("SurveyID"))
                    txtSurveyID.Text = Settings["SurveyID"].ToString();

                //UserId
                if (Settings.Contains("UserID"))
                    txtUserID.Text = Settings["UserID"].ToString();



            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// UpdateSettings saves the modified settings to the Database
        /// </summary>
        /// -----------------------------------------------------------------------------
        public override void UpdateSettings()
        {
            try
            {
                var modules = new ModuleController();

                //the following are two sample Module Settings, using the text boxes that are commented out in the ASCX file.
                //module settings

                if (ddlSurveys.SelectedValue != "-1")
                {
                    modules.UpdateModuleSetting(ModuleId, "SurveyID", ddlSurveys.SelectedValue);
                }

                if (ddlUsers.SelectedValue != "-1")
                {
                    modules.UpdateModuleSetting(ModuleId, "UserID", ddlUsers.SelectedValue);
                }

                //tab module settings
                if (ddlSurveys.SelectedValue != "-1")
                {
                    modules.UpdateTabModuleSetting(TabModuleId, "SurveyID", ddlSurveys.SelectedValue);
                }

                if (ddlUsers.SelectedValue != "-1")
                {
                        modules.UpdateTabModuleSetting(TabModuleId, "UserID", ddlUsers.SelectedValue);
                }
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        private void ShowSurveyDDL()
        {
            var surveys = new Surveys().GetAssignedSurveysList(1);

            ddlSurveys.Items.Clear();
            ddlSurveys.Items.Add(new ListItem("Please Select a Survey", "-1"));
            ddlSurveys.AppendDataBoundItems = true;
            ddlSurveys.DataSource = surveys.Surveys;
            ddlSurveys.DataTextField = "Title";
            ddlSurveys.DataValueField = "SurveyId";
            ddlSurveys.DataBind();
            ddlSurveys.Visible = true;

        }

        protected void ddlSurveys_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSurveys.SelectedValue != "-1")
            {
                txtSurveyID.Text = ddlSurveys.SelectedValue;

            }

        }



        private void ShowUserDDL()
        {
            var users = new Users().GetAllUsersList();

            ddlUsers.Items.Clear();
            ddlUsers.Items.Add(new ListItem("Please Select a User", "-1"));
            ddlUsers.AppendDataBoundItems = true;
            ddlUsers.DataSource = users.Users;
            ddlUsers.DataTextField = "UserName";
            ddlUsers.DataValueField = "UserId";
            ddlUsers.DataBind();
            ddlUsers.Visible = true;

        }

        protected void ddlUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsers.SelectedValue != "-1")
            {
                txtUserID.Text = ddlUsers.SelectedValue;

            }

        }

        #endregion
    }
}