using System;

namespace LinqToExcel.Attributes
{
    /// <summary>
    /// Represents an attribute used to map properties to Excel column names.
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = true)]
    public sealed class ExcelColumnAttribute : Attribute
    {
        private readonly string _columnName;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelColumnAttribute"/> class.
        /// </summary>
        /// <param name="columnName">The name of the column.</param>
        public ExcelColumnAttribute(string columnName)
        {
            _columnName = columnName;
        }

        /// <summary>
        /// Gets the name of the column.
        /// </summary>
        /// <value>
        /// The name of the column.
        /// </value>
        public string ColumnName
        {
            get { return _columnName; }
        }

    }
}
