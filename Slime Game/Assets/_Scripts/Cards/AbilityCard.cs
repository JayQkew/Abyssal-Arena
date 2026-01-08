using UnityEngine;

namespace Cards
{
    [CreateAssetMenu(fileName = "NewAbilityCard", menuName = "Card/Ability")]
    public class AbilityCard : Card
    {
        public GameObject prefab;
        
        public override void Apply(Deck deck)
        {
            Transform parent = deck.abilitiesParent;
            Instantiate(prefab, parent);
        }
    }
}