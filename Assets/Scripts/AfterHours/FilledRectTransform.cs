using System;
using System.Collections.Generic;
using UnityEngine;

namespace AfterHours
{
    [Serializable]
    public struct FilledRectTransform
    {
        public RectTransform ContainerRectTransform;

        public Rect Rect
        {
            get 
            {
                return ContainerRectTransform.rect;
            }
        }

        public List<RectTransform> ContainedTransforms;

        public int Amount
        {
            get { return ContainedTransforms.Count; }
        }

        public FilledRectTransform(RectTransform transform, List<RectTransform> children = null)
        {
            ContainerRectTransform = transform;
            ContainedTransforms = children ?? new List<RectTransform>();
        }

        public void Add(RectTransform transform)
        {
            if (ContainedTransforms.Contains(transform))
            {
                return;
            }
            ContainedTransforms.Add(transform);
        }

        public bool Remove(RectTransform transform)
        {
            if (ContainedTransforms.Contains(transform))
            {
                ContainedTransforms.Remove(transform);
                return true;
            }
            return false;
        }
    }
}