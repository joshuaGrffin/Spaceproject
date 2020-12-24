using UnityEngine;
[CreateAssetMenu(fileName = "ShipDef", menuName = "CreateShip/ShipDef")]
public class Ship : ScriptableObject
{
    //used by displayer
    public GameObject prefab;

    public GameObject[] automaticKeneticWeaponBarrels;
    public GameObject plasmaWeaponBarrel;
    public GameObject chargedWeaponBarrel;

    //Weapons here used by controllers
    public Weapon[] weapons; 
    #region stats
    public float health;
    public float mass;
    public float thrustForce;
    #endregion 
}
