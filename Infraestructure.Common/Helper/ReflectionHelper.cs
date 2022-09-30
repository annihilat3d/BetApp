using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Common.Helper
{
    public class ReflectionHelper
    {
        public static string[] SetFilesUpdate<T>(T model)
        {
            var properties = model.GetType().GetProperties();
            List<string> files = new List<string>();
            foreach (var property in properties)
            {
                if (property.GetValue(model) != null &&
                    property.CustomAttributes.Any(c => c.AttributeType == typeof(FirestorePropertyAttribute)))
                {
                    if (property.PropertyType == typeof(Timestamp))
                    {
                        if ((Timestamp)property.GetValue(model) > new Timestamp())
                        {
                            files.Add(property.Name);
                        }
                    }
                    else
                    {
                        files.Add(property.Name);
                    }
                }
            }
            return files.ToArray();
        }
    }
}
