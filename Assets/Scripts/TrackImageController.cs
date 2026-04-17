using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class TrackImageController : MonoBehaviour
{
    [SerializeField] private ARTrackedImageManager trackedImageManager;
    //[SerializeField] private GameObject framePrefab;
    [SerializeField] private ARObjects[] arObjects;

    //private List<GameObject> prefabCopies;
    private List<string> trackedImagesNames;
    [SerializeField] private int maxPrefabs;
    //[SerializeField] private GameObject mcdonaldsPrefab;

    private void OnEnable()
    {
        //trackedImageManager.trackedImagesChanged += OnTrackedChanged; Obsoleto (Action de C#)
        //prefabCopies = new List<GameObject>();
        trackedImagesNames = new List<string>();
        trackedImageManager.trackablesChanged.AddListener(OnTrackedChanged);

    }

    private void OnDisable()
    {
        trackedImageManager.trackablesChanged.RemoveAllListeners();
    }

    private void OnTrackedChanged(ARTrackablesChangedEventArgs<ARTrackedImage> eventargs)
    {
        foreach(var newImage in eventargs.added)
        {
            /*if(newImage.referenceImage.name == "framegameslogo")
            {
                prefabCopy = Instantiate(framePrefab, newImage.transform.position, newImage.transform.rotation);
            }*/
        }

        foreach (var newImage in eventargs.removed)
        {
            /*if (newImage.referenceImage.name == "framegameslogo")
            {
                Destroy(prefabCopy);
            }*/
        }

        foreach (var newImage in eventargs.updated)
        {
            /*Debug.Log(newImage.referenceImage.name);
            Debug.Log(newImage.referenceImage.texture);
            Debug.Log(newImage.referenceImage.guid);
            if (newImage.referenceImage.name == "framegameslogo" && prefabCopy == null)
            {
                prefabCopy = Instantiate(framePrefab, newImage.transform.position, newImage.transform.rotation);
            }*/

            for(int i = 0; i < arObjects.Length; i++)
            {
                if (newImage.referenceImage.name == arObjects[i].referenceImageName /*&& prefabCopies.Count <= maxPrefabs*/)
                {
                    GameObject prefabCopy;
                    prefabCopy = Instantiate(arObjects[i].referencePrefab, newImage.transform.position, newImage.transform.rotation.normalized, newImage.transform);
                    //prefabCopies.Add(prefabCopy);
                    if(trackedImagesNames.Count > 0)
                    {
                        foreach(var imageName in trackedImagesNames)
                        {
                            if (newImage.referenceImage.name == imageName) 
                            {
                                Destroy(prefabCopy);
                                return;
                            }
                        }
                    }
                    trackedImagesNames.Add(newImage.referenceImage.name);
                }
            }
        }
    }
}

[Serializable]
public class ARObjects
{
    public string referenceImageName;
    public GameObject referencePrefab;
}