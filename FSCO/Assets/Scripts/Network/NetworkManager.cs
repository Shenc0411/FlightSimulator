using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;

public class NetworkManager : Photon.PunBehaviour
{

    private string gameVersion = "0.01";
    // Use this for initialization
    void Start()
    {
        connect();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        
    }

    void connect()
    {
        if (!PhotonNetwork.connected)
        {
            PhotonNetwork.ConnectUsingSettings(gameVersion);
        }
    }

    private void OnGUI()
    {
        GUILayout.Label("Game Version: " + gameVersion);
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("OnJoinedLobby");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
    {
        Debug.Log("RandomJoinFailed");
        PhotonNetwork.CreateRoom("Flight Simulator1");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room: " + PhotonNetwork.room.Name);
    }

}