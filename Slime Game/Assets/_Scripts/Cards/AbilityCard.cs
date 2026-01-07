using UnityEngine;

namespace Cards
{
    [CreateAssetMenu(fileName = "NewAbilityCard", menuName = "Cards/Ability")]
    public class AbilityCard : Card
    {
        public new string name;
        public GameObject prefab;
        
        public override void Apply(Deck deck)
        {
            Transform parent = deck.abilitiesParent;
            Instantiate(prefab, parent);
        }
    }
}