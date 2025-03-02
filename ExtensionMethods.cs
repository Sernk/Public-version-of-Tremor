using System;
using System.Linq;
using System.Reflection;

public static class ExtensionMethods
{
    public static string FindNameByConstant(this Type type, ushort constant)
    {
        return type.GetFields(BindingFlags.Public | BindingFlags.Static)
                   .FirstOrDefault(f => f.GetRawConstantValue() is ushort value && value == constant)?
                   .Name;
    }
}
