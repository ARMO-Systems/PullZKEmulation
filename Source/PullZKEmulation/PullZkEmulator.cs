using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using ArmoSystems.ArmoGet.PullZkEmulator.Common;
using ArmoSystems.ArmoGet.PullZkEmulator.Properties;
using RGiesecke.DllExport;

namespace ArmoSystems.ArmoGet.PullZkEmulator
{
    // ReSharper disable UnusedMember.Global
    public static class PullZkEmulator
    {
        private static readonly Dictionary< string, MeasurementTableData > TablesData;

        static PullZkEmulator()
        {
            var xmlSerializer = new XmlSerializer( typeof ( MeasurementsTableDataHolder ) );
            // ReSharper disable once AssignNullToNotNullAttribute
            using ( Stream stream = new MemoryStream( Encoding.UTF8.GetBytes( Resources.PullZkConfig ) ) )
                TablesData = ( ( MeasurementsTableDataHolder ) xmlSerializer.Deserialize( stream ) ).ArrayOfMeasurements.ToDictionary( item => item.TableName );
        }

        [DllExport( "Connect", CallingConvention = CallingConvention.Cdecl )]
        public static int Connect( string protocol )
        {
            Thread.Sleep( TimeSpan.FromSeconds( 0.8425 ) );
            return 1;
        }

        [DllExport( "ControlDevice", CallingConvention = CallingConvention.Cdecl )]
        public static int ControlDeviceDel( int handle, int operationID, int param1, int param2, int param3, int param4, string options )
        {
            return 0;
        }

        [DllExport( "Disconnect", CallingConvention = CallingConvention.Cdecl )]
        public static void Disconnect( int handle )
        {
            Thread.Sleep( TimeSpan.FromSeconds( 0.043 ) );
        }

        [DllExport( "DeleteDeviceData", CallingConvention = CallingConvention.Cdecl )]
        public static int DeleteDeviceData( int handle, string tableName, string data, string options )
        {
            Sleep( tableName, data );
            return 0;
        }

        [DllExport( "GetDeviceDataCount", CallingConvention = CallingConvention.Cdecl )]
        public static int GetDeviceDataCount( int handle, string tableName, string filter, string options )
        {
            return 0;
        }

        [DllExport( "GetDeviceData", CallingConvention = CallingConvention.Cdecl )]
        public static int GetDeviceData( int handle, byte[] buffer, int bufferSize, string tableName, string fieldNames, string filter, string options )
        {
            return 0;
        }

        [DllExport( "GetDeviceParam", CallingConvention = CallingConvention.Cdecl )]
        public static int GetDeviceParam( int handle, byte[] buffer, int bufferSize, string items )
        {
            return 0;
        }

        [DllExport( "GetRTLog", CallingConvention = CallingConvention.Cdecl )]
        public static int GetRTLog( int handle, byte[] buffer, int bufferSize )
        {
            return 0;
        }

        [DllExport( "ModifyIPAddress", CallingConvention = CallingConvention.Cdecl )]
        public static int ModifyIPAddress( string commType, string address, string buffer )
        {
            return 0;
        }

        [DllExport( "PullLastError", CallingConvention = CallingConvention.Cdecl )]
        public static int PullLastError()
        {
            return 0;
        }

        [DllExport( "SearchDevice", CallingConvention = CallingConvention.Cdecl )]
        public static int SearchDevice( string type, string address, byte[] buffer )
        {
            return 0;
        }

        [DllExport( "SetDeviceData", CallingConvention = CallingConvention.Cdecl )]
        public static int SetDeviceData( int handle, string tableName, string data, string options )
        {
            Sleep( tableName, data );
            return 0;
        }

        private static void Sleep( string tableName, string data )
        {
            MeasurementTableData tableData = null;
            lock ( TablesData )
            {
                if ( TablesData.ContainsKey( tableName ) )
                    tableData = TablesData[ tableName ];
            }
            if ( tableData != null )
                Thread.Sleep( TimeSpan.FromTicks( ParabolaCalc.CalculateSleepTicks( tableData, data.Split( new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries ).Count() ) ) );
        }

        [DllExport( "SetDeviceFileData", CallingConvention = CallingConvention.Cdecl )]
        public static int SetDeviceFileData( int handle, string fileName, byte[] buffer, int bufferSize, string options )
        {
            return 0;
        }

        [DllExport( "SetDeviceParam", CallingConvention = CallingConvention.Cdecl )]
        public static int SetDeviceParam( int handle, string itemValues )
        {
            return 0;
        }
    }

    // ReSharper restore UnusedMember.Global
}