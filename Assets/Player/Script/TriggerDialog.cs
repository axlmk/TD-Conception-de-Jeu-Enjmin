using System.Xml.Serialization;
using UnityEngine;

public class TriggerDialog : MonoBehaviour
{
    public GameManagement manager;
    public Choice c;

    private bool hasBeenEntered = false;

    void OnTriggerEnter(Collider other)
    {
        if ((!hasBeenEntered) && (other.gameObject.name == "Player"))
        {
            manager.displayChoiceUI(c);
            hasBeenEntered = true;
        }
    }
}
