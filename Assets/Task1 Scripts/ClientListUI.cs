using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientListUI : MonoBehaviour
{
    ClientListHandler clientListHandler;
    [SerializeField] Transform templateCardUI;
    private void Awake()
    {
        clientListHandler = FindObjectOfType<ClientListHandler>();
        clientListHandler.OnClientListChange += ClientListHandler_OnClientListChange;
        templateCardUI.gameObject.SetActive(false);
    }

    private void DestroyAllCardInstance()
    {
        foreach (Transform cardTransform in transform)
        {
            if (cardTransform == templateCardUI) continue;
            Destroy(cardTransform.gameObject);
        }
    }
    private void ClientListHandler_OnClientListChange(List<Client> clientList)
    {
        DestroyAllCardInstance();
        foreach (Client client in clientList)
        {
            Transform cardTransform = Instantiate(templateCardUI, transform);
            cardTransform.gameObject.SetActive(true);
            if (cardTransform.TryGetComponent<CardUI>(out CardUI cardUI))
            {
                cardUI.Init(client);
            }
        }
    }
    private void OnDestroy()
    {
        clientListHandler.OnClientListChange -= ClientListHandler_OnClientListChange;
    }
}
