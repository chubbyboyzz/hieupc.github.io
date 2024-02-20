// Enter user information
Console.WriteLine("Enter username:");
string userName = Console.ReadLine();
Console.WriteLine("User is: " + userName);

// Enter the water meter reading for the previous month
float previousMonthReading = 0;
while (previousMonthReading == 0)
{
    Console.Write("Enter the water meter reading for the previous month: ");
    string inputPreviousMonthReading = Console.ReadLine();

    if (float.TryParse(inputPreviousMonthReading, out previousMonthReading))
    {
        Console.WriteLine("Water meter reading for the previous month: " + previousMonthReading);
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter again.");
    }
}

// Enter the water meter reading for this month and check the condition
float currentMonthReading = 0;
while (currentMonthReading <= previousMonthReading)
{
    Console.Write("Enter the water meter reading for this month: ");
    string inputCurrentMonthReading = Console.ReadLine();

    if (float.TryParse(inputCurrentMonthReading, out currentMonthReading) && currentMonthReading > previousMonthReading)
    {
        Console.WriteLine("Water meter reading for this month: " + currentMonthReading);
    }
    else
    {
        Console.WriteLine("Invalid value or must be greater than the reading for the previous month. Please enter again.");
    }
}

// Calculate the water usage for this month
float waterUsed = currentMonthReading - previousMonthReading;

// Display the result
Console.WriteLine($"Water used for this month: {waterUsed}");

// Display the list of options
Console.WriteLine("List of options:\r\n" +
    "1. Household,\r\n" +
    "2. Administrative and Service Agencies,\r\n" +
    "3. Manufacturing Unit,\r\n" +
    "4. Business Service");
string userInput = Console.ReadLine();

// Process the option
switch (userInput)
{
    case "1":
        // Household
        Console.WriteLine("Enter the number of people in your household:");
        if (int.TryParse(Console.ReadLine(), out int numberOfPeople) && numberOfPeople > 0)
        {
            float averageUsage = waterUsed / numberOfPeople;

            double totalAmount;
            if (averageUsage < 10 && averageUsage > 0)
            {
                totalAmount = waterUsed * 5973;
            }
            else if (averageUsage < 30 && averageUsage >= 10)
            {
                totalAmount = waterUsed * 7052;
            }
            else if (averageUsage > 30)
            {
                totalAmount = waterUsed * 8699;
            }
            else
            {
                totalAmount = waterUsed * 15.929;
            }

            double finalTotalAmount = totalAmount + (10 / totalAmount) * 100;
            Console.WriteLine("The amount you have to pay is: " + finalTotalAmount.ToString("F2") + "VND");
        }
        else
        {
            Console.WriteLine("Invalid number of people.");
        }
        break;
    case "2":
        // Administrative and Service Agencies
        double agencyAmount = waterUsed * 9995;
        double b = agencyAmount + (10 / agencyAmount) * 100;
        Console.WriteLine("The amount your agency has to pay is: " + b.ToString("F2") + "VND");
        break;
    case "3":
        // Manufacturing Unit
        double manufacturingAmount = waterUsed * 11615;
        double c = manufacturingAmount + (10 / manufacturingAmount) * 100;
        Console.WriteLine("The amount the manufacturing unit has to pay is: " + c.ToString("F2") + "VND");
        break;
    case "4":
        // Business Service
        double businessServiceAmount = waterUsed * 22068;
        double d = businessServiceAmount + (10 / businessServiceAmount) * 100;
        Console.WriteLine("The amount for business services is: " + d.ToString("F2") + "VND");
        break;
            
    default:
        Console.WriteLine("Invalid option.");
        break;
}
