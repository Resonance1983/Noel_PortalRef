﻿// This code is part of the Fungus library (https://github.com/snozbot/fungus)
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

using UnityEngine;


namespace Fungus {
    /// <summary>
    /// 
    /// </summary> 
    [CommandInfo("LeanTween",
                 "StopTweens",
                 "Stops the LeanTweens on a target GameObject")]
    [AddComponentMenu("")]
    [ExecuteInEditMode]
    public class StopTweensLean : Command {
        [Tooltip("Target game object stop LeanTweens on")]
        [SerializeField]
        protected GameObjectData _targetObject;

        public override void OnEnter() {
            if (_targetObject.Value != null) {
                LeanTween.cancel(_targetObject.Value);
            }

            Continue();
        }

        public override string GetSummary() {
            if (_targetObject.Value == null) {
                return "Error: No target object selected";
            }

            return "Stop all LeanTweens on " + _targetObject.Value.name;
        }

        public override Color GetButtonColor() {
            return new Color32(233, 163, 180, 255);
        }

        public override bool HasReference(Variable variable) {
            return _targetObject.gameObjectRef == variable;
        }
    }
}