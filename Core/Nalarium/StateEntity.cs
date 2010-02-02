using System;
//+
namespace Nalarium
{
    public class StateEntity
    {
        public String SerializerName { get; set; }

        public Type StateFormatType { get; set; }

        public SerializerPair SerializerPair { get; set; }

        public StateMode StateMode { get; set; }

        public Value Value { get; set; }
    }
}