/*This script has been, partially or completely, generated by the Fungus.GenerateVariableWindow*/
using UnityEngine;


namespace Fungus {
    // <summary>
    /// Get or Set a property of a Color component
    /// </summary>
    [CommandInfo("Property",
                 "Color",
                 "Get or Set a property of a Color component")]
    [AddComponentMenu("")]
    public class ColorProperty : BaseVariableProperty {
        //generated property
        public enum Property {
            R,
            G,
            B,
            A,
            Grayscale,
            Linear,
            Gamma,
            MaxColorComponent,
        }


        [SerializeField]
        protected Property property;

        [SerializeField]
        [VariableProperty(typeof(ColorVariable))]
        protected ColorVariable colorVar;

        [SerializeField]
        [VariableProperty(typeof(FloatVariable),
                          typeof(ColorVariable))]
        protected Variable inOutVar;

        public override void OnEnter() {
            var iof = inOutVar as FloatVariable;
            var iocol = inOutVar as ColorVariable;


            var target = colorVar.Value;

            switch (getOrSet) {
                case GetSet.Get:
                    switch (property) {
                        case Property.R:
                            iof.Value = target.r;
                            break;
                        case Property.G:
                            iof.Value = target.g;
                            break;
                        case Property.B:
                            iof.Value = target.b;
                            break;
                        case Property.A:
                            iof.Value = target.a;
                            break;
                        case Property.Grayscale:
                            iof.Value = target.grayscale;
                            break;
                        case Property.Linear:
                            iocol.Value = target.linear;
                            break;
                        case Property.Gamma:
                            iocol.Value = target.gamma;
                            break;
                        case Property.MaxColorComponent:
                            iof.Value = target.maxColorComponent;
                            break;
                        default:
                            Debug.Log("Unsupported get or set attempted");
                            break;
                    }

                    break;
                case GetSet.Set:
                    switch (property) {
                        case Property.R:
                            target.r = iof.Value;
                            break;
                        case Property.G:
                            target.g = iof.Value;
                            break;
                        case Property.B:
                            target.b = iof.Value;
                            break;
                        case Property.A:
                            target.a = iof.Value;
                            break;
                        default:
                            Debug.Log("Unsupported get or set attempted");
                            break;
                    }

                    break;
                default:
                    break;
            }

            colorVar.Value = target;

            Continue();
        }

        public override string GetSummary() {
            if (inOutVar == null) {
                return "Error: no variable set to push or pull data to or from";
            }

            return getOrSet.ToString() + " " + property.ToString();
        }

        public override Color GetButtonColor() {
            return new Color32(235, 191, 217, 255);
        }

        public override bool HasReference(Variable variable) {
            if (colorVar == variable || inOutVar == variable)
                return true;

            return false;
        }

    }
}