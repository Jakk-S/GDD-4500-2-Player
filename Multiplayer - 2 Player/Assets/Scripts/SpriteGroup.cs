using UnityEngine;

[ExecuteAlways]
public class SpriteGroup : MonoBehaviour
{
    [Range(0f, 1f)] [SerializeField] private float alpha = 1f;

    private SpriteRenderer[] renderers;
    
    //Being accessible from other scripts
    public float Alpha
    {
        get => alpha;
        set
        {
            alpha = Mathf.Clamp01(value);
            Apply();
        }
    }

    private void OnEnable()
    {
        CacheRenderers();
        Apply();
    }

    //apply when changes in inspector
    private void OnValidate()
    {
        CacheRenderers();
        Apply();
    }

    //Find all children with Sprite Renderer
    private void CacheRenderers()
    {
        renderers = GetComponentsInChildren<SpriteRenderer>(true);
    }
    
    //loop that makes all colors in sprite renderer to have the same alpha
    void Apply()
    {
        if (renderers == null) return;

        foreach (var r in renderers)
        {
            if (r == null) continue;
            Color c = r.color;
            c.a = alpha;
            r.color = c;
        }
    }
}
