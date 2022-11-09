using System.Text.Json;

// Read input if needed
// Console.Write("Model: ");
// var model = Console.ReadLine();

// Make a new object to serialize to JSON
var car = new Car
{
    Make = "Rick",
    Model = "Trash Cans",
    Year = 2016,
    Owners = new List<Owner>{
        new Owner{
            FirstName = "Rick",
            LastName = "Sanchez"
        },
        new Owner{
            FirstName = "Morty",
            LastName ="Smith"
        }
    }
};

// Serialize the object above to a string to write to a file.
var jsonString = JsonSerializer.Serialize(car);

// Path.Combine will use the correct path seperator for the operating system the program is running on
// Directory.GetCurrentDirectory() will get the directory the program was executed from
var jsonDirectory = Path.Combine(Directory.GetCurrentDirectory(), "data");

// Check if the directory we want to write to exists
if (!Directory.Exists(jsonDirectory)) {
    // If not then make it
    Directory.CreateDirectory(jsonDirectory);   
}

var jsonFilePath = Path.Combine(jsonDirectory, "car.json");

// Write the json to the path above.
File.WriteAllText(jsonFilePath, jsonString);

// Read back the contents of the file we just wrote
var contents = File.ReadAllText(jsonFilePath);

// Deserialize the contents string to a Car object
var deserializedCar = JsonSerializer.Deserialize<Car>(contents);

// Car does not have a ToString() method so will write the name of the class, Car
// Use the debugger to validate the deserializedCar came through right
Console.WriteLine(deserializedCar);
