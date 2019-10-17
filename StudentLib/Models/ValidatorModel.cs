using StudentLib.Services;
using System;
using System.Reflection;
using System.Text;
using System.Diagnostics;

namespace StudentLib.Models
{

    public partial class ValidatorModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public virtual bool InEffect
        {
            get
            {
                return IsInEffect();
            }
        }

        public ValidatorModel() { }
        public ValidatorModel(IValidationRule rule)
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

                // Comparing with null of type `DateTime?` always produces `false` (.NET behavior)

                var now = DateTime.Now;
                return StartDate > now || EndDate < now || (StartDate == null && EndDate == null);
            }
        }

        private bool IsInEffect()
        {
            return Active && DuringActiveTime;
        }
    }
}
