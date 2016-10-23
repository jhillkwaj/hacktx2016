using UnityEngine;
using System.Collections;

public class Move_Player : MonoBehaviour {

    public GameObject head;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawRay(this.transform.position, head.transform.forward);
        this.transform.position += 5 * Input.GetAxis("Vertical") * Time.deltaTime * head.transform.forward;
	}
}
