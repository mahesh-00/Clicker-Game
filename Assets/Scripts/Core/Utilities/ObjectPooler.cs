using System.Collections;
using UnityEngine;
using System.Collections.Generic;

namespace Clicker
{
    public class ObjectPooler : MonoBehaviour
    {
        #region static field
        private static ObjectPooler _instance;
        #endregion

        #region class
        [System.Serializable]
        public class Pool
        {
            public string poolName;
            public GameObject prefab;
            public int poolSize;

        }
        #endregion

        #region Properties
        public static ObjectPooler Instance => _instance;
        #endregion

        #region OtherVariables
        public List<Pool> poolList;
        private Dictionary<string, Queue<GameObject>> clickEffectDict = new Dictionary<string, Queue<GameObject>>();
        #endregion

        #region Monobehaviour
        // Start is called before the first frame update
        void Start()
        {
            _instance = this;

            foreach (Pool pool in poolList)
            {
                Queue<GameObject> objQueue = new Queue<GameObject>();
                for (int i = 0; i < pool.poolSize; i++)
                {
                    GameObject obj = Instantiate(pool.prefab, this.transform);
                    obj.SetActive(false);
                    objQueue.Enqueue(obj);
                }
                clickEffectDict.Add(pool.poolName, objQueue);
            }

        }
        #endregion

        #region Methods
        public GameObject SpawnObjectFromPool(string _poolName)
        {
            if (!clickEffectDict.ContainsKey(_poolName))
            {
                Debug.LogError("The given key " + _poolName + " does not exist in the dictionary");
                return null;
            }
            GameObject objToSpawn = clickEffectDict[_poolName].Dequeue();
            objToSpawn.SetActive(true);
            StartCoroutine(EnqueueObjectToPool(_poolName, objToSpawn));
            return objToSpawn;
        }

        IEnumerator EnqueueObjectToPool(string _poolName, GameObject _obj)
        {
            yield return new WaitForSeconds(3);
            clickEffectDict[_poolName].Enqueue(_obj);
            _obj.SetActive(false);
        }
        #endregion

    }
}
