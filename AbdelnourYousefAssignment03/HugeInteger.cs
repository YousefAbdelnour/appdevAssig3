using System;
using System.Linq;

namespace AbdelnourYousefAssignment03
{
    internal class HugeInteger
    {
        private int[] digits;
        public HugeInteger(String n)
        {
            int[] tempDigits = Array.ConvertAll(n.ToString().ToCharArray(), c => (int)c - '0');
            this.Digits = tempDigits;
        }
        public int[] Digits
        {
            get { return digits; }
            set
            {
                digits = new int[40];
                int offset = 40 - value.Length;
                for (int i = 0; i < value.Length; i++)
                {
                    digits[offset + i] = (value[i]);
                }
            }
        }



        public bool IsEqualTo(HugeInteger value)
        {
            for (int i = 0; i < value.Digits.Length; i++)
            {
                if (value.Digits[i] != this.Digits[i])
                {
                    return false;
                }
            }
            return true;
        }
        public bool IsNotEqualTo(HugeInteger value)
        {
            for (int i = 0; i < value.Digits.Length; i++)
            {
                if (value.Digits[i] != this.Digits[i])
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsGreaterThan(HugeInteger value)
        {
            for (int i = Digits.Length - 1; i >= 0; i--)
            {
                if (Digits[i] > value.Digits[i])
                {
                    return true;
                }
                else if (Digits[i] < value.Digits[i])
                {
                    return false;
                }
            }
            return false;
        }
        public bool IsLessThan(HugeInteger value)
        {
            for (int i = Digits.Length - 1; i >= 0; i--)
            {
                if (Digits[i] > value.Digits[i])
                {
                    return false;
                }
                else if (Digits[i] < value.Digits[i])
                {
                    return true;
                }
            }
            return true;
        }
        public bool IsGreaterThanOrEqualTo(HugeInteger value)
        {
            for (int i = Digits.Length - 1; i >= 0; i--)
            {
                if (Digits[i] > value.Digits[i])
                {
                    return true;
                }
                else if (Digits[i] < value.Digits[i])
                {
                    return false;
                }
            }
            return true;
        }
        public bool IsLessThanOrEqualTo(HugeInteger value)
        {
            for (int i = Digits.Length - 1; i >= 0; i--)
            {
                if (Digits[i] > value.Digits[i])
                {
                    return false;
                }
                else if (Digits[i] < value.Digits[i])
                {
                    return true;
                }
            }
            return true;
        }
        public bool IsZero()
        {
            for (int i = 0; i < 40; i++)
            {
                if (Digits[i] != 0)
                {
                    return false;
                }
            }
            return true;
        }
        public HugeInteger Add(HugeInteger value)
        {
            var result = new int[40];
            int carry = 0;

            for (int i = 39; i >= 0; i--)
            {
                int sum = this.Digits[i] + value.Digits[i] + carry;
                result[i] = sum % 10;
                carry = sum / 10;
            }

            string resultStr = string.Join("", result.Reverse());
            return new HugeInteger(resultStr);
        }


        public HugeInteger Subtract(HugeInteger value)
        {
            HugeInteger larger = this.IsGreaterThan(value) ? this : value;
            HugeInteger smaller = this.IsGreaterThan(value) ? value : this;

            var str = "";
            int borrow = 0;

            for (int i = 39; i >= 0; i--)
            {
                int num = larger.Digits[i] - smaller.Digits[i] - borrow;

                if (num < 0)
                {
                    borrow = 1;
                    num += 10;
                }
                else
                {
                    borrow = 0;
                }
                str = str + num.ToString();
            }

            return new HugeInteger(str);
        }

        public HugeInteger Multiply(HugeInteger value)
        {
            int[] result = new int[80];

            for (int i = 39; i >= 0; i--)
            {
                for (int j = 39; j >= 0; j--)
                {
                    int product = this.Digits[i] * value.Digits[j];
                    int index = i + j + 1;
                    result[index] += product % 10;
                    result[index - 1] += product / 10 + result[index] / 10;
                    result[index] %= 10;
                }
            }
            string resultStr = string.Join("", result.SkipWhile(x => x == 0).Take(40));
            if (string.IsNullOrEmpty(resultStr)) resultStr = "0";

            return new HugeInteger(resultStr);
        }
        public HugeInteger Divide(HugeInteger divisor)
        {
            if (!divisor.IsZero())
            {
                if (this.IsLessThan(divisor))
                {
                    return new HugeInteger("0");
                }

                int i = 1;
                HugeInteger divided = new HugeInteger("0");
                while (this.IsGreaterThanOrEqualTo(divided))
                {
                    divided = divided.Add(divisor);
                    i++;
                }
                return new HugeInteger(i + "");
            }
            else
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
        }


        public string ToString()
        {
            string str = "";
            bool pre = true;
            for (int i = 0; i < 40; i++)
            {
                if (Digits[i] == 0)
                {
                    if (pre)
                    {
                        continue;
                    }
                    else
                    {
                        str = str + Digits[i];
                    }
                }
                else
                {
                    pre = false;
                    str = str + Digits[i];
                }
            }
            return str;
        }
    }
}