using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Business.Models.Validations
{
    public class CpfValidation
    {
        public const int LengthCpf = 11;

        public static bool Validate(string cpf)
        {
            var cpfNumbers = Utils.OnlyNumbers(cpf);

            if (!ValidLength(cpfNumbers)) return false;
            return !HasRepeatedDigit(cpfNumbers) && HasValidDigit(cpfNumbers);
        }

        private static bool ValidLength(string valor)
        {
            return valor.Length == LengthCpf;
        }

        private static bool HasRepeatedDigit(string value)
        {
            string[] invalidNumbers =
            {
                "00000000000",
                "11111111111",
                "22222222222",
                "33333333333",
                "44444444444",
                "55555555555",
                "66666666666",
                "77777777777",
                "88888888888",
                "99999999999"
            };
            return invalidNumbers.Contains(value);
        }

        private static bool HasValidDigit(string value)
        {
            var number = value.Substring(0, LengthCpf - 2);
            var verifyingDigit = new DigitVerifying(number)
                .WithMultipliersFromTo(2, 11)
                .Replacing("0", 10, 11);
            var firstDigit = verifyingDigit.CalculateDigit();
            verifyingDigit.AddDigit(firstDigit);
            var secondDigit = verifyingDigit.CalculateDigit();

            return string.Concat(firstDigit, secondDigit) == value.Substring(LengthCpf - 2, 2);
        }
    }
    
    public class DigitVerifying
    {
        private string _number;
        private const int Module = 11;
        private readonly List<int> _multipliers = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9 };
        private readonly IDictionary<int, string> _replacements = new Dictionary<int, string>();
        private bool _completeFromModule = true;

        public DigitVerifying(string numero)
        {
            _number = numero;
        }

        public DigitVerifying WithMultipliersFromTo(int primeiroMultiplicador, int ultimoMultiplicador)
        {
            _multipliers.Clear();
            for (var i = primeiroMultiplicador; i <= ultimoMultiplicador; i++)
                _multipliers.Add(i);

            return this;
        }

        public DigitVerifying Replacing(string substituto, params int[] digitos)
        {
            foreach (var i in digitos)
            {
                _replacements[i] = substituto;
            }
            return this;
        }

        public void AddDigit(string digito)
        {
            _number = string.Concat(_number, digito);
        }

        public string CalculateDigit()
        {
            return !(_number.Length > 0) ? "" : GetDigitSum();
        }

        private string GetDigitSum()
        {
            var sum = 0;
            for (int i = _number.Length - 1, m = 0; i >= 0; i--)
            {
                var product = (int)char.GetNumericValue(_number[i]) * _multipliers[m];
                sum += product;

                if (++m >= _multipliers.Count) m = 0;
            }

            var mod = (sum % Module);
            var resultado = _completeFromModule ? Module - mod : mod;

            return _replacements.ContainsKey(resultado) ? _replacements[resultado] : resultado.ToString();
        }
    }

    public class Utils
    {
        public static string OnlyNumbers(string valor)
        {
            var onlyNumber = "";
            foreach (var s in valor)
            {
                if (char.IsDigit(s))
                {
                    onlyNumber += s;
                }
            }
            return onlyNumber.Trim();
        }
    }

}

