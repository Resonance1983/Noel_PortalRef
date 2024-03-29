﻿// This code is part of the Fungus library (https://github.com/snozbot/fungus)
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

using UnityEngine;

namespace Fungus {
    /// <summary>
    /// Command to store the min or max of 2 values
    /// </summary>
    [CommandInfo("Math",
                 "MinMax",
                 "Command to store the min or max of 2 values")]
    [AddComponentMenu("")]
    public class MinMax : Command {
        public enum Function {
            Min,
            Max
        }

        [Tooltip("Min Or Max")]
        [SerializeField]
        protected Function function = Function.Min;

        //[Tooltip("LHS Value ")]
        [SerializeField]
        protected FloatData inLHSValue, inRHSValue;

        //[Tooltip("Where the result of the function is stored.")]
        [SerializeField]
        protected FloatData outValue;

        public override void OnEnter() {
            switch (function) {
                case Function.Min:
                    outValue.Value = Mathf.Min(inLHSValue.Value, inRHSValue.Value);
                    break;
                case Function.Max:
                    outValue.Value = Mathf.Max(inLHSValue.Value, inRHSValue.Value);
                    break;
                default:
                    break;
            }

            Continue();
        }

        public override string GetSummary() {
            return function.ToString() + " " +
                "out: " + (outValue.floatRef != null ? outValue.floatRef.Key : outValue.Value.ToString()) +
                " [" + inLHSValue.Value.ToString() + " - " + inRHSValue.Value.ToString() + "]";
        }

        public override bool HasReference(Variable variable) {
            return inLHSValue.floatRef == variable || inRHSValue.floatRef == variable || outValue.floatRef == variable;
        }

        public override Color GetButtonColor() {
            return new Color32(235, 191, 217, 255);
        }
    }
}