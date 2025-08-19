/*
See: https://www.thecsharpacademy.com/project/53/math-game
- Create a Math game containing the 4 basic operations
  - Game will generate 5 math exercises based on the operation chosen
  - User will have to calculate the answser and enter it in for each question
  - At the end of the questions, program outputs the results and gives score (ex: "x/5 correct")
- The divisions should result in INTEGERS ONLY and dividends should go from 0 to 100. 
  - Example: Your app shouldn't present the division 7/2 to the user, since it doesn't result in an integer.
- Users should be presented with a menu to choose an operation
- Record previous games in a List
  - provide an option in the menu for the user to visualize a history of previous games.
- Do not persist results; results are to be delted once the program is closed
*/

using System;

namespace MathGame;

class Program
{
  const string MENU = """
  Math Game!
    1. Addition
    2. Subtraction
    3. Multiplication
    4. Division
  """;
  static void Main(string[] args)
  {
    Console.WriteLine("Hello World!");
    GameLoop();
  }

  static void GameLoop()
  {
    while (true)
    {
      Console.WriteLine(MENU);
      Console.Write("\nSelect option: ");
      var menuInput = Console.ReadLine();
      if (string.IsNullOrWhiteSpace(menuInput))
      {
        Console.WriteLine("No choice selected, try again!");
      }
      else if (menuInput.ToUpper().StartsWith('A') || menuInput.StartsWith('1'))
      {
        Console.WriteLine("Addition selected!");
      }
      else if (menuInput.ToUpper().StartsWith('S') || menuInput.StartsWith('2'))
      {
        Console.WriteLine("Subtraction selected!");
      }
      else if (menuInput.ToUpper().StartsWith('M') || menuInput.StartsWith('3'))
      {
        Console.WriteLine("Multiplication selected!");
      }
      else if (menuInput.ToUpper().StartsWith('D') || menuInput.StartsWith('4'))
      {
        Console.WriteLine("Division selected!");
      }
      else if (menuInput.ToUpper().StartsWith('Q'))
      {
        Console.WriteLine($"Entered in {menuInput}");
      }
      else
      {
        Console.WriteLine("\nInvalid input, please try again!");
      }

      Console.WriteLine();
    }
  }

  static (int, int) GenerateRandomGameNumbers()
  {
    Random random = new();
    return (random.Next(100) + 1, random.Next(100) + 1);
  }

  static (string exercise, int answer) GenerateAdditionExercise()
  {
    var nums = GenerateRandomGameNumbers();
    var exercise = $"{nums.Item1} + {nums.Item2} = ?";
    var answer = nums.Item1 + nums.Item2;
    return (exercise, answer);
  }

  static void CheckAnswer(string rawInput, int answer)
  {
    int input;

    try
    {
      input = int.Parse(rawInput);
    }
    catch (Exception e) when (e is FormatException || e is OverflowException)
    {
      Console.WriteLine("Invalid input entereed, please try again!");
      return;
    }

    if (input == answer)
    {
      Console.WriteLine("Correct!");
      return;
    }

    Console.WriteLine("Incorrect answer entered");
    return;
  }

  enum O
  {
    MATH,
    SUBTRACTION,
    MULTIPLICATION,
    DIVISION
  }
}

