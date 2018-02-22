using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


 

public class CreateAssetBundle : MonoBehaviour {

 
	//[MenuItem("AssetBundle/Build AssetBundles")]
 //   static void BuildAllAssetBundles()
 //   {
 //       BuildPipeline.BuildAssetBundles("Assets/StreamingAssets", BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.StandaloneWindows);

 //       AssetDatabase.SaveAssets();
 //       AssetDatabase.Refresh();
 //   }


    ///// <summary>
    ///// 点击后，所有设置了AssetBundle名称的资源会被 分单个打包出来
    ///// </summary>
    //[MenuItem("AssetBundle/Build (Single)")]
    //static void Build_AssetBundle()
    //{

    //    BuildPipeline.BuildAssetBundles(Application.dataPath + "/ABs", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
    //    //刷新
    //    AssetDatabase.Refresh();
    //}

    [MenuItem("AssetBundle/Build Asset Bundles")]
    static void BuildABs()
    {
        //打包出来的资源包名字
        //在Project视图中，选择要打包的对象  
        Object[] selects = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
        int i = 0;
        foreach (Object se in selects)
        {
           
            string[] enemyAsset = new string[selects.Length];
            AssetBundleBuild[] buildMap = new AssetBundleBuild[1];
            buildMap[0].assetBundleName = se.name;
            enemyAsset[0] = AssetDatabase.GetAssetPath(selects[i]);
            buildMap[0].assetNames = enemyAsset;
            i++;
            BuildPipeline.BuildAssetBundles(Application.dataPath + "/StreamingAssets", buildMap, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
            AssetDatabase.Refresh();
        }
 
    }
    /// <summary>
    /// 选择的资源合在一起被打包出来
    /// </summary>
    [MenuItem("AssetBundle/Build (Collection)")]
    static void Build_AssetBundle_Collection()
    {
        AssetBundleBuild[] buildMap = new AssetBundleBuild[1];
        //打包出来的资源包名字
        buildMap[0].assetBundleName = "enemybundle";

        //在Project视图中，选择要打包的对象  
        Object[] selects = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
        string[] enemyAsset = new string[selects.Length];
        for (int i = 0; i < selects.Length; i++)
        {
            //获得选择 对象的路径
            enemyAsset[i] = AssetDatabase.GetAssetPath(selects[i]);
        }
        buildMap[0].assetNames = enemyAsset;
         BuildPipeline.BuildAssetBundles(Application.dataPath + "/ABs", buildMap, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
        //刷新
        AssetDatabase.Refresh();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
