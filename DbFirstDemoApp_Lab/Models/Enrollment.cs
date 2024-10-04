﻿using System;
using System.Collections.Generic;

namespace DbFirstDemoApp_Lab.Models;

public partial class Enrollment
{
    public int EnrollmentId { get; set; }

    public int? CourseId { get; set; }

    public int? StudentId { get; set; }

    public int? Grade { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Student? Student { get; set; }
}
