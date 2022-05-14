using UnityEngine;

public class ButtoManagerPresent : MonoBehaviour
{
    public GameObject PanelPresent;
    [SerializeField]
    private bool PanelActiv = false;

    private void Awake()
    {
        PanelPresent.SetActive(false);
    }
    public void PanelOffOn()
    {
        if(PanelActiv)
        {
            PanelActiv = false;
        }
        else 
        {
            PanelActiv = true;
        }
        PanelPresent.SetActive(PanelActiv);
    }
}