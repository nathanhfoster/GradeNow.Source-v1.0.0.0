using System;
using AppStudio.DataProviders;

namespace GradeNow.Sections
{
    /// <summary>
    /// Implementation of the Courses1Schema class.
    /// </summary>
    public class Courses1Schema : SchemaBase
    {

        public string Title { get; set; }

        public string Category { get; set; }

        public string Weight { get; set; }

        public string Number { get; set; }

        public string Average { get; set; }
    }
}
