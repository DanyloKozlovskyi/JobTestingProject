using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using ShortenerEntities;

namespace ShortenerExample.CustomModelBinders
{
    public class UserModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(User))
            {
                return new BinderTypeModelBinder(typeof(UserModelBinder));
            }
            return null;
        }
    }
}
