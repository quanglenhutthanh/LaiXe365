﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;

namespace code.Utilities
{
    public class EditString
    {
        public static string BoDauTrenChuoi(string input)
        {
            const string FindText = "áàảãạâấầẩẫậăắằẳẵặđéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶĐÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴ ,./;'<>?:{}[]\\|`~!@$%^&*()=+\"";
            const string ReplText = "aaaaaaaaaaaaaaaaadeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyyaaaaaaaaaaaaaaaaadeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyy-------------------------------";
            string output = "";
            foreach (char c in input)
            {
                if (FindText.IndexOf(c) >= 0)
                {
                    output += ReplText[FindText.IndexOf(c)];
                }
                else
                    output += c;

            }
            output = Regex.Replace(output, @"\-+", "-", RegexOptions.Multiline);
            while (output[0].ToString().Equals("-"))
            {
                output = output.Substring(1, output.Length - 1);
            }
            while (output[output.Length - 1].ToString().Equals("-"))
            {
                output = output.Substring(0, output.Length - 1);
            }
            return output;
        }
        static public string mahoa_md5(string input)
        {
            string str_md5 = "";
            byte[] array = System.Text.Encoding.UTF8.GetBytes(input);
            MD5CryptoServiceProvider _md5 = new MD5CryptoServiceProvider();
            array = _md5.ComputeHash(array);
            foreach (byte b in array)
            {
                str_md5 += b.ToString();
            }

            return str_md5;

        }
    }
}