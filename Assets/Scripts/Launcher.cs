using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;
using JetBrains.Annotations;

public class Launcher : MonoBehaviourPunCallbacks
{

    const string roomName = "xSpace-portalRoom";

    void Start()
    {
        PhotonNetwork.GameVersion = "1.0";
        PhotonNetwork.ConnectUsingSettings();
    }


    void Update()
    {

    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("On disconnected: " + cause);
    }

    public void OnButtonClick()
    {
        Debug.Log("On Button Click");

        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 4;
        options.IsVisible = false;
        PhotonNetwork.JoinOrCreateRoom(roomName, options, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("ON Joined Room");
        PhotonNetwork.LoadLevel("PortalRoom");
    }


}