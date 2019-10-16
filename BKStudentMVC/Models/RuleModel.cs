using StudentLib.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace BKStudentMVC.Models
{

    public partial class RuleModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public virtual bool InEffect { get { return IsInEffect(); } }

        public RuleModel() { }
        public RuleModel(IValidationRule rule)
        {
            FullName = rule.GetType().FullName;
            Description = rule.Description;
            Active = true;
        }
        public override string ToString()
        {
            Type objType = this.GetType();
            PropertyInfo[] propertyInfoList = objType.GetProperties();
            StringBuilder result = new StringBuilder();
            foreach (var propertyInfo in propertyInfoList)
            {
                result.Append($"{propertyInfo.Name}={propertyInfo.GetValue(this)}, ");
            }
            return result.ToString();
        }

        bool DuringActiveTime
        {
            get
            {
                // if `StartDate` is `null` and `EndDate` is `null` then return `true`
                // if `StartDate` is > `Now` then return `false`
                // if `StartDate` is `null` but `EndDate` < `Now` then return `false`

                //|       | null  | > Now | < Now |
                //|-------|-------|-------|-------|
                //| null  | TRUE  | FALSE | TRUE  |
                //| > Now | TRUE  | FALSE | TRUE  |
                //| < Now | FALSE | FALSE | FALSE |

                //|       | > Now | < Now |
                //|-------|-------|-------|
                //| > Now | FALSE | TRUE  |
                //| < Now | FALSE | FALSE |

                //|       | null  | > Now | < Now |
                //|-------|-------|-------|-------|
                //| null  | TRUE  | FALSE | TRUE  |
                //| > Now | TRUE  |       |       |
                //| < Now | FALSE |       |       |

                // Comparing with null of type `DateTime?` always produces `false` (.NET behaviour)

                var now = DateTime.Now;
                return StartDate > now || EndDate < now;
            }
        }

        private bool IsInEffect()
        {
            return Active && DuringActiveTime;
        }
    }
}
