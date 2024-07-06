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

        public Job(PersonSample sample)
        {
            profession = sample.profession;
            skill = sample.skill;
            skillfulness = sample.skillfulness;
        }
    }
}