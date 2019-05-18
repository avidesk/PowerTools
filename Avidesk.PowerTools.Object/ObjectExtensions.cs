#region Header

// File: Avidesk.PowerTools\Avidesk.PowerTools.Object\ObjectExtensions.cs
// Date Created: 05/15/2019 3:03 PM
// 
// Last Code Cleanup: 05/15/2019 3:04 PM
// Last Cleaned By: Andrew Johnson (andrewjohnson)

#endregion

#region Using Directives

using System;

#endregion

namespace Avidesk.PowerTools.Object
{
    public static class ObjectExtensions
    {
        #region Static Methods

        public static object GetPropertyValue(this object o, string propertyName, out Type propertyType)
        {
            var property = o.GetType().GetProperty(propertyName);
            propertyType = property?.PropertyType;
            var propertyValue = property?.GetValue(o, null);

            return propertyValue;
        }

        public static T GetPropertyValue<T>(this object o, string propertyName, out Type propertyType)
        {
            return (T) GetPropertyValue(o, propertyName, out propertyType);
        }

        #endregion
    }
}