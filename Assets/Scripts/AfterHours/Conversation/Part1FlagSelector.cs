using System.IO;
using AfterHours.Interaction.Interactions;
using AfterHours.Interaction.Interactions.Part1;
using Flusk.Attributes;
using UnityEngine;

namespace AfterHours.Conversation
{
    public class Part1FlagSelector : MonoBehaviour
    {
        [EnumFlag]
        public Part1Flags Flag;

        public void SendFlag()
        {
            GameFlags<Part1Flags> gf;
            if (Part1GameFlags.TryGetInstance(out gf))
            {
                Part1GameFlags flags = gf as Part1GameFlags;
                if (flags != null)
                {
                    flags.AddFlag(Flag);
                }
            }
        }
    }
}