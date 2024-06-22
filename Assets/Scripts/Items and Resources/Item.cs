using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item", menuName = "Items/Item")]
public class Item : ScriptableObject
{
    [field: SerializeField]
    public new string name { get; private set; }
    [field: SerializeField]
    public string description { get; private set; }
    [field: SerializeField]
    public Image iconImage { get; private set; }
    [field: SerializeField]
    public int size { get; private set; }
}