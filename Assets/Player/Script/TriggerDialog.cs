using System.Xml.Serialization;
using UnityEngine;

public class TriggerDialog : MonoBehaviour
{
    public GameManagement manager;
    public Choice c;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            manager.displayChoiceUI(c);
        }
    }
}
