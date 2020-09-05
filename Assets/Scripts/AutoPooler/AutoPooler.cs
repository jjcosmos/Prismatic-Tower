using System;
using System.Collections;
using UnityEngine;

public class AutoPooler : MonoBehaviour
{
    [SerializeField] [Tooltip("This is the game object prefab that will be pooled.")] 
    GameObject pooledPrefab;
    [SerializeField] [Tooltip("This is the size of the pool. Increase if needed.")] 
    int poolSize = 10;
    [SerializeField] [Tooltip("Automatically enables the dequeued gameobject.")] 
    bool autoEnableOnRequest = true;
    [SerializeField] [Tooltip("Automatically reuses active gameobjects when no inactive ones are available.")] 
    bool autoRecycleWhenDry = true;
    [SerializeField]
    [Tooltip("Suppresses recycling warnings.")]
    bool suppressWarnings = false;
    public GameObject[] poolContents { get; private set; }
    private int currentIndex = 0;
    private int recyclerIndex = 0;
    void Awake()
    {
        poolContents = new GameObject[poolSize];
        FillPool();
    }

    private void FillPool()
    {
        if(pooledPrefab == null)
        {
            Debug.LogError("var Pooled Prefab is not set in AutoPooler");
            return;
        }
        for (int i = 0; i < poolSize; i++)
        {
            poolContents[i] = Instantiate(pooledPrefab, Vector3.zero, Quaternion.identity, this.transform);
            poolContents[i].SetActive(false);
        }
    }

    public GameObject RequestDequeue()
    {
        if (!FindInactiveObject())
        {
            if (!suppressWarnings) { Debug.LogWarning("Pool is dry. try increasing the size or enabling autoRecycleWhenDry."); }
            return null;
        }

        GameObject toDequeue = poolContents[currentIndex];
        toDequeue.SetActive(false);
        currentIndex = (int)Mathf.Repeat(currentIndex + 1, poolSize - 1);

        if (autoEnableOnRequest) { toDequeue.SetActive(true); }
        return toDequeue;
    }

    private bool FindInactiveObject()
    {
        for (int i = 0; i < poolSize; i++)
        {
            if(!poolContents[i].activeSelf)
            {
                currentIndex = i;
                return true;
            }
        }
        if (autoRecycleWhenDry)
        {
            currentIndex = recyclerIndex;
            recyclerIndex = (int)Mathf.Repeat(recyclerIndex + 1, poolSize - 1);
            if (!suppressWarnings) { Debug.LogWarning("Recycling projectile. Consider increasing pool size."); }
            return true;
        }
        else
        {
            if (!suppressWarnings) { Debug.LogWarning("Cannot recycle projectile, and none are inactive. Consider increasing pool size."); }
            return false;
        }
    }
}
