using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class ObjectPool
    {
        public string tag; // Etiqueta que identifica el tipo de objeto en la pool
        public GameObject prefab; // Prefab del objeto
        public int size; // Tamaño inicial de la pool
    }

    public static ObjectPooler Instance; // Instancia del object pooler (Singleton)
    public List<ObjectPool> objectPools; // Lista de pools de objetos

    private Dictionary<string, Queue<GameObject>> poolDictionary; // Diccionario que asocia cada etiqueta con su pool de objetos

    private void Awake()
    {
        if (Instance == null) // Si no hay una instancia previa del object pooler
        {
            Instance = this; // La instancia es esta misma
        }
        else // Si ya hay una instancia del object pooler
        {
            Destroy(gameObject); // Destruye este objeto para evitar duplicados
            return;
        }

        poolDictionary = new Dictionary<string, Queue<GameObject>>(); // Crea el diccionario de pools

        foreach (ObjectPool pool in objectPools) // Por cada pool en la lista
        {
            Queue<GameObject> objectPool = new Queue<GameObject>(); // Crea una nueva cola de objetos

            for (int i = 0; i < pool.size; i++) // Crea los objetos iniciales de la pool
            {
                GameObject obj = Instantiate(pool.prefab); // Instancia un nuevo objeto del prefab
                obj.SetActive(false); // Lo desactiva para que no sea visible
                objectPool.Enqueue(obj); // Lo agrega a la cola de objetos
            }

            poolDictionary.Add(pool.tag, objectPool); // Agrega la cola de objetos al diccionario
        }
    }

    public GameObject GetPooledObject(string tag)
    {
        if (!poolDictionary.ContainsKey(tag)) // Si la etiqueta no está en el diccionario
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist!"); // Muestra una advertencia en la consola
            return null; // Retorna null
        }

        Queue<GameObject> objectPool = poolDictionary[tag]; // Obtiene la cola de objetos correspondiente a la etiqueta

        if (objectPool.Count == 0) // Si no hay objetos disponibles en la cola
        {
            Debug.LogWarning("Pool with tag " + tag + " is empty!"); // Muestra una advertencia en la consola
            return null; // Retorna null
        }

        GameObject obj = objectPool.Dequeue(); // Obtiene el primer objeto de la cola
        return obj;
    }

    public void AddToPool(GameObject obj, string tag)
    {
        if (!poolDictionary.ContainsKey(tag)) // Si la etiqueta no está en el diccionario
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist!"); // Muestra una advertencia en la consola
            return;
        }

        obj.SetActive(false); // Desactiva el objeto para que no sea visible
        Queue<GameObject> objectPool = poolDictionary[tag]; // Obtiene la cola de objetos correspondiente a la etiqueta
        objectPool.Enqueue(obj); // Agrega el objeto a la cola
    }
}
