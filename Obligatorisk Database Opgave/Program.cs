

menuPicker();

static void menuPicker()
{
    bool Continue = true;
    Facility facilityCreator = new();
    while (Continue)
    {
        facilityCreator.DisplayAllFacilities();
        Console.WriteLine("Please enter a number for the option wanted");
        Console.WriteLine("1: Create new facility");
        Console.WriteLine("2: Read facility");
        Console.WriteLine("3: Update facility");
        Console.WriteLine("4: Delete facility");
        Console.WriteLine("5: Exit menu");

        int choice = Convert.ToInt32(Console.ReadLine());
        switch (choice)
        {
            case 1:
                facilityCreator.CreateFacility();
                break;
            case 2:
                facilityCreator.ReadFacility();
                break;
            case 3:
                facilityCreator.UpdateFacility();
                break;
            case 4:
                facilityCreator.DeleteFacility();
                break;
            case 5: //exit
                Continue = false;
                break;
            default:
                Console.WriteLine("Invalid number entered, try again");
                Console.ReadKey();
                break;
        }
    }
}