using UnityEngine;

namespace Abilities
{
    public class ShootLogic : MonoBehaviour
    {
        public Shoot data;

        public void Fire()
        {
            GameObject bullet = Instantiate(data.bulletPrefab, transform.position, transform.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            
            
        }
    }
}
