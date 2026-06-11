using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<T>();

            return instance;
        }
    }

    protected virtual void Awake()
    {
        T current = GetComponent<T>();

        if (instance != null && instance != current)
        {
            Destroy(gameObject);
            return;
        }

        instance = current;
    }

    protected virtual void OnDestroy()
    {
        T current = GetComponent<T>();

        if (instance == current)
            instance = null;
    }

    protected bool IsSingletonInstance()
    {
        T current = GetComponent<T>();
        return instance == current;
    }
}
