using CloudPlant.Domain.Domain_models;
using CloudPlant.Domain.DTO;
using CloudPlant.Repository.Interface;
using CloudPlant.Service.Interface;

namespace CloudPlant.Service.Implementation
{
    public class MeasurementService : IMeasurementService
    {
        private readonly IMeasurementRepository _measurementRepository;
        private readonly IDeviceRepository _deviceRepository;
        public MeasurementService(IMeasurementRepository measurementRepository, IDeviceRepository deviceRepository)
        {
            this._measurementRepository = measurementRepository;
            this._deviceRepository = deviceRepository;
        }

        public List<Measurement> CreateMeasurements(MeasurementsCreationDTO measurements)
        {
            var device = _deviceRepository.GetById(measurements.DeviceID);
            var plants = device.Plants;

            var measurementList = new List<Measurement>();

            if (plants.Count < 3)
            {
                throw new InvalidOperationException("The device does not have enough plants for all measurements.");
            }

            var measurement1 = new Measurement
            {
                SoilMeasurement = measurements.SensorMoisture1,
                HumidityMeasurement = measurements.Humidity,
                TemperatureMeasurement = measurements.Temperature,
                Plant = plants[0]
            };
            _measurementRepository.Insert(measurement1);
            measurementList.Add(measurement1);

            var measurement2 = new Measurement
            {
                SoilMeasurement = measurements.SensorMoisture2,
                HumidityMeasurement = measurements.Humidity,
                TemperatureMeasurement = measurements.Temperature,
                Plant = plants[1]
            };
            _measurementRepository.Insert(measurement2);
            measurementList.Add(measurement2);

            var measurement3 = new Measurement
            {
                SoilMeasurement = measurements.SensorMoisture3,
                HumidityMeasurement = measurements.Humidity,
                TemperatureMeasurement = measurements.Temperature,
                Plant = plants[2]
            };
            _measurementRepository.Insert(measurement3);
            measurementList.Add(measurement3);

            return measurementList;
        }
    }
}
