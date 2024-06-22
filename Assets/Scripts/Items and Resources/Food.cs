using UnityEngine;

[CreateAssetMenu(fileName = "Food", menuName = "Items/Food")]
public class Food : Item
{
    [field: SerializeField]
    public int calorie { get; private set; }
}