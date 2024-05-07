namespace QuestSystem
{
    public enum Profession
    {
        Scientist,
        Captain,
        Navigator,
        Cook,
        Engineer,
        Firefighter,
        Doctor,
        Diver,
    }

    public class Job
    {
        public Profession profession;
        public float skill;
        public float skillfulness;

        public Job()
        {
            System.Random random = new System.Random();
            profession = (Profession)random.Next(0, 6);
            skill = random.Next(0, 10);
            skillfulness = random.Next(0, 3);
        }
    }
}