using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class ClientHandler
{
    private ClientHandler() { }

    public static ClientHandler GetInstance()
    {
        if (m_instance == null)
        {
            m_instance = new ClientHandler();
            Debug.Log("Created new ClientHandler Instance");
        }

        return m_instance;
    }    
    
    public int GetNewObjectID()
    {
        //Checks if the client has been initialized
        if (m_clientNumber != -1)
        {
            int temp = idGenerator;
            idGenerator++;

            return (UtilityFunctions.Combine(m_clientNumber, temp));
        }

        return -1;
    }

    public void SetClientNumber(int clientNum)
    {
        m_clientNumber = clientNum;
    }

    //The number of this client on the server
    private int m_clientNumber = -1;

    //Unique ID creator for objects on the network
    private static int idGenerator = 0;

    //Singleton instance
    private static ClientHandler m_instance = null;


}
