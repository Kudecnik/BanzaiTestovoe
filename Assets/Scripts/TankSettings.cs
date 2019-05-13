using UnityEngine;

[CreateAssetMenu(fileName = "TankSettings", menuName = "Tank/TankSettings", order = 1)]
public class TankSettings : ScriptableObject
{
    public int MaxHealth;
    public float Speed;
    public float RotationSpeed;
    public int Defence;
}