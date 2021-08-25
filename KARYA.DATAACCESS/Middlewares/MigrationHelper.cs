using KARYA.DATAACCESS.Concrete.EntityFramework.Context;
using KARYA.MODEL.Module;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KARYA.DATAACCESS.Middlewares
{
    public static class MigrationHelper
    {
        public static void AddKaryaMigrate(this IServiceCollection services, IConfiguration configuration)
        {
            string programName = typeof(MigrationHelper).Assembly.GetName().Name;
            services.AddDbContext<KaryaContext>(options => options.UseSqlServer(configuration.GetConnectionString("KARYAConnection"), x => x.MigrationsAssembly(programName)));
            services.BuildServiceProvider().GetService<KaryaContext>().Database.Migrate();
        }
    }

    public static class AppModuleMigrationHelper
    {

        public static int SqlBool(bool value)
        {
            if (value) return 1;
            else return 0;
        }

        public static string CreateInstallationQuery(string dbName, ICoreModules _appModules)
        {

            var query = $"USE [{dbName}] " +
                $"declare @AuthorizeGroupId int " +
                $"declare @UserId int ";

            query += $"INSERT INTO [dbo].[AppModule]([Id],[ParentId],[Name],[DefaultAuthorize],[RecordBasedAuthorize],[FieldGroupId]) VALUES ";

            foreach (var module in _appModules.ModuleList)
            {
                query += $"({module.Id},{module.ParentId},'{module.Name}',{SqlBool(module.DefaultAuthorize)},{SqlBool(module.RecordBasedAuthorize)},{module.FieldGroupId}),";
            }
            query = query.Remove(query.Length - 1);
            query += $" " +
                $"INSERT INTO [dbo].[AuthorizeGroup] ([Name],[Description],[CreatedTime],[UpdatedTime],[CreatedUserId],[UpdatedUserId]) " +
                $"VALUES('Admin', 'All modules open', GETDATE(), GETDATE(), 0, 0) " +
                $"set @AuthorizeGroupId = SCOPE_IDENTITY() " +
                $"INSERT INTO [dbo].[AuthorizeGroupDetail]([AuthorizeGroupId],[AppModuleId],[IsAuthorize],[FilterRule],[FieldName],[FilterValue1],[FilterValue2]) VALUES ";

            foreach (var module in _appModules.ModuleList)
            {
                query += $"(@AuthorizeGroupId,'{module.Id}','1',0,null,null,null),";
            }
            query = query.Remove(query.Length - 1);
            query += $" " +
                $"INSERT INTO [dbo].[Users] ([Enable],[Code],[UserGroupId],[Name],[Lastname],[UserName],[Password],[EMail],[Description],[CreatedTime],[UpdatedTime],[CreatedUserId],[UpdatedUserId])" +
                $" VALUES(1,'USER001',0,'Super','User','Admin','123',null,null,GETDATE(),GETDATE(),0,0) " +
                $"SET @UserId = SCOPE_IDENTITY() " +
                $"INSERT INTO [dbo].[UserAuthorizeGroup]([UserId],[AuthorizeGroupId]) " +
                $"VALUES(@UserId, @AuthorizeGroupId) ";


            return query;
        }

        public static string CreateUpdateQuery(string dbName, ICoreModules _appModules)
        {
            var query = $"USE [{dbName}] " +
                $"declare @AuthorizeGroupId int " +
                $"SELECT TOP 1 @AuthorizeGroupId=Id FROM [dbo].[AuthorizeGroup] " +
                $"declare @UserId int " +
                $"SELECT TOP 1 @UserId=Id FROM [dbo].[Users] ";

            query += $"DELETE FROM [dbo].[AppModule]";

            query += $"INSERT INTO [dbo].[AppModule]([Id],[ParentId],[Name],[DefaultAuthorize],[RecordBasedAuthorize],[FieldGroupId]) VALUES ";

            foreach (var module in _appModules.ModuleList)
            {
                query += $"({module.Id},{module.ParentId},'{module.Name}',{SqlBool(module.DefaultAuthorize)},{SqlBool(module.RecordBasedAuthorize)},{module.FieldGroupId}),";
            }
            query = query.Remove(query.Length - 1);
            query += $" " +
                $"DELETE FROM [dbo].[AuthorizeGroupDetail] WHERE AuthorizeGroupId=@AuthorizeGroupId " +
                $"INSERT INTO [dbo].[AuthorizeGroupDetail]([AuthorizeGroupId],[AppModuleId],[IsAuthorize],[FilterRule],[FieldName],[FilterValue1],[FilterValue2]) VALUES ";

            foreach (var module in _appModules.ModuleList)
            {
                query += $"(@AuthorizeGroupId,'{module.Id}','1',0,null,null,null),";
            }
            query = query.Remove(query.Length - 1);
            query += $" ";


            return query;
        }


    }
}

