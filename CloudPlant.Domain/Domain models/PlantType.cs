using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudPlant.Domain.Domain_models
{
    public class PlantType : BaseEntity
    {
        public string PlantTypeName { get; set; }
        public float ThresholdValue1 { get; set; }
        public float ThresholdValue2 { get; set; }
        public float ThresholdValue3 { get; set; }
        public float ThresholdValue4 { get; set; }
        public virtual List<Plant> Plants { get; set; }
        public PlantType()
        {
            Plants = new List<Plant>();
        }

    }
}
