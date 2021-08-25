using Dapper;
using KARYA.BUSINESS.Abstract.TranslateApp;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.DATAACCESS.Concrete.Dapper;
using KARYA.MODEL.Entities.TranslateApp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.BUSINESS.Concrete.TranslateApp
{
    public class InnovaUserManager : DapperBaseDal, IInnovaUserManager
    {
        public async Task<IResult> AddUser(InnovaUser innovaUser)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var queryString = $"INSERT INTO [dbo].[TBLKULLANICI]([KULLANICI],[SIFRE]]) " +
                        $"VALUES ({innovaUser.Username},{innovaUser.Password})";

                    var resultData = await connection.QueryAsync(queryString);

                    return new SuccessResult();
                }

            }
            catch (Exception ex)
            {
                return new ErrorResult("Hata : "+ex.Message);
            }
        }

        public async Task<IResult> DeleteUser(InnovaUser innovaUser)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var queryString = $"update TBLKULLANICI set AKTIF = 1 where ID ={innovaUser.Id} ";

                    var resultData = await connection.QueryAsync(queryString);

                    return new SuccessResult();
                }

            }
            catch (Exception ex)
            {
                return new ErrorResult("Hata : "+ex.Message);
            }
        }

        public async Task<IDataResult<InnovaUser>> LoginUser(string username, string password)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var queryString = $"select ID as Id, KULLANICI as Username, SIFRE as [Password] from TBLKULLANICI where KULLANICI ='{username}' and SIFRE='{password}'";

                    var resultData = await connection.QueryFirstAsync<InnovaUser>(queryString);

                    return new SuccessDataResult<InnovaUser>(resultData);
                }

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<InnovaUser>(null,"Hata : "+ex.Message);
            }
        }

        public async Task<IResult> UpdateUser(InnovaUser innovaUser)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var queryString = $"update TBLKULLANICI " +
                        $"set KULLANICI = '{innovaUser.Username}', " +
                        $"SIFRE='{innovaUser.Password}' " +
                        $"where ID ={innovaUser.Id} ";

                    var resultData = await connection.QueryAsync(queryString);

                    return new SuccessResult();
                }

            }
            catch (Exception ex)
            {
                return new ErrorResult("Hata : " + ex.Message);
            }
        }
    }
}
