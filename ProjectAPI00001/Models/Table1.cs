using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectAPI00001.Models
{
    public class Table1
    {
        public Table1(int sensorId, double? sensorData, string? sensorName)
        {
            SensorId = sensorId;
            SensorData = sensorData;
            SensorName = sensorName;
        }

        [Column("id")]
        public int Id { get; internal set;}

        [Column("sensor_id")]
        public int SensorId { get; set; }

        [Column("sensor_data")]
        public double? SensorData { get; set; }

        [Column("sensor_name")]
        public string? SensorName { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; internal set; } = DateTime.Now;
    }
}
