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
        public void CheckPressure_low_treshold_should_turn_on_alarm()
        {
            Alarm anAlarm = new Alarm();
            anAlarm.Check();
            bool isAlarmOn = anAlarm.AlarmOn;
            Assert.IsTrue(isAlarmOn);
        }
    }
}
