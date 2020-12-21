using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Shield", menuName ="CreateShield/Shield")]
public class Shield : ScriptableObject
{
    #region stats
    public float rechargeRate;
    public float maxDamageReflection;
    #endregion

    public Material material;

}
