using UnityEngine;
using UnityEngine.UI;


public abstract class Item : ScriptableObject
{
    [field: SerializeField]
    public Image iconImage { get; private set; }
    [field: SerializeField]
    public new string name { get; private set; }
    [field: SerializeField, TextArea]
    public string description { get; private set; }
    [field: SerializeField]
    public int size { get; private set; }
}