using Moq;
using NUnit.Framework;
using System;

namespace TDDMicroExercises.TirePressureMonitoringSystem.Test
{
    /// <summary>
    /// 1. TirePressureMonitoringSystem exercise:
    /// Write the unit tests for the Alarm class, refactor the code as much as you need to make the class testable.
    /// The Alarm class is designed to monitor tire pressure and set an alarm if the pressure falls outside of the expected range. 
    /// The Sensor class provided for the exercise simulates the behaviour of a real tire sensor, providing random but realistic values.
    /// </summary>
    [TestFixture]
    public class AlarmTest
    {
        [Test]
        public void CheckPressure_low_threshold_should_turn_on_alarm()
        {
            // Arrange
            var mockSensor = new Mock<ISensor>();
            //Mocking sensor data below the threshold (17) so that the alarm will be triggered. 
            mockSensor.Setup(s => s.PopNextPressurePsiValue())
                      .Returns(11.0);

            Alarm anAlarm = new Alarm(mockSensor.Object);
            
            // Act
            anAlarm.Check();

            // Assert
            mockSensor.Verify(s => s.PopNextPressurePsiValue());
            Assert.IsTrue(anAlarm.AlarmOn);
        }

        [Test]
        public void CheckPressure_high_threshold_should_turn_on_alarm()
        {
            // Arrange
            var mockSensor = new Mock<ISensor>();
            //Mocking sensor data above the threshold (21) so that the alarm will be triggered. 
            mockSensor.Setup(s => s.PopNextPressurePsiValue())
                      .Returns(33.0);

            Alarm anAlarm = new Alarm(mockSensor.Object);

            // Act
            anAlarm.Check();

            // Assert
            mockSensor.Verify(s => s.PopNextPressurePsiValue());
            Assert.IsTrue(anAlarm.AlarmOn);
        }

        [Test]
        public void CheckPressure_normal_values_should_not_turn_on_alarm()
        {
            // Arrange
            var mockSensor = new Mock<ISensor>();
            //Mocking sensor data with normal values between (17-21) so that the alarm will NOT be triggered. 
            mockSensor.Setup(s => s.PopNextPressurePsiValue())
                      .Returns(19.0);

            Alarm anAlarm = new Alarm(mockSensor.Object);

            // Act
            anAlarm.Check();

            // Assert
            mockSensor.Verify(s => s.PopNextPressurePsiValue());
            Assert.IsFalse(anAlarm.AlarmOn);
        }
    }
}
