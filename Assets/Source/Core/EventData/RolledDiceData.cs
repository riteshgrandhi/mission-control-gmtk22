using UnityEngine;

namespace Assets.Source.Core.EventData
{
    public class RolledDiceData
    {
        public byte Value { get; }

        public RolledDiceData( byte value)
        {
            Value = value;
        }
    }
}
