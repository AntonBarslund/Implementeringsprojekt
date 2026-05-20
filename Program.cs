// Program.cs
if (args.Length == 0)
{
    Console.WriteLine("Hvilken opgave skal testes?");
    Console.WriteLine("  Opgave 1: dotnet run 1");
    Console.WriteLine("  Opgave 1 speedtest: dotnet run 2");
    Console.WriteLine("  Opgave 2: dotnet run 3   ");
    return;
}

switch (args[0])
{
    case "1":
        Opgave_1_Tests.TestMultShift();
        Opgave_1_Tests.TestMultModPrime();
        break;
    case "2":
        Opgave_1_Tests.SpeedTestMultShift();
        Opgave_1_Tests.SpeedTestMultModPrime();
        break;
    case "3":
        Opgave_2.Run();
        break;
    default:
        Console.WriteLine("Må være en test mellem 1 - 3");
        break;
}
