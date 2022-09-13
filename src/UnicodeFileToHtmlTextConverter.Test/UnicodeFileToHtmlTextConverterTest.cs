using Moq;
using NUnit.Framework;
using System;
using System.IO;
using System.Text;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter.Test
{
    /// <summary>
    /// 2. UnicodeFileToHtmlTextConverter exercise:
    /// Write the unit tests for the UnicodeFileToHtmlTextConverter class, refactor the code as much as you need to make the class testable.
    /// The UnicodeFileToHtmlTextConverter class is designed to reformat a plain text file for display in a browser.
    /// </summary>
    [TestFixture]
    public class UnicodeFileToHtmlTextConverterTest
    {
        [Test]
        public void should_convert_ampersand()
        {
            // Arrange
            var textReader = new Mock<StreamReader>();
            string fakeFileContents = "Bosnia & Herzegovina";
            byte[] fakeFileBytes = Encoding.UTF8.GetBytes(fakeFileContents);
            MemoryStream fakeMemoryStream = new MemoryStream(fakeFileBytes);
            
            var mockSource = new Mock<ITextSource>();
            
            mockSource.Setup(r => r.GetTextReader())
                      .Returns(new StreamReader(fakeMemoryStream));

            var textConverter = new UnicodeFileToHtmlTextConverter(mockSource.Object);
            // Act
            var html = textConverter.ConvertToHtml();
            // Assert
            Assert.AreEqual(html, "Bosnia &amp; Herzegovina<br />");

        }

    }
}
