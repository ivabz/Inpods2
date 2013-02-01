using System;
using System.ComponentModel;
using System.Reflection;

namespace Automation.TestScripts
{
    public static class EnumHelper
    {
        /// <summary>
        /// Method to get enum type string
        /// </summary>
        /// <param name="en">Enum Type</param>
        /// <returns>[String] Enum Type</returns>
        public static string OfType(Enum en)
        {
            Type type = en.GetType();

            MemberInfo[] memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            return en.ToString();
        }
    }
}
