using UnityEngine;

public abstract class Item : ScriptableObject
{
    [field: SerializeField]
    public Sprite iconImage { get; protected set; }
    [field: SerializeField]
    public new string name { get; protected set; }
    [field: SerializeField, TextArea]
    public string description { get; protected set; }
    [field: SerializeField]
    public int size { get; protected set; }
}