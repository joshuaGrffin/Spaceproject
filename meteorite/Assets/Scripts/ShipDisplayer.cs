using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ShipDisplayer : MonoBehaviour
{
    /// <summary>
    /// this is to be used for player controller prefab at the start of the wave mode
    /// </summary>
    /// <param name="posToDisplay"></param>
    /// <param name="playerControllerPrefab"></param>
    /// <param name="aShip"></param>
    public static void displayShip(Transform posToDisplay, GameObject playerControllerPrefab, Ship aShip)
    {
        GameObject ship = Instantiate(aShip.prefab, posToDisplay, true);
    }
}
