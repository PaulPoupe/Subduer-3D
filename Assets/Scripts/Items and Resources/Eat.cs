public class Eat : AnyResource, IEat
{
    public Eat(EatSample sample) : base(sample)
    {
        calorie = sample.calorie;
    }
    public int calorie { get; private set; }
}