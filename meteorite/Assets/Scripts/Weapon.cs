using UnityEngine;
[System.Serializable]
public enum WeaponTypes
{
    MG, 
    RG,
    PS
}
public abstract class Weapon : ScriptableObject
{
    //stats
    public float damage;
    public uint maxAmmo;
    public float fireRate;
    public float reloadTime;
    public WeaponTypes type;
    public GameObject projectilePrefab;
    public abstract void fireWeapon(PlayerController controller);

}
