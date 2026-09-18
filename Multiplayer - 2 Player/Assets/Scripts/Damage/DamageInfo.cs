using UnityEngine;

public enum DamageType{Physical, Fire, Poison}
public class DamageInfo
{
    public float Amount;
    public DamageType Type;
    public GameObject Source;
    public Vector3 HitPoint;
    public Vector3 HitDirection;
    public bool isCritical;
}
