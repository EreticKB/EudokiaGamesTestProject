using UnityEngine;

public class UIPanelController : MonoBehaviour
{
    [SerializeField] GameObject[] _UIPanelArray;

    private void DisableAll()
    {
        foreach (GameObject panel in _UIPanelArray)
        {
            panel.SetActive(false);
        }
    }

    public void SetUIActiveByNumber(int i)
    {
        DisableAll();
        _UIPanelArray[i].SetActive(true);
    }
}
