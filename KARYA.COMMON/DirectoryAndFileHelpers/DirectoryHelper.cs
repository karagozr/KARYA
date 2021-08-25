using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.COMMON.DirectoryAndFileHelpers
{
    public static class DirectoryHelper
    {
        private static string _basePath = $"{AppContext.BaseDirectory}";

        private static string _localData = $"{_basePath}Local Data\\";


        public static string GetLocalDataPath(string folderName)
        {
            if (!Directory.Exists(_localData))  Directory.CreateDirectory(_localData);

            if (!Directory.Exists(_localData + folderName)) Directory.CreateDirectory(_localData + folderName);

            return _localData + folderName+"\\";

        }

        public static IDataResult<string> CheckLocalData(string fileName, string folderName)
        {
            if (File.Exists(_localData+"\\"+folderName+"\\"+fileName)) return new SuccessDataResult<string>(_localData + "\\" + folderName + "\\" + fileName, "");

            return new ErrorDataResult<string>("File not found");

        }
    }
}
