using UnityEngine;
[CreateAssetMenu(fileName = "PlasmaShot", menuName = "CreateWeapon/PlasmaShot")]
public class PlasmaShot : Weapon
{
    public override void fireWeapon(PlayerController controller)
    {
        controller.ShootPlasmaShot();
    }
}
