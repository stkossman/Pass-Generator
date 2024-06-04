using PassGen;

Console.WriteLine("1. Include capital letters");
Console.WriteLine("2. Include lower letters");
Console.WriteLine("3. Include digits");
Console.WriteLine("4. Include special characters");
Console.WriteLine("Enter numbers separated by spaces to choose options (like '1 3 4'):");

string enter =  Console.ReadLine();
bool includeCapital = false;
bool includeLower = false;
bool includeDigits = false;
bool includeSpecial = false;

string[] choices = enter.Split(' ');

foreach(string choice in choices)
{
    int opt;
    if(int.TryParse(choice, out opt))
    {
        switch (opt)
        {
            case 1:
                includeCapital = true;
                break;
            case 2:
                includeLower = true; 
                break;
            case 3:
                includeDigits = true;
                break;
            case 4:
                includeSpecial = true;
                break;
            default:
                Console.WriteLine("Invalid option");
                break;
        }
    }
    else
    {
        Console.WriteLine("Invalid input");
    }
}

PassEx passEx = new PassEx(includeCapital, includeLower, includeDigits, includeSpecial);

Console.WriteLine("Enter password length:");
int passLen;
if (!int.TryParse(Console.ReadLine(), out passLen))
{
    Console.WriteLine("Invalid password length. Using default length (15).");
    passLen = 15;
}

string pass = passEx.GeneratePassword(passLen);
int strength = passEx.CalculateStrength(pass);
string level = passEx.GetLevel(strength);
Console.WriteLine($"Suggested password: {pass}");
Console.WriteLine($"Password's strength = {strength} ({level})");