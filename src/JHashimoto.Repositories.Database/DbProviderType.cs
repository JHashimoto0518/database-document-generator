using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace JHashimoto.Repositories.Database {
    public enum DbProviderTypes {
        [Description("Microsoft.Data.SqlClient")]
        SqlServer = 1
    }

    public static class DbProviderTypesExtensions {
        public static string GetProperName<T>(this T Value) where T : Enum {
            if (!(typeof(T).IsEnum)) {
                throw new InvalidEnumArgumentException();
            }

            FieldInfo fieldInfo = Value.GetType().GetField(Value.ToString());
            if (fieldInfo == null) return null;

            var attr = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false).Cast<DescriptionAttribute>().FirstOrDefault();

            if (attr == null) throw new Exception();
            return attr.Description;
        }
    }
}
