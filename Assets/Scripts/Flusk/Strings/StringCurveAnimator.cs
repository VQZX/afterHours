using System;
using Flusk.Extensions;
using UnityEngine;
 
 namespace Flusk.Strings
 {
     public class StringCurveAnimator : StringAnimator
     {
         public AnimationCurve Curve { get; protected set; }
         public bool CleanOnComplete { get; set; }

         private float min, max;
         
         public StringCurveAnimator(string text, AnimationCurve curve) : base(text)
         {
             Curve = curve;
             TotalTime = curve.FinalTime();
             timer = new Timer(TotalTime / speed, OnComplete, OnUpdate);
             CurrentTime = curve.FirstTime();
             min = curve.Min();
             max = curve.Max();
         }

         protected override void OnUpdate(float time)
         {
             CurrentTime = time;
             float currentEvaluation = Curve.Evaluate(CurrentTime);
             int characterIndex = (int) currentEvaluation.Map(min, max, 0, charLength);
             SetString(characterIndex);
         }

         protected override void OnComplete()
         {
             base.OnComplete();
             if (CleanOnComplete)
             {
                 CurrentText = string.Empty;
             }
         }
         
     }
 }