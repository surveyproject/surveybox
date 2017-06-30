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
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Users;
using System.Web.UI.WebControls;

using Votations.NSurvey.DataAccess;
using Votations.NSurvey.Data;
using Votations.NSurvey.WebAdmin.UserControls;

using FWS.Modules.SurveyBox.Components;

namespace FWS.Modules.SurveyBox
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The EditSurveyBox class is used to manage content
    /// 
    /// Typically your edit control would be used to create new content, or edit existing content within your module.
    /// The ControlKey for this control is "Edit", and is defined in the manifest (.dnn) file.
    /// 
    /// Because the control inherits from SurveyBoxModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class Edit : SurveyBoxModuleBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ModuleSecurity ms = new ModuleSecurity(this.ModuleConfiguration);
                //secTestLabel.Visible = ms.HasPermission1;

            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }


        //protected void button_Click(object sender, EventArgs e)
        //{
        //    //Button securityBtn = sender as Button;
        //    //string buttonid = secBtn.ID.ToString();
        //    // identify which button was what row to update based on id clicked and perform necessary actions

        //    FeatureController cntrl = new FeatureController();
        //    cntrl.UpgradeModule("01.00.00");
        //}


        //DNN USerinfo

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

        //SP SurveyInfo

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



    }
}