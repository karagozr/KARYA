using KARYA.MODEL.Entities.Karya;
using System.Collections.Generic;
using System.Linq;

namespace KARYA.MODEL.Module
{

    public class CoreModules: ICoreModules
    {
        public IList<AppModule> ModuleList { get; set; }
        public CoreModules()
        {
            ModuleList = new List<AppModule>();
            
            #region ADMIN PANEL
            ModuleList.Add(new AppModule() { Id = BaseRole.AdminPanel, ParentId = 0, Name = "Admin Panel", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            #region USER CONTROL                                                                                                
            ModuleList.Add(new AppModule() { Id = BaseRole.UserControl, ParentId = BaseRole.AdminPanel,         Name = "User Control", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = BaseRole.UserAdd, ParentId = BaseRole.UserControl,            Name = "User Add", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = BaseRole.UserEdit, ParentId = BaseRole.UserControl,           Name = "User Edit", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = BaseRole.UserDelete, ParentId = BaseRole.UserControl,         Name = "User Delete", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            #endregion
            #region AUtHORIZE CONTROL
            ModuleList.Add(new AppModule() { Id = BaseRole.AuthorizeModul, ParentId = BaseRole.AdminPanel,      Name = "AuthorizeModul", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = BaseRole.AuthorizeAdd, ParentId = BaseRole.AuthorizeModul,    Name = "AuthorizeAdd", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = BaseRole.AuthorizeEdit, ParentId = BaseRole.AuthorizeModul,   Name = "AuthorizeEdit", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            ModuleList.Add(new AppModule() { Id = BaseRole.AuthorizeDelete, ParentId = BaseRole.AuthorizeModul, Name = "AuthorizeDelete", DefaultAuthorize = false, RecordBasedAuthorize = false, FieldGroupId = 0 });
            #endregion
            #endregion
        }

    }
}
