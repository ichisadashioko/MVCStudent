


namespace BKStudentMVC
{
    using BKStudentMVC.Models;
    using StudentLib.Services;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;

    public class ValidationRuleConfig
    {
        public static void Start()
        {
            IEnumerable<Type> ruleTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => typeof(IValidationRule).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

            foreach (var type in ruleTypes)
            {
                var rule = Activator.CreateInstance(type) as IValidationRule;

                var ruleModel = new RuleModel(rule);
                //Debug.WriteLine($"[ValidationRuleConfig.Start] Found {ruleModel}");

                var db = new RuleDBContext();
                if (db.RuleModels.Find(ruleModel.FullName) == null)
                {
                    db.RuleModels.Add(ruleModel);
                    db.SaveChanges();
                    Debug.WriteLine($"[ValidationRuleConfig.Start] Adding {ruleModel}");
                }
            }
        }
    }
}