using System;
using System.Collections.Generic;
using Generic.Models;

namespace Entities.Models;

public class TestClass
{
    public Guid Id { get; set; }
    public int Code { get; set; }
    public string Name { get; set; }
    
    public IEnumerable<TestRelation> TestRelations { get; set; }
}