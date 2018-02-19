using UnityEngine;

namespace Flusk
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        public static T Instance
        {
            get { return (T) instance; }
        }

        protected static Singleton<T> instance;

        public static bool TryGetInstance(out T current)
        {
            if (instance == null)
            {
                current = null;
                return false;
            }
            current = (T)instance;
            return true;
        }

        protected virtual void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if ( instance != this )
            {
                Destroy(gameObject);
            }
        }
    }
}