using FantasyGame.Extensions;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FantasyGameTests.ExtensionsTests;

[TestFixture]
public class ModelStateDictionaryExtensionsTests
{
    [Test]
    public void GetErrors_NoErrors_ReturnsEmptyString()
    {
        // Arrange
        ModelStateDictionary modelState = new();
        List<string> expectedResult = [];

        // Act
        List<string> errors = modelState.GetErrors();

        // Assert
        Assert.That(errors, Is.EqualTo(expectedResult));
    }

    [Test]
    public void GetErrors_SingleError_ReturnsSingleErrorMessage()
    {
        // Arrange
        ModelStateDictionary modelState = new();
        modelState.AddModelError("field1", "message1");

        List<string> expectedResult = ["message1"];

        // Act
        List<string> errors = modelState.GetErrors();

        // Assert
        Assert.That(errors, Is.EqualTo(expectedResult));
    }

    [Test]
    public void GetErrors_MultipleErrors_ReturnsConcatenatedErrorMessages()
    {
        // Arrange
        ModelStateDictionary modelState = new();
        modelState.AddModelError("field1", "message1");
        modelState.AddModelError("field2", "message2");
        modelState.AddModelError("field3", "message3");

        List<string> expectedResult = ["message1", "message2", "message3"];

        //Act
        List<string> errors = modelState.GetErrors();

        // Assert
        Assert.That(errors, Is.EqualTo(expectedResult));
    }
}
