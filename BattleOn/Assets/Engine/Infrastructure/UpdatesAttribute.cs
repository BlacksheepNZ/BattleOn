using System;
using System.Windows;

namespace BattleOn
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method, Inherited = true)]
    public class UpdatesAttribute : Attribute
    {
        public UpdatesAttribute(params string[] propertyNames)
        {
            PropertyNames = propertyNames;
        }

        public string[] PropertyNames { get; set; }
    }
}