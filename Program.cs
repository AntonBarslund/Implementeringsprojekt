// Program.cs
if (args.Length == 0)
{
    Console.WriteLine("Hvilken opgave skal testes?");
    Console.WriteLine("  Opgave 1 speedtest: dotnet run 1");
    Console.WriteLine("  Opgave 2: dotnet run 2   ");
    Console.WriteLine("  Opgave 3: dotnet run 3");
    Console.WriteLine("  Opgave 4: dotnet run 4");
    return;
}

switch (args[0])
{
    case "1":
        Hashing_Tests.TestRunningTimes();
        break;
    case "2":
        Console.WriteLine("Test of the Get function");
        Opgave2_Tests.TestGet();
        Console.WriteLine("Test of set fucntion");
        Opgave2_Tests.TestSet();
        Console.WriteLine("Test of increment function");
        Opgave2_Tests.TestIncrement();
        break;
    case "3":
        Opgave2_Tests.TestSquaresum();
        break;
    default:
        Console.WriteLine("Må være en test mellem 1 - 4");
        break;
}
