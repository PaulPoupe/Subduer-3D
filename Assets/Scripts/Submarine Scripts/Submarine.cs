using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submarine : MonoBehaviour
{
    const int foodStorageMaxCapicity = 1000;



    public LimitedBox<Resource> oxigen = new LimitedBox<Resource>();
    public LimitedBox<Resource> fuel = new LimitedBox<Resource>();
    public LimitedBox<Resource> charge = new LimitedBox<Resource>();
    public LimitedBox<Resource> purifiedWater = new LimitedBox<Resource>();
    public foodStorage foodStorage = new foodStorage(foodStorageMaxCapicity);

}
