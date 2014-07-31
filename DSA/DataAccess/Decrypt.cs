﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace DataAccess
{
    public class Decrypt
    {
        private byte[] KEY_192;
        private byte[] IV_192;

        public Decrypt()
        {
            KEY_192 = new byte[] {
				21,12,2,1,
				5,30,34,78,98,1,32,122,
				123,124,125,126,212,212,213,214
			};

            IV_192 = new byte[]  
			{
				1,2,3,4,5,12,13,14,
				13,14,15,13,17,21,22,23,
				24,25,121,122,122,123,124,124
			};
        }

        public String DecryptTripleDES(String vl, string key)
        {
            //decrypt

            byte[] pinNumber = Encoding.UTF8.GetBytes(key);
            byte[] KeyWithSecret = new byte[KEY_192.Length + pinNumber.Length];
            Array.Copy(pinNumber, KeyWithSecret, pinNumber.Length);
            Array.Copy(KEY_192, 0, KeyWithSecret, pinNumber.Length, KEY_192.Length);

            if (vl != "")
            { //if
                try
                {
                    TripleDESCryptoServiceProvider cryptoprovider = new TripleDESCryptoServiceProvider();
                    Byte[] buffer = Convert.FromBase64String(vl);
                    MemoryStream ms = new MemoryStream(buffer);
                    CryptoStream cs = new CryptoStream(ms, cryptoprovider.CreateDecryptor(KeyWithSecret, IV_192), CryptoStreamMode.Read);
                    StreamReader sw = new StreamReader(cs);
                    return sw.ReadToEnd();
                }
                catch (Exception ex)
                {
                    return null;
                    
                }


            } //if
            return "";
        } //decrypt
    }
}
