// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace BKStudentMVC.DependencyResolution
{
    using BKStudentMVC.Models;
    using BKStudentMVC.Services;
    using StructureMap;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
    using StudentLib.Repository;
    using StudentLib.Services;
    using System;
    using System.Reflection;

    public class DefaultRegistry : Registry
    {
        #region Constructors and Destructors

        public DefaultRegistry()
        {
            Scan(
                scan =>
                {
                    scan.AssemblyContainingType<IValidationRule>();
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.AddAllTypesOf<IValidationRule>();
                    scan.With(new ControllerConvention());
                    scan.With(new SingletonConvention<IValidationRule>());
                });
            //For<IExample>().Use<Example>();
            //For<IRuleDataService>().Singleton().Use<RuleDataService>();
            For<StudentDBContext>().Use<BKDBContext>();
            For<IRuleDataService>().Use<ValidatorDataService>();
            For<IValidationService>().Use<ValidationService>();
        }

        #endregion
    }
}