using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Facility
{
    DBClient dBClient = new();

    public void CreateFacility()
    {
        Console.Clear();
        Console.WriteLine("Creating new facility");
        Console.WriteLine("Please enter name for the facility");
        string facilityName = Console.ReadLine();
        string queryString = $"INSERT INTO FacilityT VALUES ('{facilityName}')";
        dBClient.Start(queryString);
        Console.WriteLine($"Created Facility: {facilityName}");
        DisplayAllFacilities();
        Next();
    }

    public void ReadFacility()
    {
        Console.Clear();
        DisplayAllFacilities();
        Console.WriteLine("Please enter the number for the facility you want to see");
        int facilityNo = Convert.ToInt32(Console.ReadLine());
        string queryString = $"SELECT * FROM FacilityT WHERE FacilityId = {facilityNo}";
        dBClient.Start(queryString);
        Next();
    }

    public void UpdateFacility()
    {
        Console.Clear();
        Console.WriteLine("Update existing facility");
        DisplayAllFacilities();
        Console.WriteLine("Please enter number for the facility to be updated");
        int facilityId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Please enter a new name for the facility");
        string facilityName = Console.ReadLine();
        string queryString = $"UPDATE FacilityT SET FacilityType = '{facilityName}' WHERE facilityId = {facilityId}";
        dBClient.Start(queryString);
        Console.WriteLine($"Updated Facility: {facilityId}, {facilityName}");
        Next();
    }

    public void DeleteFacility()
    {
        Console.Clear();
        Console.WriteLine("Delete existing facility");
        DisplayAllFacilities();
        Console.WriteLine("Please enter a number for the facility to be deleted");
        int facilityId = Convert.ToInt32(Console.ReadLine());
        string queryString = $"DELETE FROM FacilityT WHERE FacilityId = {facilityId}";
        dBClient.Start(queryString);
        Console.WriteLine($"Deleted Facility: {facilityId}");
        Next();
    }

    public void DisplayAllFacilities()
    {
        Console.Clear();
        string displayAllFacilities = "SELECT * FROM FacilityT";
        dBClient.Start(displayAllFacilities);
        Console.WriteLine();
    }

    static void Next()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }
}

