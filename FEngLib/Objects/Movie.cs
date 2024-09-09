namespace FEngLib.Objects;

public class Movie : BaseObject
{
    public Movie(ObjectData data) : base(data)
    {
    }

    public override ObjectType GetObjectType()
    {
        return ObjectType.Movie;
    }

	public override object Clone()
	{
		var result = new Movie(null);

		result.InternalClone(this);

		return result;
	}

	public override void InitializeData()
    {
        Data = new ObjectData();
    }
}
