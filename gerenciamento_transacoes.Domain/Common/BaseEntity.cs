﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace gerenciamento_transacoes.Domain.Common
{
    public abstract class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
