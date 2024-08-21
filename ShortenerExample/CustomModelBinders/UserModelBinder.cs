using Microsoft.AspNetCore.Mvc.ModelBinding;
using ShortenerEntities;
using System;

namespace ShortenerExample.CustomModelBinders
{
    public class UserModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            User user = new User();

            //UserName
            if (bindingContext.ValueProvider.GetValue("UserName").Length > 0)
            {
                user.UserName = bindingContext.ValueProvider.GetValue("UserName").FirstValue;
            }

            //Password
            if (bindingContext.ValueProvider.GetValue("Password").Length > 0)
                user.Password = bindingContext.ValueProvider.GetValue("Password").FirstValue;

            //Id
            if (bindingContext.ValueProvider.GetValue("UserId").Length > 0)
                user.UserId = new Guid(bindingContext.ValueProvider.GetValue("UserId").FirstValue);




            bindingContext.Result = ModelBindingResult.Success(user);
            return Task.CompletedTask;
        }
    }
}
