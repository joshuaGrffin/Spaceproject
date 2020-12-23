using UnityEngine;
[CreateAssetMenu(fileName ="Machinegun", menuName ="CreateWeapon/Machinegun")]
public class MachineGun : Weapon
{
    public override void fireWeapon(PlayerController controller)
    {
        controller.ShootMachinegun();
    }
}
