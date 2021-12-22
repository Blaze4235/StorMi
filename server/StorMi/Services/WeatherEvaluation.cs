using System.Collections.Generic;
using System.Linq;
using StorMi.Interfaces;
using StorMi.Models.WeatherAPI;

namespace StorMi.Services
{
    public class WeatherEvaluation : IWeatherEvaluation
    {
        public WeatherModelDay GetCalculatedWeatherModelDay(IEnumerable<WeatherModelDay> weatherModels)
        {
            var calculatedWeatherModel = new WeatherModelDay();
            var length = weatherModels.ToList().Count;

            foreach (var inputWeatherModel in weatherModels)
            {
                if (inputWeatherModel.City != null)
                {
                    calculatedWeatherModel.City = inputWeatherModel.City;
                }
                if (inputWeatherModel.Country != null)
                {
                    calculatedWeatherModel.Country = inputWeatherModel.Country;
                }
                calculatedWeatherModel.AvgHumidity += inputWeatherModel.AvgHumidity;
                calculatedWeatherModel.AvgTemp += inputWeatherModel.AvgTemp;
                calculatedWeatherModel.ChanceOfRain += inputWeatherModel.ChanceOfRain;
                calculatedWeatherModel.ChanceOfSnow += inputWeatherModel.ChanceOfSnow;
                calculatedWeatherModel.TemperatureMax += inputWeatherModel.TemperatureMax;
                calculatedWeatherModel.TemperatureMin += inputWeatherModel.TemperatureMin;
                calculatedWeatherModel.WindSpeed += inputWeatherModel.WindSpeed;
                if (inputWeatherModel.OverallCondition != null)
                {
                    calculatedWeatherModel.OverallCondition = inputWeatherModel.OverallCondition;
                }
            }

            calculatedWeatherModel.AvgHumidity /= length;
            calculatedWeatherModel.AvgTemp /= length;
            calculatedWeatherModel.ChanceOfRain /= length;
            calculatedWeatherModel.ChanceOfSnow /= length;
            calculatedWeatherModel.TemperatureMax /= length;
            calculatedWeatherModel.TemperatureMin /= length;
            calculatedWeatherModel.WindSpeed /= length;

            return calculatedWeatherModel;
        }

        public IEnumerable<WeatherModelDay> GetCalculatedWeatherModelWeek(
            IEnumerable<WeatherModelDay> weatherModels, int apiNumber = 2, int daysNumber = 7)
        {
            var calculatedWeatherModelList = new List<WeatherModelDay>();
            var length = weatherModels.ToList().Count;

            for (int i = 0; i < daysNumber; i++)
            {
                var tempWeatherList = new List<WeatherModelDay>();
                var calculatedWeatherModel = new WeatherModelDay();

                for (int j = 0; j < apiNumber; j++)
                {
                    var tempWeatherModel = new WeatherModelDay();

                    // Bug with indexes [i * j]
                    tempWeatherModel.City = weatherModels.ToList()[i + daysNumber * j].City;
                    tempWeatherModel.Country = weatherModels.ToList()[i + daysNumber * j].Country;
                    tempWeatherModel.AvgHumidity += weatherModels.ToList()[i + daysNumber * j].AvgHumidity;
                    tempWeatherModel.AvgTemp += weatherModels.ToList()[i + daysNumber * j].AvgTemp;
                    tempWeatherModel.ChanceOfRain += weatherModels.ToList()[i + daysNumber * j].ChanceOfRain;
                    tempWeatherModel.ChanceOfSnow += weatherModels.ToList()[i + daysNumber * j].ChanceOfSnow;
                    tempWeatherModel.TemperatureMax += weatherModels.ToList()[i + daysNumber * j].TemperatureMax;
                    tempWeatherModel.TemperatureMin += weatherModels.ToList()[i + daysNumber * j].TemperatureMin;
                    tempWeatherModel.WindSpeed += weatherModels.ToList()[i + daysNumber * j].WindSpeed;
                    tempWeatherModel.OverallCondition = weatherModels.ToList()[i + daysNumber * j].OverallCondition;

                    var t = weatherModels.ToList()[i + daysNumber * j].TemperatureMin;
                    var t2 = weatherModels.ToList()[i + daysNumber * j].AvgHumidity;
                    tempWeatherList.Add(tempWeatherModel);
                }

                calculatedWeatherModel.City = tempWeatherList.First().City;
                calculatedWeatherModel.Country = tempWeatherList.First().Country;
                calculatedWeatherModel.OverallCondition = tempWeatherList.First().OverallCondition;
                calculatedWeatherModel.AvgHumidity = tempWeatherList.Sum(w => w.AvgHumidity) / apiNumber;
                calculatedWeatherModel.AvgTemp = (int)tempWeatherList.Sum(w => w.AvgTemp) / apiNumber;
                calculatedWeatherModel.ChanceOfRain = tempWeatherList.Sum(w => w.ChanceOfRain) / apiNumber;
                calculatedWeatherModel.ChanceOfSnow = tempWeatherList.Sum(w => w.ChanceOfSnow) / apiNumber;
                calculatedWeatherModel.TemperatureMax = (int)tempWeatherList.Sum(w => w.TemperatureMax) / apiNumber;
                calculatedWeatherModel.TemperatureMin = (int)tempWeatherList.Sum(w => w.TemperatureMin) / apiNumber;
                calculatedWeatherModel.WindSpeed = tempWeatherList.Sum(w => w.WindSpeed) / apiNumber;

                calculatedWeatherModelList.Add(calculatedWeatherModel);
            }
            
            return calculatedWeatherModelList;
        }

        public IEnumerable<WeatherModelHour> GetCalculatedWeatherModelHour(
            IEnumerable<WeatherModelHour> weatherModels, int hourNumbr = 24, int apiNumber = 2)
        {
            var calculatedWeatherModelList = new List<WeatherModelHour>();
            var length = weatherModels.ToList().Count;

            for (int i = 0; i < hourNumbr; i++)
            {
                var tempWeatherList = new List<WeatherModelHour>();
                var calculatedWeatherModel = new WeatherModelHour();

                for (int j = 1; j <= apiNumber; j++)
                {
                    var tempWeatherModel = new WeatherModelHour();

                    tempWeatherModel.City = weatherModels.ToList()[i * j].City;
                    tempWeatherModel.Country = weatherModels.ToList()[i * j].Country;
                    tempWeatherModel.Time = weatherModels.ToList()[i * j].Time;
                    tempWeatherModel.Humidity = weatherModels.ToList()[i * j].Humidity;
                    tempWeatherModel.ChanceOfRain = weatherModels.ToList()[i * j].ChanceOfRain;
                    tempWeatherModel.ChanceOfSnow = weatherModels.ToList()[i * j].ChanceOfSnow;
                    tempWeatherModel.Temp = weatherModels.ToList()[i * j].Temp;
                    tempWeatherModel.FeelsLikeTemp = weatherModels.ToList()[i * j].FeelsLikeTemp;
                    tempWeatherModel.WindSpeed = weatherModels.ToList()[i * j].WindSpeed;
                    tempWeatherModel.WindDegree = weatherModels.ToList()[i * j].WindDegree;
                    tempWeatherModel.WindDirection = weatherModels.ToList()[i * j].WindDirection;
                    tempWeatherModel.AvgVisibilityInKm = weatherModels.ToList()[i * j].AvgVisibilityInKm;
                    tempWeatherModel.WindGustInKm = weatherModels.ToList()[i * j].WindGustInKm;
                    tempWeatherModel.Condition = weatherModels.ToList()[i * j].Condition;

                    tempWeatherList.Add(tempWeatherModel);
                }

                calculatedWeatherModel.City = tempWeatherList.First().City;
                calculatedWeatherModel.Country = tempWeatherList.First().Country;
                calculatedWeatherModel.Time = tempWeatherList.First().Time;
                calculatedWeatherModel.Humidity = tempWeatherList.Sum(w => w.Humidity) / apiNumber;
                calculatedWeatherModel.ChanceOfRain = tempWeatherList.Sum(w => w.ChanceOfRain) / apiNumber;
                calculatedWeatherModel.ChanceOfSnow = tempWeatherList.Sum(w => w.ChanceOfSnow) / apiNumber;
                calculatedWeatherModel.Temp = tempWeatherList.Sum(w => w.Temp) / apiNumber;
                calculatedWeatherModel.FeelsLikeTemp = tempWeatherList.Sum(w => w.FeelsLikeTemp) / apiNumber;
                calculatedWeatherModel.WindSpeed = tempWeatherList.Sum(w => w.WindSpeed) / apiNumber;
                calculatedWeatherModel.WindDegree = tempWeatherList.Sum(w => w.WindDegree) / apiNumber;
                calculatedWeatherModel.WindDirection = tempWeatherList.First().WindDirection;
                calculatedWeatherModel.AvgVisibilityInKm = tempWeatherList.First().AvgVisibilityInKm;
                calculatedWeatherModel.WindGustInKm = tempWeatherList.First().WindGustInKm;
                calculatedWeatherModel.Condition = tempWeatherList.First().Condition;

                calculatedWeatherModelList.Add(calculatedWeatherModel);
            }

            return calculatedWeatherModelList;
        }
    }
}