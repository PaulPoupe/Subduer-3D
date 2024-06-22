using System.Globalization;

public class FoodStorage : Storage<Food>
{
    public FoodStorage(int maxCapicity) : base(maxCapicity) { }

    public int GetCalorieReserve()
    {
        int calorieReserve = 0;
        foreach (var foodBox in GetShelf())
            calorieReserve += CalorieCounter(foodBox);
        return calorieReserve;
    }

    private int CalorieCounter(Box<Food> box) => box.item.calorie * box.count;
}