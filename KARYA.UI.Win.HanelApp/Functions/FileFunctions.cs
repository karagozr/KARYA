
using KARYA.Core.Types.Return;
using KARYA.Core.Types.Return.Interfaces;
using KARYA.HanelApp.Common.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace KARYA.HanelApp.UI.Win.Functions
{
    public static class FileFunctions
    {
        public static IResult WriteConnectionData(ConnectionValuesModel connectionValuesModel)
        {
            try
            {
                if (!Directory.Exists(Application.StartupPath + @"\AppSetting"))
                    Directory.CreateDirectory(Application.StartupPath + @"\AppSetting");

                var settings = new XmlWriterSettings { Indent = true };
                var writter = XmlWriter.Create(Application.StartupPath + @"\AppSetting\ConnectionSetting.xml", settings);
                writter.WriteStartDocument();
                writter.WriteComment("Created by KARYA");
                writter.WriteStartElement("Connection");
                writter.WriteAttributeString("Server", connectionValuesModel.Server);
                writter.WriteAttributeString("Database", connectionValuesModel.Database);
                writter.WriteAttributeString("User", connectionValuesModel.User);
                writter.WriteAttributeString("Password", connectionValuesModel.Password);
                writter.WriteEndElement();
                writter.WriteEndDocument();
                writter.Flush();
                writter.Close();

                return new SuccessResult("Saved succesfully");
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public static IDataResult<ConnectionValuesModel> ReadConnectionData()
        {
            var connData = new ConnectionValuesModel();

            try
            {
                if (File.Exists(Application.StartupPath + $@"\AppSetting\ConnectionSetting.xml"))
                {
                    var reader = XmlReader.Create(Application.StartupPath + $@"\AppSetting\ConnectionSetting.xml");

                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "Connection")
                        {
                            connData.Server     = reader.GetAttribute(0);
                            connData.Database   = reader.GetAttribute(1);
                            connData.User       = reader.GetAttribute(2);
                            connData.Password   = reader.GetAttribute(3);
                        }
                        

                    }

                    reader.Close();
                    reader.Dispose();

                    return new SuccessDataResult<ConnectionValuesModel>(connData, "Connection Setting file saved successfully");
                }
                else
                {
                    return new ErrorDataResult<ConnectionValuesModel>(connData, "Connection Setting file was not created");
                }

                
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ConnectionValuesModel>(connData,ex.Message);
            }


        }
    }
}
