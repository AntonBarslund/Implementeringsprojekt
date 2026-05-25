// Program.cs
if (args.Length == 0) {
    Console.WriteLine("Hvilken opgave skal testes?");
    Console.WriteLine("  Opgave 1: dotnet run 1");
    Console.WriteLine("  Opgave 1 speedtest: dotnet run 2");
    Console.WriteLine("  Opgave 2: dotnet run 3   ");
    Console.WriteLine("  Opgave 3: dotnet run 4");
    Console.WriteLine("  Opgave 4: dotnet run 5");
    return;
}

switch (args[0]) {
    case "1":
        Opgave_1_Tests.TestMultShift();
        Opgave_1_Tests.TestMultModPrime();
        break;
    case "2":
        Opgave_1_Tests.SpeedTestMultShift();
        Opgave_1_Tests.SpeedTestMultModPrime();
        break;
    case "3":
        Console.WriteLine("Test of the Get function");
        Opgave2_Tests.TestGet();
        Console.WriteLine("Test of set fucntion");
        Opgave2_Tests.TestSet();
        Console.WriteLine("Test of increment function");
        Opgave2_Tests.TestIncrement();
        break;
    case "4":
        Opgave2_Tests.TestSquaresum();
        break;
    case "5":
        Opgave_4_Tests.TestAlg1();
        Opgave_4_Tests.TestBSC_init();
        break;
    default:
        Console.WriteLine("Må være en test mellem 1 - 4");
        break;
}
