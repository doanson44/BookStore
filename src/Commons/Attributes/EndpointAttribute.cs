using System;

namespace Commons.Attributes;

public class EndpointAttribute : Attribute
{
    public string Name { get; set; }
}
