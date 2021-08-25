using KARYA.MODEL.Entities.Karya;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.MODEL.Authorize.SahizaWorld
{
    public static class EnumHelper
    {

        public static string Description(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            if (field == null) return value.ToString();
            DescriptionAttribute[] attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            return value.ToString();
        }
    }
    public class AppModules: IAppModules
    {
        public IList<AppModule> ModuleList { get; set; }
        public AppModules()
        {
            ModuleList = new List<AppModule>();

            #region ADMIN PANEL
            ModuleList.Add(new AppModule() { Id = (int)AppRole.AdminModul,        ParentId = 0,                             Name = AppRole.AdminModul.Description()         });
            #region USER MODULE                                                                                                                                                
            ModuleList.Add(new AppModule() { Id = (int)AppRole.UserModul,         ParentId = (int)AppRole.AdminModul,       Name = AppRole.UserModul.Description()          });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.UserAdd,           ParentId = (int)AppRole.UserModul,        Name = AppRole.UserAdd.Description()            });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.UserEdit,          ParentId = (int)AppRole.UserModul,        Name = AppRole.UserEdit.Description()           });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.UserDelete,        ParentId = (int)AppRole.UserModul,        Name = AppRole.UserDelete.Description()         });
            #endregion
            #region AUTHORIZE MODULE 
            ModuleList.Add(new AppModule() { Id = (int)AppRole.AuthorizeModul,    ParentId = (int)AppRole.UserModul,        Name = AppRole.AuthorizeModul.Description()     });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.AuthorizeAdd,      ParentId = (int)AppRole.AuthorizeModul,   Name = AppRole.AuthorizeAdd.Description()       });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.AuthorizeEdit,     ParentId = (int)AppRole.AuthorizeModul,   Name = AppRole.AuthorizeEdit.Description()      });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.AuthorizeDelete,   ParentId = (int)AppRole.AuthorizeModul,   Name = AppRole.AuthorizeDelete.Description()    });
            #endregion
            #endregion

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            
            #region STOK
            ModuleList.Add(new AppModule() { Id = (int)AppRole.StokModule,        ParentId = 0,                             Name = AppRole.StokModule.Description()         });
            //ModuleList.Add(new AppModule() { Id = (int)AppRole.StokAdd,           ParentId = (int)AppRole.StokModule,       Name = AppRole.StokAdd.Description()            });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.StokUpdate,        ParentId = (int)AppRole.StokModule,       Name = AppRole.StokUpdate.Description()         });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.StokDelete,        ParentId = (int)AppRole.StokModule,       Name = AppRole.StokDelete.Description()         });
            #endregion

            #region CARI
            ModuleList.Add(new AppModule() { Id = (int)AppRole.CariModule,        ParentId = 0,                             Name = AppRole.CariModule.Description()         });
            //ModuleList.Add(new AppModule() { Id = (int)AppRole.CariAdd,           ParentId = (int)AppRole.CariModule,       Name = AppRole.CariAdd.Description()            });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.CariUpdate,        ParentId = (int)AppRole.CariModule,       Name = AppRole.CariUpdate.Description()         });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.CariDelete,        ParentId = (int)AppRole.CariModule,       Name = AppRole.CariDelete.Description()         });
            #endregion

            #region CARI
            ModuleList.Add(new AppModule() { Id = (int)AppRole.StokHaraketModule, ParentId = 0,                             Name = AppRole.StokHaraketModule.Description()  });
            //ModuleList.Add(new AppModule() { Id = (int)AppRole.StokHaraketAdd,    ParentId = (int)AppRole.StokHaraketModule,Name = AppRole.StokHaraketAdd.Description()     });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.StokHaraketUpdate, ParentId = (int)AppRole.StokHaraketModule,Name = AppRole.StokHaraketUpdate.Description()  });
            ModuleList.Add(new AppModule() { Id = (int)AppRole.StokHaraketDelete, ParentId = (int)AppRole.StokHaraketModule,Name = AppRole.StokHaraketDelete.Description()  });
            #endregion


            foreach (var item in ModuleList)
            {
                item.DefaultAuthorize = false;
                item.FieldGroupId = 0;
                item.RecordBasedAuthorize = false;
            }
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
