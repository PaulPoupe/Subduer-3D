using UnityEngine.UI;

public abstract class AnyResource
{
    protected AnyResource(AbstractResurceSample sample)
    {
        name = sample.Name;
        description = sample.Description;
        iconImage = sample.IconImage;
        size = sample.Size;
    }

    public string name { get; protected set; }
    public string description { get; protected set; }
    public Image iconImage { get; protected set; }
    public int size { get; protected set; }
}