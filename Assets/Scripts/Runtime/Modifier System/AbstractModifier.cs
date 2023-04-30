using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Runtime.Modifier_System
{
    public abstract class AbstractModifier<T>
    {
        private string attributeName;
        private T Value;

        public abstract void Apply();
    }

    public class SpeedModifier : AbstractModifier<float>
    {
        public override void Apply()
        {
        }
    }

    public class XpModifier : AbstractModifier<int>
    {
        public override void Apply()
        {
        }
    }
}