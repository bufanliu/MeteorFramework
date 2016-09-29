using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using ExitGames.Client.Photon;
using System;
using System.Security;
using System.Collections.Generic;

public class PhotonClient : MonoBehaviour, IPhotonPeerListener
{
    public string ServerAddress = "localhost:5055";
    protected string ServerApplication = "YbServerElement";

    protected PhotonPeer peer;
    public bool ServerConnected;


    public Text tt;


    // Use this for initialization
    void Start()
    {
        this.ServerConnected = false;
        this.peer = new PhotonPeer(this, ConnectionProtocol.Udp);
        this.Connect();






    }
    internal virtual void Connect()
    {
        try
        {
            this.peer.Connect(this.ServerAddress, this.ServerApplication);
        }
        catch (SecurityException se)
        {
            this.DebugReturn(0, "Connection Failed. " + se.ToString());
        }
    }
    // Update is called once per frame
    void Update()
    {
        this.peer.Service();

        if (ServerConnected)
        {
            tt.text = "Connect";

        }
        else
        {
            tt.text = "no";
        }

    }

    public void DebugReturn(DebugLevel level, string message)
    {
        Debug.LogWarning("DebugLevel:" + level + " Message:" + message);
    }

    public void OnEvent(EventData eventData)
    {
        throw new NotImplementedException();
    }

    public void OnOperationResponse(OperationResponse operationResponse)
    {
        this.DebugReturn(0, string.Format("OperationResult:" + operationResponse.OperationCode.ToString()));

        switch (operationResponse.OperationCode)
        {
            case 5:
                {
                    if (operationResponse.ReturnCode == 0) // if success
                    {

                    }
                    else
                    {

                    }
                    break;
                }
        }
    }

    public void OnStatusChanged(StatusCode statusCode)
    {
        this.DebugReturn(0, string.Format("PeerStatusCallback: {0}", statusCode));
        switch (statusCode)
        {
            case StatusCode.Connect:
                this.ServerConnected = true;
                break;
            case StatusCode.Disconnect:
                this.ServerConnected = false;
                break;
        }
    }

    public void Send()
    {
        Debug.Log("发送消息");
        Dictionary<byte, object> dd = new Dictionary<byte, object>();

        Dictionary<string, string> dir = new Dictionary<string, string>();

        dir.Add("1", "haha");
        dir.Add("2", "中文歌");
        dir.Add("3", "@@13");
        dir.Add("4", "44444");
        dd.Add(1, dir);

        this.peer.OpCustom(5, dd, true);
    }

    public void OnApplicationQuit()
    {
        this.peer.Disconnect();
    }

}
