using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject Licorne;
    public GameObject Pegase;
    public GameObject PegaseNoir;
    // Start is called before the first frame update
    void Start()
    {
        Personnages();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Personnages()
    {
        if(GameManager.instance.choixLicorne == true)
        {
            Instantiate(Licorne, new Vector3(0, 0, 0),Quaternion.identity);
        }
        else if(GameManager.instance.choixPegase == true)
        {
            Instantiate(Pegase, new Vector3(0, 0, 0), Quaternion.identity);
        }
        else if (GameManager.instance.choixPegase == true)
        {
            Instantiate(PegaseNoir, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}
