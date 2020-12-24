using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This holds the spawning algotithm and also calls the displayer class to create the player ships and AI ships when ready
/// </summary>
public class LevelManagment : MonoBehaviour
{
    [SerializeField]
    GameObject playerPrefab;

    [SerializeField]
    Transform playerSpawn;

    //temperary
    [SerializeField]
    Ship aShip;

    private void Start()
    {
        ShipDisplayer.displayShip(playerSpawn, playerPrefab, aShip);
    }
}
