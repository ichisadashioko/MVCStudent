


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

            var db = new RuleDBEntities();
            foreach (var type in ruleTypes)
            {
                var rule = Activator.CreateInstance(type) as IValidationRule;

                var ruleModel = new RuleModel(rule);
                //Debug.WriteLine($"[ValidationRuleConfig.Start] Found {ruleModel}");

                RuleModel _ruleModel = db.RuleModels.SingleOrDefault(x => x.FullName == ruleModel.FullName);
                if (_ruleModel == null)
                {
                    Debug.WriteLine($"[ValidationRuleConfig.Start] Adding {ruleModel}");
                    //db.RuleModels.Add(ruleModel);
                    //db.Database.ExecuteSqlCommand($"INSERT INTO RuleModels(FullName, Description, Active, StartDate, EndDate) VALUES ({ruleModel.FullName}, {ruleModel.Description}, {ruleModel.Active}, {ruleModel.StartDate}, {ruleModel.EndDate})");
                    db.Database.ExecuteSqlCommand("INSERT INTO RuleModels(FullName, Description, Active, StartDate, EndDate) VALUES ({0}, {1}, {2}, {3}, {4})", ruleModel.FullName, ruleModel.Description, ruleModel.Active, ruleModel.StartDate, ruleModel.EndDate);
                    //SqlCommand cmd = new SqlCommand()
                    db.SaveChanges();
                }
            }
            db.Dispose();
        }
    }
}