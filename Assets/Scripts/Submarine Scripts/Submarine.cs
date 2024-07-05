using UnityEngine;

public class Submarine : MonoBehaviour
{
    private Tank oxigenTank;
    private Tank fuelTank;
    private Tank purifiedWater;
    private FoodStorage foodStorage;

    public void Initialize()
    {
        oxigenTank = new Tank(100, ResourceCatalog.GetCatalog()["Oxigen"], 50);
        fuelTank = new Tank(100, ResourceCatalog.GetCatalog()["Fuel"], 50);
        purifiedWater = new Tank(100, ResourceCatalog.GetCatalog()["Purified water"], 65);
        foodStorage = new FoodStorage(1000);
    }
}