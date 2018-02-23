using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Common.Domain.Model
{
    //public abstract class ValueObject<T> : IEquatable<T>  where T : class
    //{
    //    #region Equals
    //    public override bool Equals(object obj)
    //    {
    //        if (obj == null)
    //            return false;

    //        var other = obj as T;

    //        return Equals(other);
    //    }

    //    public override int GetHashCode()
    //    {
    //        IEnumerable<FieldInfo> fields = GetFields();

    //        const int startValue = 17;
    //        const int multiplier = 59;

    //        int hashCode = startValue;

    //        foreach (FieldInfo field in fields)
    //        {
    //            object value = field.GetValue(this);

    //            if (value != null)
    //                hashCode = hashCode * multiplier + value.GetHashCode();
    //        }

    //        return hashCode;
    //    } 
    //    #endregion

    //    private IEnumerable<FieldInfo> GetFields()
    //    {
    //        Type t = GetType();

    //        var fields = new List<FieldInfo>();

    //        while (t != typeof(object))
    //        {
    //            fields.AddRange(t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public));

    //            t = t.BaseType;
    //        }

    //        return fields;
    //    }

    //    public virtual bool Equals(T other)
    //    {
    //        if (other == null)
    //            return false;

    //        Type t = GetType();

    //        FieldInfo[] fields = t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

    //        foreach (FieldInfo field in fields)
    //        {
    //            object value1 = field.GetValue(other);
    //            object value2 = field.GetValue(this);

    //            if (value1 == null)
    //            {
    //                if (value2 != null)
    //                    return false;
    //            }
    //            else if (value2 == null)
    //            {
    //                return false;
    //            }
    //            else if (typeof(DateTime).IsAssignableFrom(field.FieldType) ||
    //                     typeof(DateTime?).IsAssignableFrom(field.FieldType))
    //            {
    //                string dateString1 = ((DateTime)value1).ToLongDateString();
    //                string dateString2 = ((DateTime)value2).ToLongDateString();

    //                if (!dateString1.Equals(dateString2))
    //                {
    //                    return false;
    //                }
    //            }
    //            else if (typeof(string).IsAssignableFrom(field.FieldType))
    //            {
    //                string string1 = value1.ToString();
    //                string string2 = value2.ToString();

    //                if (!string1.Equals(string2, StringComparison.OrdinalIgnoreCase))
    //                    return false;
    //            }
    //            else if (typeof(IEnumerable).IsAssignableFrom(field.FieldType))
    //            {
    //                var col1 = value1 as IEnumerable;
    //                var col2 = value2 as IEnumerable;

    //                if (col1 == null || col2 == null)
    //                    return false;

    //                var e1 = col1.GetEnumerator();
    //                var e2 = col2.GetEnumerator();
    //                while (e1.MoveNext() && e2.MoveNext())
    //                {
    //                    var item1 = e1.Current;
    //                    var item2 = e2.Current;

    //                    if (!item1.Equals(item2))
    //                        return false;
    //                }
    //            }
    //            else if (!value1.Equals(value2))
    //                return false;
    //        }

    //        return true;
    //    }
    //}

    [Serializable]
    public abstract class ValueObject<T> : IEquatable<T> where T : class
    {
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var other = obj as T;

            return Equals(other);
        }

        public override int GetHashCode()
        {
            IEnumerable<FieldInfo> fields = GetFields();

            const int startValue = 17;
            const int multiplier = 59;

            int hashCode = startValue;

            foreach (FieldInfo field in fields)
            {
                object value = field.GetValue(this);

                if (value != null)
                    hashCode = hashCode * multiplier + value.GetHashCode();
            }

            return hashCode;
        }

        public virtual bool Equals(T other)
        {
            if (other == null)
                return false;

            Type t = GetType();

            FieldInfo[] fields = t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (FieldInfo field in fields)
            {
                object value1 = null;
                try
                {
                    value1 = field.GetValue(other);
                }
                catch
                {
                    // Swallow this one, value1 is defaulted to null
                }
                object value2 = field.GetValue(this);

                if (value1 == null)
                {
                    if (value2 != null)
                        return false;
                }
                else if (value2 == null)
                {
                    return false;
                }
                else if ((typeof(DateTime).IsAssignableFrom(field.FieldType)) || ((typeof(DateTime?).IsAssignableFrom(field.FieldType))))
                {
                    var dateString1 = ((DateTime)value1).ToLongDateString();
                    var dateString2 = ((DateTime)value2).ToLongDateString();
                    if (!dateString1.Equals(dateString2))
                    {
                        return false;
                    }
                    continue;
                }
                else if (!value1.Equals(value2))
                    return false;
            }

            return true;
        }

        private IEnumerable<FieldInfo> GetFields()
        {
            Type t = GetType();

            var fields = new List<FieldInfo>();

            while (t != typeof(object))
            {
                fields.AddRange(t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public));

                t = t.BaseType;
            }

            return fields;
        }

        public static bool operator ==(ValueObject<T> x, ValueObject<T> y)
        {
            return x?.Equals(y) ?? y is null;
        }

        public static bool operator !=(ValueObject<T> x, ValueObject<T> y)
        {
            return !(x == y);
        }
    }
}
