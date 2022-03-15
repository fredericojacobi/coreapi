using System;
using System.Collections.Generic;

namespace Entities.Models;

public class TestStudent
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public IEnumerable<TestRelation> TestRelations { get; set; }

}