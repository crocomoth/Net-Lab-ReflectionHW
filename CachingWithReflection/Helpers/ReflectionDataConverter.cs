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
                stringBuilder.Append(item.Name + " : " + item.GetValue(obj));
            }

            return stringBuilder.ToString();
        }
    }
}
