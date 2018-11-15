using System;
using System.Text;

namespace CachingWithReflection.Helpers
{
    public class ReflectionDataConverter
    {

        public string GetDataAsString<T>(T obj)
        {
            var properties = obj.GetType().GetProperties();

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var item in properties)
            {
                stringBuilder.Append($"{item.Name} : {GetStringRepresentation(obj, item)},");
            }

            return stringBuilder.ToString();
        }

        public T GetObjectFromString<T>(string data)
        {
            Type TType = typeof(T);
            var properties = TType.GetProperties();
            var obj = Activator.CreateInstance<T>();

            var keyValueArr = data.Split(new char[] { ',' } , StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in properties)
            {
                item.SetValue(obj, Convert.ChangeType(FindValue(item.Name, keyValueArr), item.PropertyType));
            }

            return obj;
        }

        private object FindValue(string name, string[] keyValueArr)
        {
            foreach (var item in keyValueArr)
            {
                var pair = item.Split(new string[] { " : " }, StringSplitOptions.RemoveEmptyEntries);
                if (pair[0].Equals(name))
                {
                    if (pair[1].Equals("null"))
                    {
                        return null;
                    }

                    return pair[1];
                }
            }

            return null;
        }

        private static object GetStringRepresentation<T>(T obj, System.Reflection.PropertyInfo item)
        {
            if(item.GetValue(obj) == null)
            {
                return "null";
            }

            return item.GetValue(obj);
        }
    }
}
