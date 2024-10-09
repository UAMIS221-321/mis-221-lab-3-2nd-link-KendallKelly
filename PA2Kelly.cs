using System;

class Program
{
    static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Simple Menu");
            Console.WriteLine("1. Convert Units of Measure");
            Console.WriteLine("2. Rock Classification");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");

            string menu = Console.ReadLine();

            if (menu == "1")
            {
                Console.WriteLine("What unit of measurement would you like to convert? (length/mass/temperature)");
                string measurementType = Console.ReadLine().ToLower();

                if (measurementType == "mass")
                {
                    ConvertMassUnits();
                }
                else if (measurementType == "length")
                {
                    ConvertLengthUnits();
                }
                else if (measurementType == "temperature")
                {
                    ConvertTemperature();
                }
                else
                {
                    Console.WriteLine("Currently, only mass, length, and temperature conversions are supported.");
                }
            }
            else if (menu == "2")
            {
                double totalPoints = 0;

                Console.Write("Enter the number of identical rock samples found: ");
                int numberOfSamples;
                while (!int.TryParse(Console.ReadLine(), out numberOfSamples) || numberOfSamples < 0)
                {
                    Console.Write("Please enter a valid number of samples (0 or more): ");
                }
                totalPoints += numberOfSamples * 4.5;

                Console.Write("Does the rock need to be transported? (yes/no): ");
                string transportResponse = Console.ReadLine().ToLower();
                if (transportResponse == "yes")
                {
                    totalPoints += 7.3;
                }

                Console.Write("Enter the surface temperature of the rock (in degrees): ");
                double surfaceTemperature;
                while (!double.TryParse(Console.ReadLine(), out surfaceTemperature))
                {
                    Console.Write("Please enter a valid temperature: ");
                }
                if (surfaceTemperature <= 0)
                {
                    totalPoints += 9.2;
                }

                Console.Write("Enter the total weight of the rock samples (in kilograms): ");
                double totalWeight;
                while (!double.TryParse(Console.ReadLine(), out totalWeight) || totalWeight < 0)
                {
                    Console.Write("Please enter a valid weight (0 or more): ");
                }
                if (totalWeight > 25)
                {
                    totalPoints *= 1.17; // Increase by 17%
                }

                Console.WriteLine($"Total points collected: {totalPoints}");

                while (true)
                {
                    Console.Write("Would you like to adjust the score? (yes/no): ");
                    string adjustResponse = Console.ReadLine().ToLower();
                    if (adjustResponse == "no") break;

                    Console.Write("Enter the amount to adjust (positive to increase, negative to decrease): ");
                    double adjustmentAmount;
                    while (!double.TryParse(Console.ReadLine(), out adjustmentAmount))
                    {
                        Console.Write("Please enter a valid adjustment amount: ");
                    }

                    if (Math.Abs(adjustmentAmount) > totalPoints)
                    {
                        Console.WriteLine("Error: Adjustment amount exceeds current total points. Please try again.");
                        continue;
                    }

                    totalPoints += adjustmentAmount;
                    Console.WriteLine($"Updated total points: {totalPoints}");
                    Console.WriteLine($"Points adjusted by: {adjustmentAmount}");
                }

                Console.WriteLine("Final total points: " + totalPoints);
            }
            else if (menu == "3")
            {
                Console.WriteLine("Exiting...");
                exit = true; // Exit the loop
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
            }

            Console.WriteLine("Press Enter key to continue...");
            Console.ReadKey();
        }
    }

    public static void ConvertMassUnits()
    {
        while (true)
        {
            Console.Write("Enter value to convert (or type 'exit' to quit): ");
            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
            {
                break;
            }

            if (!double.TryParse(input, out double value))
            {
                Console.WriteLine("Invalid input. Please enter a numeric value.");
                continue;
            }

            Console.Write("What unit is this value in? (g/kg/lbs): ");
            string fromUnit = Console.ReadLine().ToLower();

            Console.Write("What unit do you want to convert to? (g/kg/lbs): ");
            string toUnit = Console.ReadLine().ToLower();

            if (IsValidMassUnit(fromUnit) && IsValidMassUnit(toUnit))
            {
                double convertedValue = ConvertMass(value, fromUnit, toUnit);
                Console.WriteLine($"Converted value: {convertedValue} {toUnit}");
            }
            else
            {
                Console.WriteLine("Invalid mass unit. Use g, kg, or lbs.");
            }

            Console.WriteLine(); 
        }
    }

    public static void ConvertLengthUnits()
    {
        while (true)
        {
            Console.Write("Enter value to convert (or type 'exit' to quit): ");
            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
            {
                break;
            }

            if (!double.TryParse(input, out double value))
            {
                Console.WriteLine("Invalid input. Please enter a numeric value.");
                continue;
            }

            Console.Write("Convert from (mm/cm/m/km/in/yd): ");
            string fromUnit = Console.ReadLine().ToLower();

            Console.Write("Convert to (mm/cm/m/km/in/yd): ");
            string toUnit = Console.ReadLine().ToLower();

            if (IsValidLengthUnit(fromUnit) && IsValidLengthUnit(toUnit))
            {
                double convertedValue = ConvertLength(value, fromUnit, toUnit);
                Console.WriteLine($"Converted value: {convertedValue} {toUnit}");
            }
            else
            {
                Console.WriteLine("Invalid length unit. Use mm, cm, m, km, in, or yd.");
            }

            Console.WriteLine(); 
        }
    }

    public static void ConvertTemperature()
    {
        Console.WriteLine("Enter the temperature value:");

        if (double.TryParse(Console.ReadLine(), out double temp))
        {
            Console.WriteLine("Do you want to convert to Celsius or Fahrenheit? (Enter 'C' or 'F')");
            string scale = Console.ReadLine();

            if (scale.Equals("C", StringComparison.OrdinalIgnoreCase) || scale.Equals("F", StringComparison.OrdinalIgnoreCase))
            {
                double convertedTemp = ConvertTemperatureValue(temp, scale);
                Console.WriteLine($"Converted temperature: {convertedTemp} degrees {scale.ToUpper()}");
            }
            else
            {
                Console.WriteLine("Invalid scale. Use 'C' for Celsius or 'F' for Fahrenheit.");
            }
        }
        else
        {
            Console.WriteLine("Invalid temperature input. Please enter a numeric value.");
        }
    }

    public static double ConvertTemperatureValue(double temp, string scale)
    {
        if (scale.Equals("C", StringComparison.OrdinalIgnoreCase))
        {
            // Convert Fahrenheit to Celsius
            return (temp - 32) * 5 / 9;
        }
        else if (scale.Equals("F", StringComparison.OrdinalIgnoreCase))
        {
            // Convert Celsius to Fahrenheit
            return (temp * 9 / 5) + 32;
        }
        return temp; 
    }

    public static double ConvertMass(double value, string fromUnit, string toUnit)
    {
        double valueInGrams = 0;

        if (fromUnit == "g")
        {
            valueInGrams = value;
        }
        else if (fromUnit == "kg")
        {
            valueInGrams = value * 1000;
        }
        else if (fromUnit == "lbs")
        {
            valueInGrams = value / 0.00220462;
        }
        else
        {
            Console.WriteLine("Invalid fromUnit. Use g, kg, or lbs.");
            return value;  
        }

        if (toUnit == "g")
        {
            return valueInGrams;
        }
        else if (toUnit == "kg")
        {
            return valueInGrams / 1000;
        }
        else if (toUnit == "lbs")
        {
            return valueInGrams * 0.00220462;
        }
        else
        {
            Console.WriteLine("Invalid toUnit. Use g, kg, or lbs.");
            return value; 
        }
    }

    public static double ConvertLength(double value, string fromUnit, string toUnit)
    {
        double valueInMeters = 0;

        if (fromUnit == "mm")
        {
            valueInMeters = value / 1000; // Milli to meters
        }
        else if (fromUnit == "cm")
        {
            valueInMeters = value / 100; // Centi to meter
        }
        else if (fromUnit == "m")
        {
            valueInMeters = value; // Meter
        }
        else if (fromUnit == "km")
        {
            valueInMeters = value * 1000; // Kilo to m
        }
        else if (fromUnit == "in")
        {
            valueInMeters = value * 0.0254; // in to meters
        }
        else if (fromUnit == "yd")
        {
            valueInMeters = value * 0.9144; // yds to meters
        }
        else
        {
            Console.WriteLine("Invalid fromUnit. Use mm, cm, m, km, in, or yd.");
            return value;
        }

        if (toUnit == "mm")
        {
            return valueInMeters * 1000; // Convert meters to mm
        }
        else if (toUnit == "cm")
        {
            return valueInMeters * 100; // Convert meters to cm
        }
        else if (toUnit == "m")
        {
            return valueInMeters; // Already in meters
        }
        else if (toUnit == "km")
        {
            return valueInMeters / 1000; // Convert meters to km
        }
        else if (toUnit == "in")
        {
            return valueInMeters / 0.0254; // Convert meters to inches
        }
        else if (toUnit == "yd")
        {
            return valueInMeters / 0.9144; // Convert meters to yards
        }
        else
        {
            Console.WriteLine("Invalid toUnit. Use mm, cm, m, km, in, or yd.");
            return value;
        }
    }

    public static bool IsValidMassUnit(string unit)
    {
        return unit == "g" || unit == "kg" || unit == "lbs";
    }

    public static bool IsValidLengthUnit(string unit)
    {
        return unit == "mm" || unit == "cm" || unit == "m" || unit == "km" || unit == "in" || unit == "yd";
    }
}











