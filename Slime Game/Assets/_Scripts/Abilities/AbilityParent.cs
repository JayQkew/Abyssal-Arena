using UnityEngine;

namespace Abilities
{
    public class AbilityParent : MonoBehaviour
    {
        [SerializeField] private SoftBody softBody;
        
        
        void Update()
        {
            transform.position = softBody.transform.position;
        }
    }
}
