using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class WatchedObject : MonoBehaviour
{
    public bool ownedByClient = false;
    public int objectID = 0;

    private void Start()
    {
        //Need to figure out deterministic way of getting these so I can guarantee 
        //Same ids on all other clients
        //For now 01 should work
        //objectID = ClientHandler.GetInstance().GetNewObjectID();  
    }
    public void SendPosition()
    {
        if (ownedByClient)
        {
            //Send position and ID for this object
            //NetworkManager.SendInt(objectID, MessageFlags.BROADCAST_ALL);
            Vector3CS position = new Vector3CS(transform.position.x, transform.position.y, transform.position.z);
            NetworkThreader.SendVector(position, MessageFlags.BROADCAST_ALL);
        }
    }
}
