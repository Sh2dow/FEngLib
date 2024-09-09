namespace FEngLib.Objects;

public class SimpleImage : BaseObject
{
    public SimpleImage(ObjectData data) : base(data)
    {
    }

    public override ObjectType GetObjectType()
    {
        return ObjectType.SimpleImage;
    }

	public override object Clone()
	{
		var result = new SimpleImage(null);

		result.InternalClone(this);

		return result;
	}

	public override void InitializeData()
    {
        Data = new ObjectData();
    }
}
