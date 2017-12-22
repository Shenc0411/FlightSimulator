using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;

public class PlayerManager : Photon.PunBehaviour
{
    public GameObject plane;
    public GameObject AvatarSpawnSpot;
    public GameObject YokeSpawnSpot;
    public GameObject localAvatar;
    public GameObject localYoke;

    public override void OnJoinedRoom()
    {

        PhotonView[] PVs = localAvatar.GetPhotonViewsInChildren();

        for (int i = 0; i < PVs.Length; i++)
        {
            PVs[i].RequestOwnership();
        }

        PhotonView LYPV = localYoke.GetPhotonView();
        LYPV.RequestOwnership();

    }

}