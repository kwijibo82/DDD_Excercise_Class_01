using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Common.Domain.Model
{
    public abstract class Enumeration
    {
        public string Name { get; private set; }

        public string Id { get; private set; }

        protected Enumeration()
        {
        }

        protected Enumeration(string id, string name)
        {
            Requires.NotNullOrEmpty(id, nameof(id));
            Requires.NotNullOrEmpty(name, nameof(name));

            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public static IEnumerable<T> GetAll<T>() where T : Enumeration, new()
        {
            var type = typeof(T);
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            foreach (var info in fields)
            {
                var instance = new T();

                if (info.GetValue(instance) is T locatedValue)
                {
                    yield return locatedValue;
                }
            }
        }

        public static bool TryParse(TValue value, out TEnumeration result)
        {
            return TryParse(e => e.ValueEquals(value), out result);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Enumeration otherValue))
            {
                return false;
            }

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static T FromDisplayName<T>(string displayName) where T : Enumeration, new()
        {
            var matchingItem = Parse<T, string>(displayName, "display name", item => item.Name == displayName);
            return matchingItem;
        }

        private static T Parse<T, K>(K value, string description, Func<T, bool> predicate) where T : Enumeration, new()
        {
            var matchingItem = GetAll<T>().FirstOrDefault(predicate);

            if (matchingItem == null)
            {
                var message = string.Format("'{0}' is not a valid {1} in {2}", value, description, typeof(T));

                throw new InvalidOperationException(message);
            }

            return matchingItem;
        }
    }
}