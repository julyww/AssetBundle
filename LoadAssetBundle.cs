using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadAssetBundle : MonoBehaviour {
    
 
    private void Awake()
    {
        
    }
    void Start () {
        var myAssetbundle=AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath,"cube 1"));
        if (myAssetbundle == null)
        {
            return;
        }
        var prefab = myAssetbundle.LoadAsset<GameObject>("Cube 1");
        Instantiate(prefab);
        myAssetbundle.Unload(false);
         
    }
	
	// Update is called once per frame
	void Update () {
		
	}

   void loadadw()
    {
        var myAssetbundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "cube 1"));
        if (myAssetbundle == null)
        {
            return;
        }
        var prefab = myAssetbundle.LoadAsset<GameObject>("Cube 1");
        Instantiate(prefab);
        myAssetbundle.Unload(false);
    }

    
     
}
