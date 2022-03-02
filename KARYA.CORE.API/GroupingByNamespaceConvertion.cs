using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Linq;

namespace KARYA.CORE.API
{
    public class GroupingByNamespaceConvertion : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            var controllerNamespace = controller.ControllerType.Namespace;
            var apiVersion = controllerNamespace.Split(".").Last().ToLower();
            //var res = Request.Path.Value;
            if (!apiVersion.StartsWith("v")) apiVersion = "v1";

            controller.ApiExplorer.GroupName = apiVersion;
        }
    }
}