using HelloWorld; // Ensure this is the correct namespace for the Program class
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Reflection;
using System.Text.RegularExpressions;

namespace HelloWorldTest
{
    public class UnitTest1
    {


        //Harjoitus - PeruslaskutNumeromuuttujilla
        [Fact]
        [Trait("TestGroup", "NumeromuuttujatDouble")]
        public void NumeromuuttujatDouble()
        {
            // Arrange
            using var sw = new StringWriter();
            Console.SetOut(sw);


            // Set a timeout of 30 seconds for the test execution
            var cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(30));

            try
            {
                // Act
                Task task = Task.Run(() =>
                {
                    // Run the program
                    HelloWorld.Program.Main(new string[0]);
                }, cancellationTokenSource.Token);

                task.Wait(cancellationTokenSource.Token);  // Wait for the task to complete or timeout

                // Get the output that was written to the console
                var result = sw.ToString().TrimEnd(); // Trim only the end of the string

                var resultLines = result.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

              Assert.True(LineContainsIgnoreSpaces(resultLines[0], "Peruslaskujen tulokset:"),
    $"Expected: 'Peruslaskujen tulokset:' but got: '{resultLines[0]}'");

Assert.True(LineContainsIgnoreSpaces(resultLines[1], "57,75"),
    $"Expected: '57,75' but got: '{resultLines[1]}'");

Assert.True(LineContainsIgnoreSpaces(resultLines[2], "16"),
    $"Expected: '16' but got: '{resultLines[2]}'");

Assert.True(LineContainsIgnoreSpaces(resultLines[3], "5"),
    $"Expected: '5' but got: '{resultLines[3]}'");

Assert.True(LineContainsIgnoreSpaces(resultLines[4], "1,9090909"),
    $"Expected: '1,9090909' but got: '{resultLines[4]}'");
            }
            catch (OperationCanceledException)
            {
                Assert.True(false, "The operation was canceled due to timeout.");
            }
            catch (AggregateException ex) when (ex.InnerException is OperationCanceledException)
            {
                Assert.True(false, "The operation was canceled due to timeout.");
            }
            finally
            {
                cancellationTokenSource.Dispose();
            }
        }
        private bool LineContainsIgnoreSpaces(string line, string expectedText)
        {
            // Remove all whitespace from the line and the expected text
            string normalizedLine = Regex.Replace(line, @"\s+", "");
            string normalizedExpectedText = Regex.Replace(expectedText, @"\s+", "");
            return normalizedLine.Contains(normalizedExpectedText);
        }

        private int CountWords(string line)
        {
            return line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        private bool LineContainsIgnoreSpaces(string actualLine, string expectedLine)
{
    // Normalize spaces
    actualLine = actualLine.Replace(" ", "").ToLower();
    expectedLine = expectedLine.Replace(" ", "").ToLower();

    // Normalize decimal separators (replace commas with periods)
    actualLine = actualLine.Replace(',', '.');
    expectedLine = expectedLine.Replace(',', '.');

    // Check if the actual line contains the expected line
    return actualLine.Contains(expectedLine);
}


        private bool CompareLines(string[] actualLines, string[] expectedLines)
        {
            if (actualLines.Length != expectedLines.Length)
            {
                return false;
            }

            for (int i = 0; i < actualLines.Length; i++)
            {
                if (actualLines[i] != expectedLines[i])
                {
                    return false;
                }
            }

            return true;
        }

    }
}



