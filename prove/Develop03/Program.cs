using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "C:/Users/Isaac/OneDrive/Documents/Semester 5/cse210/cse210-hw/prove/Develop03/scripture.json";  // Make sure the file is in your project directory

        if (File.Exists(filePath))
        {
            // Read the file content
            string jsonContent = File.ReadAllText(filePath);

            // Step 2: Deserialize the JSON into an object (using System.Text.Json)
            try
            {
                var scripture = JsonSerializer.Deserialize<Scripture>(jsonContent);

                // Step 3: Display the scripture
                if (scripture != null)
                {
                    scripture.DisplayScripture();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deserializing JSON: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("The file does not exist.");
        }


    }
}
