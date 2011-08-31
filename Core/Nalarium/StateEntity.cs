using System;

namespace Nalarium
{
    public class StateEntity
    {
        //- @SerializerName -//
        public String SerializerName { get; set; }

        //- @StateFormatType -//
        public Type StateFormatType { get; set; }

        //- @SerializerPair -//
        public SerializerPair SerializerPair { get; set; }

        //- @StateMode -//
        public StateMode StateMode { get; set; }

        //- @Value -//
        public Value Value { get; set; }
    }
}