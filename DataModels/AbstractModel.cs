using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace ThesisPrototype
{
    public abstract class AbstractModel
    {
        public string GetPrimaryKeyFieldName()
        {
            var publicProperties = this.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var publicFields = this.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);

            if (publicProperties.Any(p => Attribute.IsDefined(p, typeof(IsPrimaryKey))))
            {
                return publicProperties.Single(p=> Attribute.IsDefined(p, typeof(IsPrimaryKey))).Name;
            }
            else if (publicFields.Any(pf => Attribute.IsDefined(pf, typeof(IsPrimaryKey))))
            {
                return publicFields.Single(pf => Attribute.IsDefined(pf, typeof(IsPrimaryKey))).Name;
            }
            else throw new Exception("Model must have primary key, using [IsPrimaryKey] attribute");
        }

        // Is used to map the variable names (column names in the DB) to the appropriate variable values within the class.
        // IE. if a model has a property called Id that contains the value for the "Identifier" column, you would have { "Identifier", this.Id } 
        public Dictionary<string, object> GetFieldsWithValues()
        {
            var type = this.GetType();
            var propertiesOfThisModel = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var ret = propertiesOfThisModel.ToDictionary(key => key.Name, value => value.GetValue(this));
            return ret;
        }
    }
}