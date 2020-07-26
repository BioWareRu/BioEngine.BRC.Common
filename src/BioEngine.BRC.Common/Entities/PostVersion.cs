using System;
using System.ComponentModel.DataAnnotations.Schema;
using BioEngine.BRC.Common.Components;
using BioEngine.BRC.Common.Entities.Abstractions;
using Newtonsoft.Json;

namespace BioEngine.BRC.Common.Entities
{
    [Table("PostVersions")]
    [Entity("postversion")]
    public class PostVersion : BaseEntity
    {
        public Guid ContentId { get; set; }
        [Column(TypeName = "jsonb")] public string Data { get; set; }

        public string ChangeAuthorId { get; set; }

        public void SetContent(IContentItem contentItem)
        {
            Data = JsonConvert.SerializeObject(contentItem,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore, TypeNameHandling = TypeNameHandling.Auto
                });
        }

        public IContentItem? GetContent()
        {
            return JsonConvert.DeserializeObject<IContentItem>(Data,
                new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead
                });
        }

        public T? GetContent<T>() where T : Post
        {
            return JsonConvert.DeserializeObject<T>(Data,
                new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead
                });
        }
    }
}
