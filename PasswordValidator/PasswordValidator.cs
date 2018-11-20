using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PasswordValidator
{
    public class PasswordValidator
    {
        private String password;

        const int pwMinLength = 8;
        const int pwMaxLength = 14;

        public PasswordValidator(String password)
        {
            this.password = password;
        }

        public String EvaluatePwStrength()
        {
            List<bool> validationList = new List<bool>();
            validationList.Add(CheckPwLength());
            validationList.Add(CheckForLowerCase());
            validationList.Add(CheckForUpperCase());
            validationList.Add(CheckForNumber());
            validationList.Add(CheckForSymbol());

            int passedValidations = 0;

            for(int i = 0; i < validationList.Count; i++)
            {
                if(validationList[i] == true)
                {
                    passedValidations++;
                }
            }

            if(passedValidations <= 3)
            {
                return "Weak";
            }
            else if(passedValidations == 4)
            {
                return "Average";
            }
            else
            {
                return "Strong";
            }
        }

        public bool CheckIfPwNotEmpty()
        {
            if(this.password.Length <= 0 || this.password == null)
            {
                return false;
            }

            return true;
        }

        public bool CheckPwLength()
        {
            if(this.CheckIfPwNotEmpty())
            {
                if (this.password.Length >= pwMinLength && this.password.Length <= pwMaxLength)
                {
                    return true;
                }
                else
                {
                    return false;
                } 
            }

            return false;
        }   
        
        public bool CheckForLowerCase()
        {
            if(this.CheckIfPwNotEmpty())
            {
                if(this.password.Any(char.IsLower))
                {
                    return true;
                } else
                {
                    return false;
                }
            }
            return false;
        }

        public bool CheckForUpperCase()
        {
            if (this.CheckIfPwNotEmpty())
            {
                if (this.password.Any(char.IsUpper))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public bool CheckForNumber()
        {
            if(CheckIfPwNotEmpty())
            {
                if(this.password.Any(char.IsDigit))
                {
                    return true;
                } else
                {
                    return false;
                }
            }
            return false;
        }

        public bool CheckForSymbol()
        {
            if(CheckIfPwNotEmpty())
            {
                Match match = Regex.Match(this.password, "[^a-z0-9]]");
                if(!match.Success)
                {
                    return true;
                } else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
//Teha parooli validaator, mis kontrollib, kas parool on nõrk, keskmine või tugev.
//Valideerimismeetorile antakse tingumused koos parooliga ette.

//parameetrid, mida valideerida:

//parooli pikkus
//kas parool sisaldab väikest tähte
//kas parool sisaldab suurt tähte
//kas parool sisaldab numbrit
//kas parool sisaldab sümbolit