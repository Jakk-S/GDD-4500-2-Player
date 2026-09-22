using UnityEngine;

public class SpriteCycle : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private Transform pivot;
    private SpriteRenderer sprRenderer;
    private int _sprCounter;

    void Awake()
    {
        sprRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        CycleSprites(sprites);
    }
        
    void CycleSprites(Sprite[] sprites)
    {
        if(sprites.Length == 0) return;
        
        float angle = pivot.eulerAngles.z;
        int segment = Mathf.FloorToInt(angle / 30) % sprites.Length;
        segment = ((segment % sprites.Length) + sprites.Length) % sprites.Length;
        if (segment != _sprCounter)
        {
            _sprCounter = segment;
            sprRenderer.sprite = sprites[_sprCounter];
        }
    }
}
