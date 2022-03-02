//using Microsoft.OpenApi.Models;
//using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.CORE.API.Helpers
{
    public class RemoveVersionFromParameter //: IOperationFilter
    {
        //public void Apply(OpenApiOperation operation, OperationFilterContext context)
        //{
        //    if (operation.Parameters.Count > 0 && operation.Parameters.Any(p => p.Name == "version")  )
        //    {
        //        var versParam = operation.Parameters.Single(p => p.Name == "version");
        //        operation.Parameters.Remove(versParam);

        //    }
        //}
    }

    public class ReplaceVersionParameterInPath //: IDocumentFilter
    {

        //public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        //{
        //    var paths = swaggerDoc.Paths;
        //    swaggerDoc.Paths = new OpenApiPaths();

        //    foreach (var item in paths)
        //    {
        //        var key = item.Key.Replace("v{version}", swaggerDoc.Info.Version);
        //        var value = item.Value;
        //        swaggerDoc.Paths.Add(key, value);
        //    }
        //}
    }
}
