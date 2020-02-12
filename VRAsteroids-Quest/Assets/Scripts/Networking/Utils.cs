using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    class UtilityFunctions
    {
        public static int Combine(int a, int b)
        {
            if (b == 0) return a;
            return Combine(a, b / 10) * 10 + b % 10;
        }
    }

    public enum MessageType
    {
        MSG_INT,                //Message type Int
        MSG_FLOAT,              //Message type Float
        MSG_DOUBLE,             //Message type Double
        MSG_VECTOR3,            //Message type Vector3 (unimplemented)
        MSG_STRING,             //Message type String
        MSG_CONNECT,            //Message type Connect Request
        MSG_DISCONNECT,         //Message type Disconnect Request
    };

    public enum MessageFlags
    {

        BROADCAST_ALL,          //Broadcast to all clients connected to the server
        BROADCAST_RELATED,      //Broadcast to only clients grouped with this client
        NONE                    //Do nothing
    };

    public struct Vector3CS
    {

        public Vector3CS(float _x)
        {
            x = _x;
            y = 0.0f;
            z = 0.0f;
        }
        public Vector3CS(float _x, float _y)
        {
            x = _x;
            y = _y;
            z = 0.0f;
        }
        public Vector3CS(float _x = 0.0f, float _y = 0.0f, float _z = 0.0f)
        {
            x = _x;
            y = _y;
            z = _z;
        }

        public float x, y, z;
    }
}