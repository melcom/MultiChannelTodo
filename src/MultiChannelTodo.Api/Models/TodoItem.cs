using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiChannelTodo.Api.Models
{
    public class TodoItem
    {
        public TodoItem()
        {
            CreatedAt = DateTimeOffset.UtcNow;
            UpdatedAt = DateTimeOffset.UtcNow;
        }

        public ObjectId Id { get; set; }

        [BsonElement("text")]
        public string Text { get; set; }

        [BsonElement("complete")]
        public bool Complete { get; set; }

        [BsonElement("createdat")]
        public DateTimeOffset? CreatedAt { get; set; }

        [BsonElement("updatedat")]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}