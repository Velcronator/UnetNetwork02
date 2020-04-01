using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SetupLocalPlayer : NetworkBehaviour {

    public Text namePlayerPrefab;   // Prefab
    public Text nameLabel;          // Instants of the prefab
    public Transform namePos;

	// Use this for initialization
	void Start () 
	{
		if(isLocalPlayer)
		{
			GetComponent<PlayerController>().enabled = true;
            CameraFollow360.player = this.gameObject.transform;
		}
		else
		{
			GetComponent<PlayerController>().enabled = false;
		}

        GameObject canvas = GameObject.FindWithTag("MainCanvas");
        nameLabel = Instantiate(namePlayerPrefab, Vector3.zero, Quaternion.identity) as Text;
        nameLabel.transform.SetParent(canvas.transform);
	}

	void Update()
	{
        Vector3 nameLabelPos = Camera.main.WorldToScreenPoint(namePos.position);
        nameLabel.transform.position = nameLabelPos;
	}

}
