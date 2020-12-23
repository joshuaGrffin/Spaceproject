using UnityEngine;
[CreateAssetMenu(fileName ="Railgun", menuName ="CreateWeapon/Railgun")]
public class RailGun : Weapon
{
    public override void fireWeapon(PlayerController controller)
    {
        controller.ShootRailGun();   
    }
}
