using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    class FormSettings
    {
        //These are boxes filled in that are either on or off
        public bool StatutoryEmployee, RetirementPlan, ThirdPartySickPay, Void;
        public string EmployerAddressZIP, LocalityName, LocalIncomeTax, LocalWagesTipsEtc,
                      StateIncomeTax, StateWagesTipsEtc, EmployersStateID,
                      _9, _7, _5, _3, _1, _2, _4, _6, _8, _10, _12c, _12d,
                      _11, _12b_header, _12c_header, _12d_header, _12a_header,
                      EIN, SSN, Other, FirstName, LastName, ControlNumber,
                      Suff, _12a, _12b, NameAddressZIP, State; 


        public bool GetFieldBool(string str)
        {
            bool temp = (bool)typeof(FormSettings).GetField(str).GetValue(this);
            return temp;
        }
        public string GetFieldString(string str)
        {
            string temp = (string)typeof(FormSettings).GetField(str).GetValue(this);
            if (temp == null)
            {
                temp = "";
            }
            return temp;
        }
        //Provides test data
        public void Populate()
        {
            StatutoryEmployee = true;
            RetirementPlan = false;
            ThirdPartySickPay = true;
            Void = true;

            EmployerAddressZIP = "Employer Address ZIP";
            LocalIncomeTax = "$2000";
            LocalityName = "Locality name";
            LocalWagesTipsEtc = "Wages tips";

            StateIncomeTax = "$100";
            StateWagesTipsEtc = "$200";
            EmployersStateID = "State ID";

            _1 = "Wages, tips and other";
            _2 = "Federal income";
            _3 = "Social security wages";
            _4 = "SS withheld";
            _5 = "Medicare wages and tips";
            _6 = "Medicare tax withheld";
            _7 = "Social security tips";
            _8 = "Allocated tips";
            _9 = "";
            _10 = "Dependent care";
            _11 = "Nonqualified";
            _12a = "12a";
            _12b = "12b";
            _12c = "12c";
            _12d = "12d";

            _12a_header = "A";
            _12b_header = "B";
            _12c_header = "C";
            _12d_header = "D";

            EIN = "EIN";
            SSN = "SSN";
            Other = "Other";
            FirstName = "First name";
            LastName = "Last name";
            ControlNumber = "Control number";
            Suff = "Mr.";
            NameAddressZIP = "Name\nAddress\nZIP";
            State = "CA";
        }
    }
}
