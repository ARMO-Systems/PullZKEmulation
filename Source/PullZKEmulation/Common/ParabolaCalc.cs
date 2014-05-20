using System;

namespace ArmoSystems.ArmoGet.PullZkEmulator.Common
{
    internal static class ParabolaCalc
    {
        internal static long CalculateSleepTicks( MeasurementTableData data, int EmpsCount )
        {
            var y1 = data.FirstMeasurement.Ticks;
            var y2 = data.SecondMeasurement.Ticks;
            var y3 = data.ThirdMeasurement.Ticks;

            var x1 = data.FirstMeasurement.EmpsCount;
            var x2 = data.SecondMeasurement.EmpsCount;
            var x3 = data.ThirdMeasurement.EmpsCount;

            var a = ( double ) ( y3 - ( x3 * ( y2 - y1 ) + x2 * y1 - x1 * y2 ) / ( x2 - x1 ) ) / ( x3 * ( x3 - x1 - x2 ) + x1 * x2 );
            var b = ( double ) ( y2 - y1 ) / ( x2 - x1 ) - a * ( x1 + x2 );
            var c = ( double ) ( x2 * y1 - x1 * y2 ) / ( x2 - x1 ) + a * x1 * x2;

            return Convert.ToInt64( a * EmpsCount * EmpsCount + b * EmpsCount + c );
        }
    }
}