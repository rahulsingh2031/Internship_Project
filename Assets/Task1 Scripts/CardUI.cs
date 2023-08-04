using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardUI : MonoBehaviour, IPointerClickHandler
{
    public static event System.Action<UserData> OnCardClick;
    [SerializeField] TMPro.TextMeshProUGUI idText;
    [SerializeField] TMPro.TextMeshProUGUI labelText;
    Client client;

    public void Init(Client client)
    {
        idText.text = "Id: " + client.id.ToString();
        labelText.text = "label: " + client.label;
        this.client = client;
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        UserData userData;
        API_Handler.Singleton.RootData.data.TryGetValue(client.id.ToString(), out userData);


        OnCardClick?.Invoke(userData);
    }
}
