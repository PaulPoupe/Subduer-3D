using UnityEngine;

public class Catalog<T> : MonoBehaviour where T : Item
{
    [SerializeField]
    private T[] serializedCatalog;
    [SerializeField]


    public static T[] catalog { get; private set; }

    private void Awake()
    {
        catalog = serializedCatalog;
    }
}