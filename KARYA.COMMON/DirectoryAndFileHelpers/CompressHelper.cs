using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.COMMON.DirectoryAndFileHelpers
{
    public static class CompressHelper
    {
        public static ZipArchive GetArchiveFromByteArr(this byte[] arr) 
        {
            try
            {
                var memoryStream = new MemoryStream(arr);
                
                return new ZipArchive(memoryStream, ZipArchiveMode.Read, true);
                    
                
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        public static List<ZipArchiveEntry> GetEntriesInArchive(this ZipArchive zipArchive)
        {
            try
            {
                return zipArchive.Entries.ToList();

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public static bool ExtractFile(this ZipArchiveEntry zipEntry, string path, string fileName)
        {
            try
            {
                zipEntry.ExtractToFile(path+"\\"+fileName, true);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public static bool ExtractFile(this ZipArchiveEntry zipEntry, string path)
        {
            try
            {
                zipEntry.ExtractToFile(path, true);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

    }

}
