using System;
using System.Collections.Generic;
using System.Linq;

namespace WizardsTest
{
    public class LayeredEffectCompnent : ILayeredAttributes
    {
        private Dictionary<AttributeKey, int> attributeValues;

        public void AddLayeredEffect(LayeredEffectDefinition effect)
        {
            if (attributeValues == null)
            {
                ClearLayeredEffects();
            }

            int oldValue = attributeValues[effect.Attribute];
            int newValue = effect.Modification;

            switch (effect.Operation)
            {
                case EffectOperation.Add:
                    attributeValues[effect.Attribute] += newValue;

                    break;

                case EffectOperation.Subtract:
                    attributeValues[effect.Attribute] -= newValue;
                    break;

                case EffectOperation.Set:
                    attributeValues[effect.Attribute] = newValue;
                    break;

                case EffectOperation.Multiply:

                    attributeValues[effect.Attribute] *= newValue;
                    break;

                case EffectOperation.BitwiseAnd:

                    attributeValues[effect.Attribute] = oldValue & newValue;
                    break;

                case EffectOperation.BitwiseOr:
                    attributeValues[effect.Attribute] = oldValue | newValue;
                    break;

                case EffectOperation.BitwiseXor:
                    attributeValues[effect.Attribute] = oldValue ^ newValue;
                    break;

                default:
                    return;
            }
        }

        public void ClearLayeredEffects()
        {
            attributeValues = new Dictionary<AttributeKey, int>();

            AttributeKey[] keys = Enum.GetValues(typeof(AttributeKey)).Cast<AttributeKey>().ToArray(); ;

            for (int i = 0; i < keys.Length; i++)
            {
                attributeValues.Add(keys[i], 0);
            }
        }

        public int GetCurrentAttribute(AttributeKey key)
        {
            if (attributeValues == null)
            {
                return 0;
            }
            return attributeValues[key];
        }

        public void SetBaseAttribute(AttributeKey key, int value)
        {
            if (attributeValues == null)
            {
                ClearLayeredEffects();
            }
            attributeValues[key] = value;
        }
    }
}