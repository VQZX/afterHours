using System;
using Flusk;
using Flusk.Attributes;
using UnityEngine;

namespace AfterHours.Interaction.Interactions.Part1
{
    public class Part1GameFlags : GameFlags<Part1Flags>
    {
#if UNITY_EDITOR
        [EnumFlag]
        public Part1Flags DummyFlag;

        [SerializeField]
        protected bool useDummy;
        public bool UseDummy
        {
            get { return useDummy; }
        }
#endif
        
        
        public static Part1GameFlags Get()
        {
            return (Part1GameFlags) instance;
        }
        
        public override bool HasFlag(Part1Flags flag)
        {
            return (flag & accumulatedFlag) > 0;
        }

        public override void AddFlag(int flagID)
        {
            Part1Flags flag = (Part1Flags) flagID;
            AddFlag(flag);
        }

        public override void AddFlag(Part1Flags flag)
        {           
            accumulatedFlag = accumulatedFlag | flag;
        }
    }
}