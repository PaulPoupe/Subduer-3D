using System.Collections.Generic;
using UnityEngine;

public class Catalog<T> : MonoBehaviour where T : Item
{
    [SerializeField]
    protected T[] serializedCatalog;

    private static Dictionary<string, T> catalog = new Dictionary<string, T>();

    private void Awake()
    {
        FillDictionary();
    }

    protected void FillDictionary()
    {
        foreach (var item in serializedCatalog)
        {
            catalog.Add(item.name, item);
        }
    }

    public static IReadOnlyDictionary<string, T> GetCatalog() => catalog;
}