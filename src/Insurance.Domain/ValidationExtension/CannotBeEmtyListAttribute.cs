using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Insurance.Domain.ValidationExtension
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CannotBeEmtyListAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            var list = value as IList;
            return list != null && list.Count != 0;
        }
    }
}
