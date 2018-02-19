using System;
using Flusk;

namespace AfterHours.Interaction.Interactions
{
    public abstract class GameFlags<T> : Singleton<GameFlags<T>> where T : IConvertible
    {
        protected T accumulatedFlag;

        public abstract void AddFlag(int flagId);
        
        public abstract bool HasFlag(T flag);

        public abstract void AddFlag(T flag);
        
#if UNITY_EDITOR
        protected virtual void OnValidate()
        {
            if (!typeof(T).IsEnum)
            {
                string format = string.Format("[GAME FLAGS] Type T ({0}) must be of type Enum", 
                    typeof(T).ToString());
                throw new ArgumentException(format);
            }
        }
#endif
    }
}