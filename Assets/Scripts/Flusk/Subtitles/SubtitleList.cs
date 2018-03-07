using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flusk.Subtitles
{
    [Serializable]
    public class SubtitleList : IList<Subtitle>
    {
        [SerializeField]
        protected List<Subtitle> subtitles;

        private int currentIndex;

        public Subtitle GetNext()
        {
            currentIndex = currentIndex + 1;
            return this[currentIndex - 1];
        }
        
        
        
        #region IList implementation
        public IEnumerator<Subtitle> GetEnumerator()
        {
            return subtitles.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) subtitles).GetEnumerator();
        }

        public void Add(Subtitle item)
        {
            subtitles.Add(item);
        }

        public void Clear()
        {
            subtitles.Clear();
        }

        public bool Contains(Subtitle item)
        {
            return subtitles.Contains(item);
        }

        public void CopyTo(Subtitle[] array, int arrayIndex)
        {
            subtitles.CopyTo(array, arrayIndex);
        }

        public bool Remove(Subtitle item)
        {
            return subtitles.Remove(item);
        }

        public int Count
        {
            get { return subtitles.Count; }
        }

        public bool IsReadOnly
        {
            get { return ((ICollection<Subtitle>) subtitles).IsReadOnly; }
        }

        public int IndexOf(Subtitle item)
        {
            return subtitles.IndexOf(item);
        }

        public void Insert(int index, Subtitle item)
        {
            subtitles.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            subtitles.RemoveAt(index);
        }

        public Subtitle this[int index]
        {
            get { return subtitles[index]; }
            set { subtitles[index] = value; }
        }
        #endregion
    }
}