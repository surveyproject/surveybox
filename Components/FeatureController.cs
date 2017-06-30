/*
' Copyright (c) 2014 FryslanWebservices.com
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System.Collections.Generic;
//using System.Xml;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Services.Search;
using DotNetNuke.Security.Permissions;
using System.Collections;
using DotNetNuke.Entities.Modules.Definitions;

namespace FWS.Modules.SurveyBox.Components
{

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The Controller class for SurveyBox
    /// 
    /// The FeatureController class is defined as the BusinessController in the manifest file (.dnn)
    /// DotNetNuke will poll this class to find out which Interfaces the class implements. 
    /// 
    /// The IPortable interface is used to import/export content from a DNN module
    /// 
    /// The ISearchable interface is used by DNN to index the content of a module
    /// 
    /// The IUpgradeable interface allows module developers to execute code during the upgrade 
    /// process for a module.
    /// 
    /// Below you will find stubbed out implementations of each, uncomment and populate with your own data
    /// </summary>
    /// -----------------------------------------------------------------------------

    //uncomment the interfaces to add the support.
    public class FeatureController //: IUpgradeable //IPortable, ISearchable, 
    {


        #region Optional Interfaces

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// ExportModule implements the IPortable ExportModule Interface
        /// </summary>
        /// <param name="ModuleID">The Id of the module to be exported</param>
        /// -----------------------------------------------------------------------------
        public string ExportModule(int ModuleID)
        {
            //string strXML = "";

            //List<SurveyBoxInfo> colSurveyBoxs = GetSurveyBoxs(ModuleID);
            //if (colSurveyBoxs.Count != 0)
            //{
            //    strXML += "<SurveyBoxs>";

            //    foreach (SurveyBoxInfo objSurveyBox in colSurveyBoxs)
            //    {
            //        strXML += "<SurveyBox>";
            //        strXML += "<content>" + DotNetNuke.Common.Utilities.XmlUtils.XMLEncode(objSurveyBox.Content) + "</content>";
            //        strXML += "</SurveyBox>";
            //    }
            //    strXML += "</SurveyBoxs>";
            //}

            //return strXML;

            throw new System.NotImplementedException("The method or operation is not implemented.");
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// ImportModule implements the IPortable ImportModule Interface
        /// </summary>
        /// <param name="ModuleID">The Id of the module to be imported</param>
        /// <param name="Content">The content to be imported</param>
        /// <param name="Version">The version of the module to be imported</param>
        /// <param name="UserId">The Id of the user performing the import</param>
        /// -----------------------------------------------------------------------------
        public void ImportModule(int ModuleID, string Content, string Version, int UserID)
        {
            //XmlNode xmlSurveyBoxs = DotNetNuke.Common.Globals.GetContent(Content, "SurveyBoxs");
            //foreach (XmlNode xmlSurveyBox in xmlSurveyBoxs.SelectNodes("SurveyBox"))
            //{
            //    SurveyBoxInfo objSurveyBox = new SurveyBoxInfo();
            //    objSurveyBox.ModuleId = ModuleID;
            //    objSurveyBox.Content = xmlSurveyBox.SelectSingleNode("content").InnerText;
            //    objSurveyBox.CreatedByUser = UserID;
            //    AddSurveyBox(objSurveyBox);
            //}

            throw new System.NotImplementedException("The method or operation is not implemented.");
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// GetSearchItems implements the ISearchable Interface
        /// </summary>
        /// <param name="ModInfo">The ModuleInfo for the module to be Indexed</param>
        /// -----------------------------------------------------------------------------
        public DotNetNuke.Services.Search.SearchItemInfoCollection GetSearchItems(DotNetNuke.Entities.Modules.ModuleInfo ModInfo)
        {
            //SearchItemInfoCollection SearchItemCollection = new SearchItemInfoCollection();

            //List<SurveyBoxInfo> colSurveyBoxs = GetSurveyBoxs(ModInfo.ModuleID);

            //foreach (SurveyBoxInfo objSurveyBox in colSurveyBoxs)
            //{
            //    SearchItemInfo SearchItem = new SearchItemInfo(ModInfo.ModuleTitle, objSurveyBox.Content, objSurveyBox.CreatedByUser, objSurveyBox.CreatedDate, ModInfo.ModuleID, objSurveyBox.ItemId.ToString(), objSurveyBox.Content, "ItemId=" + objSurveyBox.ItemId.ToString());
            //    SearchItemCollection.Add(SearchItem);
            //}

            //return SearchItemCollection;

            throw new System.NotImplementedException("The method or operation is not implemented.");
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// UpgradeModule implements the IUpgradeable Interface
        /// </summary>
        /// <param name="Version">The current version of the module</param>
        /// -----------------------------------------------------------------------------
        public string UpgradeModule(string Version)
        {

            //    if (Version == "01.01.00")
            //    {
            //        // Install module permissions
            //        InitModulePermissions();
            //    }
            //    return Version;

            throw new System.NotImplementedException("The method or operation is not implemented.");
        }



        //private void InitModulePermissions()
        //{
        //    PermissionController permCtl = new PermissionController();

        //    int PID = PortalController.Instance.GetCurrentPortalSettings().PortalId;

        //    DesktopModuleInfo desktopInfo = DesktopModuleController.GetDesktopModuleByModuleName("SurveyBox", PID);

        //    ModuleDefinitionInfo modDefInfo = ModuleDefinitionController.GetModuleDefinitionByDefinitionName("SurveyBox", desktopInfo.DesktopModuleID);

        //    //try
        //    //{
        //    //    PermissionInfo pi = new PermissionInfo();
        //    //    pi.ModuleDefID = modDefInfo.ModuleDefID;
        //    //    pi.PermissionCode = ModuleSecurity.PERMISSIONCODE;
        //    //    pi.PermissionKey = ModuleSecurity.PERMISSION1;
        //    //    pi.PermissionName = "Label Visible";
        //    //    permCtl.AddPermission(pi);
        //    //}
        //    //catch
        //    //{
        //    //}
        //    try
        //    {
        //        PermissionInfo pi = new PermissionInfo();
        //        pi.ModuleDefID = modDefInfo.ModuleDefID;
        //        pi.PermissionCode = ModuleSecurity.PERMISSIONCODE;
        //        pi.PermissionKey = ModuleSecurity.PERMISSION2;
        //        pi.PermissionName = "Show Surveylist";
        //        permCtl.AddPermission(pi);
        //    }
        //    catch
        //    {
        //    }
        //}

        #endregion

    }

}
