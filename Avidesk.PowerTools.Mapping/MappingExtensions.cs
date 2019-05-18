#region Header

// File: Avidesk.PowerTools\Avidesk.PowerTools.Mapping\MappingExtensions.cs
// Date Created: 05/15/2019 3:03 PM
// 
// Last Code Cleanup: 05/17/2019 9:57 PM
// Last Cleaned By: Andrew Johnson (andrewjohnson)

#endregion

#region Using Directives

using System.Collections.Generic;
using AutoMapper;

#endregion

namespace Avidesk.PowerTools.Mapping
{
    public static class MappingExtensions
    {
        #region Static Methods

        public static T MapFromTo<TU, T>(this TU o)
        {
            return Mapper.Map<TU, T>(o);
        }

        public static T MapTo<T>(this object o)
        {
            return Mapper.Map<T>(o);
        }

        public static List<T> MapToList<T>(this object o)
        {
            return Mapper.Map<List<T>>(o);
        }

        #endregion
    }
}