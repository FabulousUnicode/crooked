using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelManager : MonoBehaviour, IPointerExitHandler
{

    [SerializeField] private GameObject IPanel;

    public void OnPointerExit(PointerEventData eventData)
    {
        StartCoroutine(closeDelay());
    }

    IEnumerator closeDelay()
    {
        yield return new WaitForSeconds(0.5f);
        closePanel();
    }

    public void closePanel()
    {
        IPanel.SetActive(false);
    }
}
