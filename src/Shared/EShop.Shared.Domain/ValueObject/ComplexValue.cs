﻿using System.Reflection;

namespace EShop.Shared.Domain.ValueObject;

public abstract class ComplexValue : IEquatable<ComplexValue>
{
    private List<PropertyInfo>? _properties;

    private List<FieldInfo>? _fields;

    public abstract ComplexValue Of(params object[] args);

    public static bool operator ==(ComplexValue obj1, ComplexValue obj2)
    {
        if (Equals(obj1, null))
        {
            if (Equals(obj2, null))
            {
                return true;
            }

            return false;
        }

        return obj1.Equals(obj2);
    }

    public static bool operator !=(ComplexValue obj1, ComplexValue obj2)
    {
        return !(obj1 == obj2);
    }

    public bool Equals(ComplexValue? obj)
    {
        return Equals(obj as object);
    }
    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        return GetProperties().All(p => PropertiesAreEqual(obj, p))
            && GetFields().All(f => FieldsAreEqual(obj, f));
    }

    private IEnumerable<FieldInfo> GetFields()
    {
        if (_fields == null)
        {
            _fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(p => p.GetCustomAttribute(typeof(IgnoreMemberAttribute)) == null)
                .ToList();
        }

        return _fields;
    }

    private IEnumerable<PropertyInfo> GetProperties()
    {
        if (_properties == null)
        {
            _properties = GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => p.GetCustomAttribute(typeof(IgnoreMemberAttribute)) == null)
                .ToList();
        }

        return _properties;
    }

    private bool FieldsAreEqual(object obj, FieldInfo f)
    {
        return Equals(f.GetValue(this), f.GetValue(obj));
    }

    private bool PropertiesAreEqual(object obj, PropertyInfo p)
    {
        return Equals(p.GetValue(this, null), p.GetValue(obj, null));
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            foreach (var prop in GetProperties())
            {
                var value = prop.GetValue(this, null);
                hash = HashValue(hash, value);
            }

            foreach (var field in GetFields())
            {
                var value = field.GetValue(this);
                hash = HashValue(hash, value);
            }

            return hash;
        }
    }

    private int HashValue(int hash, object? value)
    {
        var currentHash = value?.GetHashCode() ?? 0;

        return hash * 23 + currentHash;
    }
}
