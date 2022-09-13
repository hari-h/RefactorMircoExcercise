# RefactorMircoExcercise

It took approximately 3.5h to do the first two exercises. (Tire pressure And Unicode file to Html)

30-45 mins - After cloning the solution I took some time to look up the code and get familiar with the solution and read the exercises. In the beginning, I had issues with dependencies. I had to reinstall NUnit package and add new NUnit3TestAdapter, for some reason NUnit test didn't run out of the box. Also, I added the Moq package that I used for the tests. 

Also since you gave credits within your readme file to Luca Minudel I took some time to research who he is, and I found a few links/posts of people who have already finished the exercises. 

The rest of the time I was working on the refactoring. 

Below you can find some notes that I wrote while writing the code. 

#### 1. **TirePressureMonitoringSystem exercise**:
After an initial observation of the provided code, I noticed that to test the alarm properly we need to be able to set/mock/fake the sensor value which wasn't possible right away. 

In particular inside the function: 

    Alarm.Check() 

Line: 

    double psiPressureValue = _sensor.PopNextPressurePsiValue(); 

Since I choose to use Mock framework I had to create an Interface for the Sensor class, which led to the change of the Alarm class constructor.  

With these changes, I could continue with the creation of the test class and Mock/setup the sensor data which is turning the alarm on and off. 

#### 2. **UnicodeFileToHtmlTextConverter exercise**:
To test the main function ConvertToHtml inside UnicodeFileToHtmlTextConverter I had to replace the following part:

    using (TextReader unicodeFileStream = File.OpenText(_fullFilenameWithPath))

so that I can fake/mock the TextReader content without passing an actual file path. 

---

That's how far I got until now. For more info feel free to reach out to me. 
