using UnityEngine;
using System.Collections;
using VInspector;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Sprite[] weaponSprites;
    [SerializeField] private SpriteRenderer sprRenderer;
    public bool RotateRight { get; set; } = true;
    [SerializeField] private Weapon _weapon;
    
    
    private int rotateDir = 1;
    private int sprCounter = 0;
    
    void Start()
    {
        StartCoroutine(ChangeSprite());
    }
    void Update()
    {
        
        if (RotateRight && rotateDir == 1)
        {
            rotateDir = -1;
            sprRenderer.flipX = false;
        }
        else if (!RotateRight && rotateDir == -1)
        {
            rotateDir = 1;
            sprRenderer.flipX = true;
        }
        
        transform.Rotate(0, 0, Time.deltaTime * rotateDir * _weapon.rotationSpeed);
    }
    
    IEnumerator ChangeSprite()
    {
        while (true)
        {
            sprCounter++;
            if (sprCounter > 11)
            {
                sprCounter = 0;
            }
            sprRenderer.sprite = weaponSprites[sprCounter];
            yield return new WaitForSeconds(360f/(weaponSprites.Length * _weapon.rotationSpeed));
        }
    }
}
