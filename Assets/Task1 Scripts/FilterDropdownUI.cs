using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterDropdownUI : MonoBehaviour
{
    ClientListHandler clientListHandler;
    private void Awake()
    {
        clientListHandler = FindObjectOfType<ClientListHandler>();
    }
    public void OnDropdownValueChange(int index)
    {
        switch (index)
        {
            case 0:
                clientListHandler.ShowAll();
                break;
            case 1:
                clientListHandler.Filter(true);
                break;
            case 2:
                clientListHandler.Filter(false);
                break;
        }
    }
}
