using System;
using Generic.Models;

namespace Entities.Models;

public class TestRelation
{
    public Guid Id { get; set; }
    public Guid TestClassId { get; set; }
    public Guid TestStudentId { get; set; }

    public TestClass TestClass { get; set; }
    public TestStudent TestStudent { get; set; }
}