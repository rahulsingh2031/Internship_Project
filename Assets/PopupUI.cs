using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class PopupUI : MonoBehaviour
{
    [SerializeField] private float popupDuration = 0.5f;
    [SerializeField] private Ease easeInType = Ease.InBounce;
    [SerializeField] private Ease easeOutType = Ease.OutBounce;
    [SerializeField] private UnityEngine.UI.Image panel;

    [Header("Popup Data")]
    [SerializeField] UnityEngine.UI.Button closeButton;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI addressText;
    [SerializeField] TextMeshProUGUI pointsText;

    private void Awake()
    {
        CardUI.OnCardClick += Init;
        closeButton.onClick.AddListener(() => HidePopup());
    }
    private void ShowPopup()
    {
        gameObject.SetActive(true);
        panel.raycastTarget = true;
        transform.DOScale(1f, popupDuration).SetEase(easeInType);
    }
    private void HidePopup()
    {
        panel.raycastTarget = false;
        transform.DOScale(0, popupDuration).SetEase(easeOutType).OnComplete(() => gameObject.SetActive(false));
    }

    private void Init(UserData userData)
    {
        if (userData != null)
        {
            nameText.text = "Name: " + userData.name;
            addressText.text = "Address: " + userData.address;
            pointsText.text = "Points: " + userData.points.ToString();

        }
        else
        {
            nameText.text = "Name: ";
            addressText.text = "Address: "; ;
            pointsText.text = "Points: ";

        }
        ShowPopup();
    }

}
