using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AfterHours.Menu
{
    public class SingleMethodButton : Button
    {
        /// <summary>
        /// Action that is called backs
        /// </summary>
        protected UnityAction unityAction;

        /// <summary>
        /// Ensure only one method on callback
        /// </summary>
        public virtual void AddOnClick(Action action)
        {
            unityAction = () => action();
            onClick.AddListener(unityAction);
        }
    }
}
