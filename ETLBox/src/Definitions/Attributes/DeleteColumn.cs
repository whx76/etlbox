﻿using System;

namespace ETLBox.DataFlow
{
    /// <summary>
    /// This attribute defines if the column is used to identify if the record is supposed to be deleted.
    /// If this attribute is set and the given value matches the column of the assigned property,
    /// the DbMerge will know that if the records matches (identifed by the IdColumn attribute)
    /// it should be deleted.
    /// </summary>
    /// <example>
    ///  public class MyPoco : MergeableRow
    /// {
    ///     [IdColumn]
    ///     public int Key { get; set; }
    ///     [UpdateColumn]
    ///     public string Value {get;set; }
    ///     [DeleteColumn(true)]
    ///     public bool IsDeletion {get;set; }
    /// }
    /// </example>
    [AttributeUsage(AttributeTargets.Property)]
    public class DeleteColumn : Attribute
    {
        /// <summary>
        /// Name of the property that is used to decide if a row is deleted 
        /// </summary>
        public string DeletePropertyName { get; set; }

        /// <summary>
        /// Marks this property as column used for a deletion check in a Merge operation
        /// </summary>
        public object DeleteOnMatchValue { get; set; }

        public DeleteColumn()
        {

        }

        /// <summary>
        /// Marks this property as column that is deleted if is equal the  <see cref="DeleteOnMatchValue"/>.
        /// </summary>
        /// <param name="deleteOnMatchValue">To be value for the property that identifes the row as deletion</param>
        public DeleteColumn(object deleteOnMatchValue)
        {
            DeleteOnMatchValue = deleteOnMatchValue;
        }
    }
}
