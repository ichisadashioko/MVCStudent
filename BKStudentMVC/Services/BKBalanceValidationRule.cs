using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentLib.Models;
using StudentLib.Services;
using StructureMap;
using System.Diagnostics;

namespace BKStudentMVC.Services
{
    public class BKBalanceValidationRule : IValidationRule
    {
        private static int numCalls = 0;
        private const decimal _requiredMoneyForHanoi = 500_000_000m;
        private const decimal _requiredMoneyForOtherProvinces = 300_000_000m;

        public BKBalanceValidationRule()
        {
            Debug.WriteLine($"[BKStudentMVC.Services.BKBalanceValidationRule] {this.GetType().FullName} numCalls={numCalls++}");
        }

        public int Order => 26;

        public virtual string Description => $"Students who are from Hanoi must have more than {_requiredMoneyForHanoi / 10e6m} million in their bank account. Otherwise, they must have more than {_requiredMoneyForOtherProvinces / 10e6m} million in their bank account";

        public bool Validate(Student student)
        {
            if (student.Province == Province.HaNoi && student.BankBalance > _requiredMoneyForHanoi)
            {
                return true;
            }

            return student.Province != Province.HaNoi && student.BankBalance > _requiredMoneyForOtherProvinces ? true : false;
        }
    }
}