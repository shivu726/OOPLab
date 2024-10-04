﻿using System;
using System.Collections.Generic;

namespace DbFirstDemoApp_Lab.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string? Title { get; set; }

    public int Credits { get; set; }

    public int? DepartmentId { get; set; }

    public virtual Department? Department { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
