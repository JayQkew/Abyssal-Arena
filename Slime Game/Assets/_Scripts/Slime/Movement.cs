using Stats;
using UnityEngine;

namespace Slime
{
    [RequireComponent(typeof(SoftBody))]
    public class Movement : MonoBehaviour
    {
        private SoftBody _softBody;
        private InputHandler _inputHandler;
        private PlayerStats _playerStats;

        public bool moveConsumeFuel = true;
        public bool dashConsumeFuel = true;
        public float currFuel;
        [SerializeField] private bool isInflated;
        
        [Header("Audio")]
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip inflate;
        [SerializeField] private AudioClip dash;

        private void Awake()
        {
            _softBody = GetComponent<SoftBody>();
            _inputHandler = transform.parent.GetComponent<InputHandler>();
        }

        private void Start()
        {
            _playerStats = GetComponent<SlimeStats>().Stats;
            
            currFuel = _playerStats.Fuel;
            _inputHandler.onInflate.AddListener(Inflate);
            _inputHandler.onDeflate.AddListener(Deflate);

            _inputHandler.onDash.AddListener(Dash);
        }

        private void Update()
        {
            Move(_inputHandler.moveInput);
            if (Grounded()) currFuel = _playerStats.Fuel;
            if (isInflated) _softBody.currRadius = SetSlimeRadius();
        }

        private void Move(Vector2 dir)
        {
            Vector2 constrainedDir = new Vector2(dir.x, 0);

            if (isInflated)
            {
                if (currFuel > 0 && dir != Vector2.zero)
                {
                    MoveForce(dir);
                }
                // else MoveForce(constrainedDir);
            }
            else
            {
                MoveForce(constrainedDir);
            }
        }

        private void MoveForce(Vector2 dir)
        {
            float moveMult = _playerStats.MoveSpeed;
            foreach (Rigidbody2D rb in _softBody.nodesRb)
            {
                if (rb.transform.position.y >= _softBody.transform.position.y)
                    rb.AddForce(dir * (moveMult * 100 * Time.deltaTime), ForceMode2D.Force);
                else rb.AddForce(dir * (moveMult * 50 * Time.deltaTime), ForceMode2D.Force);
            }
        }

        public void Inflate()
        {
            foreach (Rigidbody2D rb in _softBody.nodesRb)
            {
                rb.gravityScale = 0;
            }

            isInflated = true;
            _softBody.currRadius = SetSlimeRadius();
            _softBody.frequency = _playerStats.Frequency.max;
            
            audioSource.PlayOneShot(inflate);
        }

        public void Deflate()
        {
            foreach (Rigidbody2D rb in _softBody.nodesRb)
            {
                rb.gravityScale = 1;
            }

            isInflated = false;
            _softBody.currRadius = _playerStats.Radius.min;
            _softBody.frequency = _playerStats.Frequency.min;
        }

        public void Dash()
        {
            if (currFuel > 0 && _inputHandler.aimInput != Vector2.zero)
            {
                foreach (Rigidbody2D rb in _softBody.nodesRb)
                {
                    // get current velocity mag
                    // apply that mag in the movement dir
                    float magnitude = rb.linearVelocity.magnitude;
                    Vector2 newVel = magnitude * _inputHandler.aimInput;
                    rb.linearVelocity = newVel;
                    rb.AddForce(_inputHandler.aimInput * _playerStats.DashForce,
                        ForceMode2D.Impulse);
                }

                if (dashConsumeFuel) currFuel -= _playerStats.DashCost;
                
                audioSource.PlayOneShot(dash);
            }
        }

        private bool Grounded()
        {
            foreach (SoftBodyNode node in _softBody.nodeScripts)
            {
                if (node.touchingGround) return true;
            }

            return false;
        }

        public bool TouchingSurface()
        {
            foreach (SoftBodyNode node in _softBody.nodeScripts)
            {
                if (node.touchingGround || node.touchingSurface) return true;
            }

            return false;
        }

        private float SetSlimeRadius()
        {
            float minRadius = _playerStats.Radius.min;
            float radiusDiff = _playerStats.Radius.max - minRadius;
            return radiusDiff + minRadius;
        }

        public void AirRefill(float amount)
        {
            float maxFuel = _playerStats.Fuel;
            currFuel += amount;

            if (currFuel > maxFuel) currFuel = maxFuel;
        }
    }
}