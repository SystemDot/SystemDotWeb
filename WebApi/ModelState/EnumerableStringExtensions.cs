namespace SystemDot.Web.WebApi.ModelState
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using SystemDot.Core;
    using SystemDot.Core.Collections;

    public static class EnumerableStringExtensions
    {
        public static void AddMessagesToModelState<TModel, TProperty>(
            this IEnumerable<string> messages,
            Expression<Func<TModel, TProperty>> property)
        {
            messages.ForEach(message => 
                CurrentModelStateLocator.Locate()
                    .AddModelError(GetModelPropertyValidationKey(property), message));
        }

        static string GetModelPropertyValidationKey<TModel, TProperty>(
            Expression<Func<TModel, TProperty>> property)
        {
            return string.Format(
                "{0}.{1}", 
                typeof (TModel).Name.ToCamelCase(), 
                property.Body.As<MemberExpression>().Member.Name);
        }
    }
}