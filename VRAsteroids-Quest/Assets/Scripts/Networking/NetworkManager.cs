using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using Utils;
using System.Threading;

public class NetworkManager : MonoBehaviour
{
    private float m_time = 0.0f;
    public float sendInterval = 30.0f;

    public string ip;

    public List<WatchedObject> watchedObjects = new List<WatchedObject>();

    private void OnDestroy()
    {
        //Cleanup
        NetworkThreader.DisconnectFromServer();
        NetworkThreader.CloseClient();
    }

    // Start is called before the first frame update
    void Start()
    {
        InitializeClient();
        NetworkThreader.watchedObjects = watchedObjects;
        //NetworkThreader.StartThreading();
    }

    void InitializeClient()
    {
        NetworkThreader.InitClient();
        NetworkThreader.ConnectToServer(ip);
    }

    // Update is called once per frame
    void Update()
    {
        //SendData();
    }

    void SendData()
    {
        m_time += Time.deltaTime;
        if (m_time >= sendInterval)
        {
            for (int i = 0; i < watchedObjects.Count; i++)
            {
                watchedObjects[i].SendPosition();
            }
            m_time = 0.0f;
        }
    }
}
