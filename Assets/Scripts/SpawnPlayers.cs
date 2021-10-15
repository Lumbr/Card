using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    private void Start() { PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity); }
}
