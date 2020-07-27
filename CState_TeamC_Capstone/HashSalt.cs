using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace CState_TeamC_Capstone {
	public class HashSalt {
		public string Hash { get; set; }
		public string Salt { get; set; }

		public static HashSalt GenerateSaltedHash(int size, string strPassword) {
			var saltBytes = new byte[size];

			var provider = new RNGCryptoServiceProvider();
			provider.GetNonZeroBytes(saltBytes);
			string strSalt = Convert.ToBase64String(saltBytes);

			string strSaltHash = GenerateHashString(strPassword + strSalt);

			HashSalt hashSalt = new HashSalt { Hash = strSaltHash, Salt = strSalt };
			return hashSalt;
		}

		public static bool VerifySaltedHash(string strEntered, string strStoredHash, string strStoredSalt) {
			string strNewSaltHash = GenerateHashString(strEntered + strStoredSalt);
			
			if (strNewSaltHash.Equals(strStoredHash)) {
				return true;
			} else {
				return false;
			}
		}

		public static string GenerateHashString(string strInput) {
			string strHashString = "";

			// Create a SHA256   
			using (SHA256 sha256Hash = SHA256.Create()) {
				// ComputeHash - returns byte array  
				byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(strInput));
				strHashString = Convert.ToBase64String(bytes);
			}

			return strHashString;
		}
	}
}