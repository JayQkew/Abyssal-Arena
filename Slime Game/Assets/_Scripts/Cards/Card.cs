using System.Collections.Generic;
using UnityEngine;

namespace Cards
{
    public abstract class Card: ScriptableObject
    {
        public new string name;
        public string description;
        public Sprite icon;

        public abstract void Apply(Deck deck);
    }
}
