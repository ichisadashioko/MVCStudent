


namespace BKStudentMVC
{
    using BKStudentMVC.Models;
    using StudentLib.Models;
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

            var db = new BKDBContext();
            foreach (var type in ruleTypes)
            {
                var rule = Activator.CreateInstance(type) as IValidationRule;

                var ruleModel = new ValidatorModel(rule);
                //Debug.WriteLine($"[ValidationRuleConfig.Start] Found {ruleModel}");

                ValidatorModel _ruleModel = db.ValidatorModels.SingleOrDefault(x => x.FullName == ruleModel.FullName);
                if (_ruleModel == null)
                {
                    Debug.WriteLine($"[ValidationRuleConfig.Start] Adding {ruleModel}");
                    db.ValidatorModels.Add(ruleModel);

                    db.SaveChanges();
                }
            }
            db.Dispose();
        }
    }
}