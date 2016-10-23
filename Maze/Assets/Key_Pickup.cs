using UnityEngine;
using System.Collections;

public class Key_Pickup : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject instance = Instantiate(Resources.Load("Key Audio", typeof(GameObject))) as GameObject;
            this.gameObject.SetActive(false);
        }
    }
}
