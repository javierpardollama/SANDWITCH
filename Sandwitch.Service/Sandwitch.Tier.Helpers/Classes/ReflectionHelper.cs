using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Sandwitch.Tier.Helpers.Classes
{
    /// <summary>
    /// Represents a <see cref="ReflectionHelper"/> class.
    /// </summary>
    public static class ReflectionHelper
    {
        /// <summary>
        /// Gets Empty Properties
        /// </summary>
        /// <param name="object">Injected <see cref="T"/></param>
        /// <returns>Instance of <see cref="List{KeyValuePair{string,string}}"/></returns>
        public static List<KeyValuePair<string, string>> GetEmptyProperties<T>(T @object)
        {
            return typeof(T).GetProperties()
                .Where(prop =>
                 !Attribute.IsDefined(prop, typeof(NotMappedAttribute))
                && (prop.PropertyType == typeof(string)
                || prop.PropertyType == typeof(DateTime)
                || prop.PropertyType == typeof(DateTime?)
                || prop.PropertyType == typeof(Guid)
                || prop.PropertyType == typeof(Guid?)
                || prop.PropertyType == typeof(int)
                || prop.PropertyType == typeof(int?)
                || prop.PropertyType == typeof(double)
                || prop.PropertyType == typeof(double?)
                || prop.PropertyType == typeof(decimal)
                || prop.PropertyType == typeof(decimal?)                          
                || prop.PropertyType == typeof(long)
                || prop.PropertyType == typeof(long?)                
                || prop.PropertyType == typeof(bool)
                || prop.PropertyType == typeof(bool?)
                ))
                .Select(refprop => new KeyValuePair<string, string>(refprop.Name, refprop?.GetValue(@object)?.ToString())).ToList()
                .OrderBy(refprop => refprop.Key)
                .Where(refprop => refprop.Value == null)
                .ToList();
        }
    }
}
