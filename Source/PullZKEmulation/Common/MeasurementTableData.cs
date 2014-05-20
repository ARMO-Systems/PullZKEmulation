using System.Xml.Serialization;

namespace ArmoSystems.ArmoGet.PullZkEmulator.Common
{
    [XmlRoot( "MeasurementTableData" )]
    public sealed class MeasurementTableData
    {
        [XmlElement( "TableName" )]
        public string TableName { set; get; }

        [XmlElement( "FirstMeasurement" )]
        public MeasurementData FirstMeasurement { set; get; }

        [XmlElement( "SecondMeasurement" )]
        public MeasurementData SecondMeasurement { set; get; }

        [XmlElement( "ThirdMeasurement" )]
        public MeasurementData ThirdMeasurement { set; get; }

        [XmlRoot( "MeasurementData" )]
        public sealed class MeasurementData
        {
            [XmlElement( "EmploeesCount" )]
            public int EmpsCount { set; get; }

            [XmlElement( "Ticks" )]
            public long Ticks { set; get; }
        }
    }

    [XmlRoot( "MeasurementTableDataHolder" )]
    public sealed class MeasurementsTableDataHolder
    {
        public MeasurementsTableDataHolder()
        {
            ArrayOfMeasurements = new MeasurementTableData[ 0 ];
        }

        [XmlArray]
        public MeasurementTableData[] ArrayOfMeasurements { set; get; }
    }
}