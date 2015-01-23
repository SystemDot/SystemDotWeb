namespace SystemDot.Web.WebApi.ModelState
{
    using System.Threading;
    using System.Web.Http.ModelBinding;

    public static class CurrentModelStateLocator
    {
        private static readonly ThreadLocal<ModelStateDictionary> Dictionary = 
            new ThreadLocal<ModelStateDictionary>();

        public static ModelStateDictionary Locate()
        {
            return Dictionary.Value;
        }

        public static void Set(ModelStateDictionary toSet)
        {
            Dictionary.Value = toSet;
        }
    }
}