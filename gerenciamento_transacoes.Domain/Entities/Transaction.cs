using gerenciamento_transacoes.Domain.Common;
using MongoDB.Bson.Serialization.Attributes;

namespace gerenciamento_transacoes.Domain.Entities
{
    public sealed class Transaction : BaseEntity
    {
        [BsonElement("value")]
        public double Value { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("nameSender")]
        public string NameSender { get; set; }

        [BsonElement("nameReceiver")]
        public string NameReceiver { get; set; }

        [BsonElement("dateTime")]
        public DateTime Date { get; set; }
    }
}
