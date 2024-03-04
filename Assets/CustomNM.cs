// using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CustomNM : NetworkManager
{
    public override void OnClientConnect()
    {
        base.OnClientConnect();
        Debug.Log("I am a client and I have connected to the server! Yayy!!");
    }

    //     public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    //     {
    //         base.OnServerAddPlayer(conn);
    //         Debug.Log("Player added!");
    //         PlayerColor playerColor = conn.identity.GetComponent<PlayerColor>();
    //         playerColor.SetDisplayColor(new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f));
    //     }
    // }
    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);
        Debug.Log("Player added!");

        // Find the square GameObject associated with the network connection
        GameObject square = conn.identity.gameObject;

        // Add the PlayerColor component to the square GameObject
        PlayerColor playerColor = square.GetComponent<PlayerColor>();
        if (playerColor == null)
        {
            playerColor = square.AddComponent<PlayerColor>();
        }

        // Set display color if PlayerColor component is present
        if (playerColor != null)
        {
            playerColor.SetDisplayColor(new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f));
        }
        else
        {
            Debug.LogError("PlayerColor component not found or added on player GameObject.");
        }
    }


}
// Client-side script
public class ClientScript : MonoBehaviour
{
    public NetworkManager networkManager;

    public void ConnectToServer()
    {
        if (networkManager != null)
        {
            try
            {
                networkManager.StartClient();
                Debug.Log("Successful Connection!");
            }
            catch (System.Exception e)
            {
                Debug.LogError("Error connecting to server: " + e.Message);
            }
        }
        else
        {
            Debug.LogError("NetworkManager reference is not set!");
        }
    }
}
