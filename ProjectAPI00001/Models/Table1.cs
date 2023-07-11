using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectAPI00001.Models
{
    public class Table1
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("uniqueId")]
        public Guid UniqueId { get; set; }

        [Column("sensor_data")]
        public double? SensorData { get; set; }

        [Column("sensor_name")]
        public string? SensorName { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

    }
}
