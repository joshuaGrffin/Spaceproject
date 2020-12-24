using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
[CreateAssetMenu(fileName = "Shield", menuName = "CreateShield/Shield")]
public class Shield : ScriptableObject
{
    #region stats
    public float rechargeRate;
    public float maxDamageReflection;
    //public Color colorOfShield;
    #endregion
}
