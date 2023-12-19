using System.IO;
using FEngLib.Messaging;
using FEngLib.Objects;
using FEngLib.Packages;
using FEngLib.Tags;

namespace FEngLib.Chunks;

public class MessageResponsesDataChunk : FrontendObjectChunk
{
    private readonly string _logReference = "Message";

    public MessageResponsesDataChunk(IObject<ObjectData> frontendObject, HashResolver hashResolver) : base(frontendObject, hashResolver)
    {
    }

    public override IObject<ObjectData> Read(Package package, ObjectReaderState readerState, BinaryReader reader)
    {
        var tagProcessor = new MessageResponseTagProcessor();
        TagStream tagStream = new MessageTagStream(reader,
            readerState.CurrentChunkBlock.Size);

        while (tagStream.HasTag())
        {
            var tag = tagStream.NextTag();
            tagProcessor.ProcessTag(tag);
            FrontendObject.Name = HashResolver.ResolveNameHash(FrontendObject.Name, FrontendObject.NameHash, _logReference);
        }

        ResponseHelpers.PopulateMessageResponseList(tagProcessor.MessageResponseEntryList, FrontendObject);

        return FrontendObject;
    }

    public override FrontendChunkType GetChunkType()
    {
        return FrontendChunkType.MessageResponses;
    }
}