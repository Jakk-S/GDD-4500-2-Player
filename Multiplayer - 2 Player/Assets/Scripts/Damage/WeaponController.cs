using UnityEngine;

namespace Damage
{
    public enum RotationType {SpeedDependent, NonSpeedDependent}
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer sprRenderer;
        [SerializeField] private Weapon weapon;
        [SerializeField] private RotationType rotateType =  RotationType.SpeedDependent;
         public bool rotateRight = true;
    
        private Rigidbody2D _rbBall;
        private float _rSpeed;
        private int _rotateDir = 1;
        private int _sprCounter;

        void Awake()
        {
            ChangeDirection();
            _rbBall = gameObject.GetComponentInParent<Rigidbody2D>();
            weapon.SetOwner(gameObject);
        }
    
        void Update()
        {
            switch (rotateType)
            {
                case RotationType.SpeedDependent:
                    _rSpeed = weapon.rotSpeed * _rbBall.linearVelocity.magnitude;
                    _rSpeed = Mathf.Clamp(_rSpeed, 0, weapon.rotSpeed * 10);
                    break;
                case RotationType.NonSpeedDependent:
                    _rSpeed = weapon.rotSpeed;
                    break;
            }
        
            transform.Rotate(0, 0, Time.deltaTime * _rotateDir * _rSpeed);

            CycleSprites(weapon.weaponSpr);
        }

        public void ChangeDirection()
        {
            Vector3 scale =  transform.localScale;
            if (rotateRight && _rotateDir == 1)
            {
                _rotateDir = -1;
                scale.x = 1;
            }
            else if (!rotateRight && _rotateDir == -1)
            {
                _rotateDir = 1;
                scale.x = -1;
            }

            transform.localScale = scale;
        }
        void CycleSprites(Sprite[] sprites)
        {
            float angle = transform.eulerAngles.z;
            int segment = Mathf.FloorToInt(angle / 30) % sprites.Length;
            if (segment != _sprCounter)
            {
                _sprCounter = segment;
                sprRenderer.sprite = sprites[_sprCounter];
            }
        }
    }
}