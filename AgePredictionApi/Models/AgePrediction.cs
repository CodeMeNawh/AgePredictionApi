using System.ComponentModel.DataAnnotations;

namespace AgePredictionApi.Models
{
    public class AgePrediction
    {
        [Key]
        public string Name { get; set; }
        public int? Age { get; set; }
        public int Count { get; set; }
    }
}
