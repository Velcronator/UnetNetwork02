using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SetupLocalPlayer : NetworkBehaviour {

    public Text namePlayerPrefab;   // Prefab
    public Text nameLabel;          // Instants of the prefab
    public Transform namePos;

   // [SyncVar(hook = "OnChangeName")]
    public string pName = "player";

    [Command]
    public void CmdChangeName(string newName)
    {
        pName = newName;
        nameLabel.text = pName;
        Debug.Log("CmdChangeName");
    }


    void OnGUI()
    {
        if (isLocalPlayer)
        {
            pName = GUI.TextField(new Rect(25, 15, 100, 25), pName); //textboxname);
            if (GUI.Button(new Rect(130, 15, 35, 25), "Set"))
                CmdChangeName(pName);

            //colourboxname = GUI.TextField(new Rect(170, 15, 100, 25), colourboxname);
            //if (GUI.Button(new Rect(275, 15, 35, 25), "Set"))
            //    CmdChangeColour(colourboxname);
        }
    }




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
