using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Univerisity_Project.Models
{
    public class DepartmentCourseCounter
    {
        [Key]
        public int Department { get; set; }
        public int CourseNumber { get; set; }
    }
}