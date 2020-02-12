using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System.Threading;

namespace Utils
{
    class NetworkThreader
    {
        public static Thread receiveThr;

        public static List<WatchedObject> watchedObjects;

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

        public static void StartThreading()
        {
            //Start receive thread
            receiveThr = new Thread(ReceiveThread);
        }

        public static void ReceiveThread()
        {
            while (true)
            {
                int id = RecvInt();
                for (int i = 0; i < watchedObjects.Count; i++)
                {
                    if (id == watchedObjects[i].objectID)
                    {
                        if (!watchedObjects[i].ownedByClient)
                        {
                            Vector3CS position = RecvVector();
                            watchedObjects[i].transform.position = new Vector3(position.x, position.y, position.z);
                        }
                    }
                }
            }
        }

    }
}