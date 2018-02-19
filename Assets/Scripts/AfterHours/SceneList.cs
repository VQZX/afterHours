using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AfterHours
{
    [Serializable]
    public class SceneList : IList
    {
        [SerializeField]
        protected List<string> sceneName;

        private int current;
        
        public string Iterate()
        {
            current = (current + 1) % sceneName.Count;
            return Current;
        }

        public string Current
        {
            get { return sceneName[current]; }
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable) sceneName).GetEnumerator();
        }

        public void CopyTo(Array array, int index)
        {
            ((ICollection) sceneName).CopyTo(array, index);
        }

        public int Count
        {
            get { return sceneName.Count; }
        }

        public object SyncRoot
        {
            get { return ((ICollection) sceneName).SyncRoot; }
        }

        public bool IsSynchronized
        {
            get { return ((ICollection) sceneName).IsSynchronized; }
        }

        public int Add(object value)
        {
            return ((IList) sceneName).Add(value);
        }

        public bool Contains(object value)
        {
            return ((IList) sceneName).Contains(value);
        }

        public void Clear()
        {
            sceneName.Clear();
        }

        public int IndexOf(object value)
        {
            return ((IList) sceneName).IndexOf(value);
        }

        public void Insert(int index, object value)
        {
            ((IList) sceneName).Insert(index, value);
        }

        public void Remove(object value)
        {
            ((IList) sceneName).Remove(value);
        }

        public void RemoveAt(int index)
        {
            sceneName.RemoveAt(index);
        }

        public object this[int index]
        {
            get { return ((IList) sceneName)[index]; }
            set { ((IList) sceneName)[index] = value; }
        }

        public bool IsReadOnly
        {
            get { return ((IList) sceneName).IsReadOnly; }
        }

        public bool IsFixedSize
        {
            get { return ((IList) sceneName).IsFixedSize; }
        }
    }
}