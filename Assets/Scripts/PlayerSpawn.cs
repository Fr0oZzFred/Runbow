using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{   // Cedric
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
            Instantiate(Licorne, this.transform.position, Quaternion.identity);
        }
        else if(GameManager.instance.choixPegase == true)
        {
            Instantiate(Pegase, this.transform.position, Quaternion.identity);
        }
        else if (GameManager.instance.choixPegaseNoir == true)
        {
            Instantiate(PegaseNoir, this.transform.position, Quaternion.identity);
        }
    }
}
