using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using Utils;

public class NetworkManager : MonoBehaviour
{
    private float m_time = 0.0f;
    public float sendInterval = 30.0f;

    public string ip;

    public List<WatchedObject> watchedObjects = new List<WatchedObject>();

    const string DLL_NAME = "NETWORKING";

    [DllImport(DLL_NAME)]
    public static extern void InitClient();

    [DllImport(DLL_NAME)]
    public static extern void ConnectToServer(string ip);

    [DllImport(DLL_NAME)]
    public static extern void SendFloat(float flt, MessageFlags flag);

    [DllImport(DLL_NAME)]
    public static extern void SendInt(float it, MessageFlags flag);

    [DllImport(DLL_NAME)]
    public static extern void SendString(string str, MessageFlags flag);

    [DllImport(DLL_NAME)]
    public static extern void SendVector(Vector3CS vec, MessageFlags flag);

    [DllImport(DLL_NAME)]
    public static extern float RecvFloat();

    [DllImport(DLL_NAME)]
    public static extern int RecvInt();

    [DllImport(DLL_NAME)]
    public static extern string RecvString();

    [DllImport(DLL_NAME)]
    public static extern Vector3CS RecvVector();

    [DllImport(DLL_NAME)]
    public static extern void DisconnectFromServer();

    [DllImport(DLL_NAME)]
    public static extern void CloseClient();



    private void OnDestroy()
    {
        //Cleanup
        DisconnectFromServer();
        CloseClient();
    }

    // Start is called before the first frame update
    void Start()
    {
        InitializeClient();

       //StartCoroutine(ReceiveData());
    }

    void InitializeClient()
    {
        InitClient();
        ConnectToServer(ip);
    }

    // Update is called once per frame
    void Update()
    {
        SendData();
    }

    // IEnumerator ReceiveData()
    // {
    //     while (true)
    //     {
    //         int id = RecvInt();
    //         for (int i = 0; i < watchedObjects.Count; i++)
    //         {
    //             if (watchedObjects[i].objectID == id)
    //             {
    //                 watchedObjects[i].ReceivePosition();
    //             }
    //         }
    //     }
    //     //Supposed to be unreachable
    //     yield return null;
    // }

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
