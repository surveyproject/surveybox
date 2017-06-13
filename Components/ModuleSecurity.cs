using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;
using DotNetNuke.Security.Permissions;
using System.Collections;
using DotNetNuke.Entities.Modules.Definitions;

namespace FWS.Modules.SurveyBox.Components
{
    public class ModuleSecurity
    {

        private bool _permission1;
        private bool _permission2;

        // DNN table permission - permissioncode
        public const string PERMISSIONCODE = "SURVEYBOX_MODULE";
        // DNN table permission - permissionkey
        public const string PERMISSION1 = "SURVEYBOX1";
        public const string PERMISSION2 = "SURVEYBOX2";

        public ModuleSecurity(ModuleInfo modInfo)
        {

            ModulePermissionCollection permCollection = modInfo.ModulePermissions;

            _permission1 = ModulePermissionController.HasModulePermission(permCollection, PERMISSION1);
            _permission2 = ModulePermissionController.HasModulePermission(permCollection, PERMISSION2);

        }

        public bool HasPermission1
        {
            get { return _permission1; }
        }

        public bool HasPermission2
        {
            get { return _permission2; }
        }

    }
}