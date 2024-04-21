using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class Person
{
    public int position;


    private Image image;

    public string name;
    public string surename;
    public string gender;
    public int age;



    public float fatigue { get; private set; } = 100.0f;
    public float health { get; private set; } = 100.0f;
    public float comunicationSkill;

    public float mentalStability;

    public Job job;

    public Person()
    {
        System.Random random = new System.Random();
        job = new Job();
        age = random.Next(18, 48);
        comunicationSkill = random.Next(0, 5);
        mentalStability = random.Next(0, 5);
        job.profession = (Job.Profession)random.Next(0, 6);
        job.skill = (float)random.Next(0, 4);
        name = Names.mensNames[random.Next(Names.mensNames.Count)];
        surename = Names.sureNames[random.Next(Names.sureNames.Count)];
    }


}




