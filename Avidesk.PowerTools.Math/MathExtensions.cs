#region Header

// File: Avidesk.PowerTools\Avidesk.PowerTools.Math\MathExtensions.cs
// Date Created: 05/15/2019 2:58 PM
// 
// Last Code Cleanup: 05/15/2019 3:02 PM
// Last Cleaned By: Andrew Johnson (andrewjohnson)

#endregion

namespace Avidesk.PowerTools.Math
{
    public static class MathExtensions
    {
        #region Fields

        private const double FloatingPointTolerance = .0000001;

        #endregion

        #region Static Methods

        public static bool EqualsRounded(this float valueA, float? valueB, int roundTo)
        {
            if (valueB is null)
            {
                return false;
            }

            return System.Math.Abs(System.Math.Round(valueA, roundTo) - System.Math.Round((double) valueB, roundTo)) < FloatingPointTolerance;
        }

        public static bool EqualsRounded(this double valueA, double? valueB, int roundTo)
        {
            if (valueB is null)
            {
                return false;
            }

            return System.Math.Abs(System.Math.Round(valueA, roundTo) - System.Math.Round((double) valueB, roundTo)) < FloatingPointTolerance;
        }

        public static bool EqualsRounded(this decimal valueA, decimal? valueB, int roundTo)
        {
            if (valueB is null)
            {
                return false;
            }

            return System.Math.Round(valueA, roundTo) == System.Math.Round((decimal) valueB, roundTo);
        }

        #endregion
    }
}