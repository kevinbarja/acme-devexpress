using System;
using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Security.Strategy;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;
using Acme.Module.BusinessObjects.acme;

namespace Acme.Module.DatabaseUpdate {
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppUpdatingModuleUpdatertopic.aspx
    public class Updater : ModuleUpdater {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
            base(objectSpace, currentDBVersion) {
        }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            //string name = "MyName";
            //DomainObject1 theObject = ObjectSpace.FindObject<DomainObject1>(CriteriaOperator.Parse("Name=?", name));
            //if(theObject == null) {
            //    theObject = ObjectSpace.CreateObject<DomainObject1>();
            //    theObject.Name = name;
            //}
            SecuritySystemUser sampleUser = ObjectSpace.FindObject<SecuritySystemUser>(new BinaryOperator("UserName", "User"));
            if(sampleUser == null) {
                sampleUser = ObjectSpace.CreateObject<SecuritySystemUser>();
                sampleUser.UserName = "User";
                sampleUser.SetPassword("");
            }
            SecuritySystemRole defaultRole = CreateDefaultRole();
            sampleUser.Roles.Add(defaultRole);

            SecuritySystemUser userAdmin = ObjectSpace.FindObject<SecuritySystemUser>(new BinaryOperator("UserName", "Admin"));
            if(userAdmin == null) {
                userAdmin = ObjectSpace.CreateObject<SecuritySystemUser>();
                userAdmin.UserName = "Admin";
                // Set a password if the standard authentication type is used
                userAdmin.SetPassword("");
            }
			// If a role with the Administrators name doesn't exist in the database, create this role
            SecuritySystemRole adminRole = ObjectSpace.FindObject<SecuritySystemRole>(new BinaryOperator("Name", "Administrators"));
            if(adminRole == null) {
				adminRole = ObjectSpace.CreateObject<SecuritySystemRole>();
				adminRole.Name = "Administrators";
            
                // Seed demo data
                ObjectSpace.CreateObject<BusinessUnit>().Name = "RRHH";
                ObjectSpace.CreateObject<BusinessUnit>().Name = "IT";
                ObjectSpace.CreateObject<BusinessUnit>().Name = "COMERCIAL";

                ObjectSpace.CreateObject<Period>().Name = "2020";
                ObjectSpace.CreateObject<Period>().Name = "2018";

                ObjectSpace.CreateObject<ServiceType>().Name = "Pago de planilla";
                ObjectSpace.CreateObject<ServiceType>().Name = "Envio de SMS";

                ObjectSpace.CreateObject<ServiceLocation>().Name = "Central";
                ObjectSpace.CreateObject<ServiceLocation>().Name = "Local";

                Department sczDepartment = ObjectSpace.CreateObject<Department>();
                sczDepartment.Name = "Santa Cruz";

                ObjectSpace.CreateObject<Department>().Name = "La Paz";

                UserService sczUserService = ObjectSpace.CreateObject<UserService>();
                sczUserService.Department = sczDepartment;
                sczUserService.Agency = "Norte";
                sczUserService.Count = ">10000";

                ObjectSpace.CreateObject<AppService>().Name = "Cosim ERP";
            }

            adminRole.IsAdministrative = true;
            userAdmin.Roles.Add(adminRole);

            ObjectSpace.CommitChanges(); //This line persists created object(s).
        }
        public override void UpdateDatabaseBeforeUpdateSchema() {
            base.UpdateDatabaseBeforeUpdateSchema();
            //if(CurrentDBVersion < new Version("1.1.0.0") && CurrentDBVersion > new Version("0.0.0.0")) {
            //    RenameColumn("DomainObject1Table", "OldColumnName", "NewColumnName");
            //}
        }
        private SecuritySystemRole CreateDefaultRole() {
            SecuritySystemRole defaultRole = ObjectSpace.FindObject<SecuritySystemRole>(new BinaryOperator("Name", "Default"));
            if(defaultRole == null) {
                defaultRole = ObjectSpace.CreateObject<SecuritySystemRole>();
                defaultRole.Name = "Default";

                defaultRole.AddObjectAccessPermission<SecuritySystemUser>("[Oid] = CurrentUserId()", SecurityOperations.ReadOnlyAccess);
                defaultRole.AddMemberAccessPermission<SecuritySystemUser>("ChangePasswordOnFirstLogon", SecurityOperations.Write, "[Oid] = CurrentUserId()");
                defaultRole.AddMemberAccessPermission<SecuritySystemUser>("StoredPassword", SecurityOperations.Write, "[Oid] = CurrentUserId()");
                defaultRole.SetTypePermissionsRecursively<SecuritySystemRole>(SecurityOperations.Read, SecuritySystemModifier.Allow);
                defaultRole.SetTypePermissionsRecursively<ModelDifference>(SecurityOperations.ReadWriteAccess, SecuritySystemModifier.Allow);
                defaultRole.SetTypePermissionsRecursively<ModelDifferenceAspect>(SecurityOperations.ReadWriteAccess, SecuritySystemModifier.Allow);
            }
            return defaultRole;
        }
    }
}
