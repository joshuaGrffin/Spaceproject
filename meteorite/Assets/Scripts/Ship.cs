using UnityEngine;
[CreateAssetMenu(fileName = "ShipDef", menuName = "CreateShip/ShipDef")]
public class Ship : ScriptableObject
{
    public Mesh mesh;
    public Material material;
    //Weapons here (max 3?) 
    public Weapon[] weapons; 
    #region stats
    public float health;
    public float mass;
    public float thrustForce;
    #endregion 
}
