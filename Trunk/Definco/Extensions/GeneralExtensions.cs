using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;

namespace Definco.Extensions
{
    public static class GeneralExtensions
    {
        public static string GetDisplayName<T, U>(this T src, Expression<Func<T, U>> exp)
        {
            var me = exp.Body as MemberExpression;
            if (me == null)
                throw new ArgumentException("Must be a MemberExpression.", "exp");

            var attr = me.Member
                         .GetCustomAttributes(typeof(DisplayAttribute), false)
                         .Cast<DisplayAttribute>()
                         .SingleOrDefault();

            return (attr != null) ? attr.Name : me.Member.Name;
        }
    }
}