using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notify : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Tell", 2.0f);   
    }

    void Tell() {
        CommunicationSystem.Instance.Notify("To be countinued . . . ");
    }
}
