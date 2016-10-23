using UnityEngine;
using System.Collections;

public class Keys : MonoBehaviour {

    public GameObject[] keys;
	// Update is called once per frame
	void Update () {
	    for(int i = 0; i < keys.Length; i++)
        {
            if(keys[i].gameObject.activeSelf)
            {
                return;
            }
        }
        win();
	}

    void win()
    {
        GameObject instance = Instantiate(Resources.Load("Win Audio", typeof(GameObject))) as GameObject;
        Destroy(this.gameObject);
    }
}
