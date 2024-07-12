using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace SyncplicityTask.Wrappers
{
    public static class Extension
    {


        public static string GetDescription(this Enum objValue)
        {

            Type type = objValue.GetType();
            Array values = System.Enum.GetValues(type);

            foreach (int val in values)
            {
                if (val != (Convert.ToInt16(objValue))) { continue; }

                var memInfo = type.GetMember(type.GetEnumName(val));
                var descriptionAttribute = memInfo[0]
                                                     .GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false)
                                                     .FirstOrDefault() as System.ComponentModel.DescriptionAttribute;

                if (descriptionAttribute != null)
                {
                    return descriptionAttribute.Description;
                }

            }
            return null;
        }
    }
}