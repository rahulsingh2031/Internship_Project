using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClientListHandler : MonoBehaviour
{

    public event Action<List<Client>> OnClientListChange;

    private API_Handler aPI_Handler;



    private IEnumerator Start()
    {
        aPI_Handler = API_Handler.Singleton;
        while (aPI_Handler.RootData == null)
        {
            yield return null;
        }
        ShowAll();
    }

    public void ShowAll()
    {

        List<Client> allClients = aPI_Handler.RootData.clients;
        OnClientListChange?.Invoke(allClients);
    }
    public void Filter(bool showManager)
    {
        List<Client> requiredClient = new();
        foreach (Client client in aPI_Handler.RootData.clients)
        {
            if (showManager == client.isManager)
            {
                requiredClient.Add(client);
                OnClientListChange?.Invoke(requiredClient);
            }

        }


    }
}
