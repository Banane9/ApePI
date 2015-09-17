using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ApePI
{
    /// <summary>
    /// Contains information about an Endpoint that is a property.
    /// </summary>
    //internal sealed class PropertyEndpoint : Endpoint<PropertyInfo>
    //{
    //    /// <summary>
    //    /// Gets whether it's possible to GET this endpoint.
    //    /// </summary>
    //    public bool CanGet
    //    {
    //        get { return Member.GetMethod == null ? false : !Member.GetMethod.IsPrivate; }
    //    }

    //    /// <summary>
    //    /// Gets whether it's possible to write information to this endpoint.
    //    /// </summary>
    //    public bool CanSet
    //    {
    //        get { return Member.SetMethod == null ? false : !Member.SetMethod.IsPrivate; }
    //    }

    //    /// <summary>
    //    /// Gets whether authentication is required to GET this endpoint.
    //    /// </summary>
    //    public bool GetRequiresAuth
    //    {
    //        get { return Member.GetMethod == null ? false : Member.GetMethod.IsAssembly; }
    //    }

    //    /// <summary>
    //    /// Gets whether authentication is required to write to this endpoint.
    //    /// </summary>
    //    public bool SetRequiresAuth
    //    {
    //        get { return Member.SetMethod == null ? false : Member.SetMethod.IsAssembly; }
    //    }

    //    public PropertyEndpoint(PropertyInfo propertyInfo)
    //    {
    //        Member = propertyInfo;
    //    }
    //}
}