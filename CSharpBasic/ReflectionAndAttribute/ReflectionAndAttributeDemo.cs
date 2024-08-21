using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CSharpBasic.ReflectionAndAttribute
{
    public static class ReflectionAndAttributeDemo
    {

        /// <summary>
        /// Reflection and attributes in C# provide powerful mechanisms to inspect and manipulate code at runtime.Reflection allows you to 
        /// dynamically examine and interact with types, members, and objects, while attributes enable you to attach metadata to your code.
        /// </summary>
        /// <param name="obj"></param>
        public static void RefelectionUsesesDemo()
        {
            var person1 = new Person();
            // Reflection common useses
            //Obtaining Type Information. Aspecial Type here is Person class
            var type = typeof(Person);
            Type anotherType = person1.GetType();

            Console.WriteLine($"obtaining type: {type} and type  from GetType() method: {anotherType}");

            // Retrieving Members of a Type
            MethodInfo[] methods = type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            FieldInfo[] fields = type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            PropertyInfo[] properties = type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (MethodInfo me in methods)
            {
                Console.WriteLine($"Propertye from {type} : {me.Name}");
            }

            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine($"Propertye from {type} : {property.Name}");
            }

            // Creating instances dynamically
            object person2 = Activator.CreateInstance(type, new object[] { "Xuan", "DinhPhung", 26 });

            Console.WriteLine(JsonSerializer.Serialize(person2));

            // Invoking methods dynamically
            MethodInfo method = type.GetMethod("Walk");
            method.Invoke(person2, []);


            // Access and modify the private field 'Identity'
            FieldInfo field = type.GetField("Identity", BindingFlags.NonPublic | BindingFlags.Instance);
            if (field != null)
            {
                // Set the value of the 'Identity' field
                field.SetValue(person2, "PDXuan");

                // Get the value of the 'Identity' field
                var value = field.GetValue(person2);
                Console.WriteLine($"Identity: {value}");
            }
            else
            {
                Console.WriteLine("Field 'Identity' not found.");
            }
        }


        /// <summary>
        /// Just want to serialize FistName, LastName from Person Type
        /// </summary>
        public static void DoReflectionAndAttributeDemo()
        {

            var person = new Person { FirstName = "John", LastName = "Doe", Age = 30 };
            string serialized = CustomSerializer.Serialize(person);
            Console.WriteLine(serialized); // Output: FirstName: John, LastName: Doe

        }

    }




    /// <summary>
    /// Custom attribute for property 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class SerializablePropertyAttribute : Attribute { }


    /// <summary>
    /// A class use custom attribute 
    /// </summary>
    public class Person
    {

        [SerializableProperty]
        public string FirstName { get; set; }
        [SerializableProperty]
        public string LastName { get; set; }
        public int Age { get; set; } // Not serialized

        private string Identity;

        /// <summary>
        /// Just for demo.
        /// </summary>
        /// <returns></returns>
        public void Walk()
        {
            Console.WriteLine("Walk walk walk walk");
        }

        // Constructor with parameters
        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        // Default constructor
        public Person() { }
    }


    /// <summary>
    /// Handle customSerilizer using reflection 
    /// </summary>
    public class CustomSerializer
    {
        public static string Serialize(object obj)
        {
            var properties = obj.GetType().GetProperties().Where(p => p.GetCustomAttributes(typeof(SerializablePropertyAttribute), false).Any());
            var keyValuePairs = properties.Select(p => $"{p.Name}: {p.GetValue(obj)}");
            return string.Join(", ", keyValuePairs);
        }
    }



}
