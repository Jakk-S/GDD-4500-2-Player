using UnityEngine;
using System.Collections;
public class WeaponController : MonoBehaviour
{
    [SerializeField] private Sprite[] weaponSprites;
    [SerializeField] private SpriteRenderer sprRenderer;
    [SerializeField] private bool RotateRight = true;
    [SerializeField] private float rotSpeed = 1;
    private int rotateDir = 1;
    private int sprCounter = 0;

    void Start()
    {
        StartCoroutine(ChangeSprite());
        rotSpeed *= 100;
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
        
        transform.Rotate(0, 0, Time.deltaTime * rotateDir * rotSpeed);
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
            yield return new WaitForSeconds(30/rotSpeed);
        }
    }
}
