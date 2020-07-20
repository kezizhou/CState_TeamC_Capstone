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

		public static HashSalt GenerateSaltedHash(int size, string password) {
			var saltBytes = new byte[size];
			var provider = new RNGCryptoServiceProvider();
			provider.GetNonZeroBytes(saltBytes);
			var salt = Convert.ToBase64String(saltBytes);

			var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 10000);
			var hashPassword = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

			HashSalt hashSalt = new HashSalt { Hash = hashPassword, Salt = salt };
			return hashSalt;
		}

		public static bool VerifySaltedHash(string strEntered, string strStoredHash, string strStoredSalt) {
			var saltBytes = Convert.FromBase64String(strStoredSalt);
			var rfc2898DeriveBytes = new Rfc2898DeriveBytes(strEntered, saltBytes, 10000);
			return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256)) == strStoredHash;
		}

		public static byte[] GetHash(string inputString) {
			using (HashAlgorithm algorithm = SHA256.Create())
				return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
		}

		public static string GenerateHashString(string strInput) {
			StringBuilder sb = new StringBuilder();
			foreach (byte b in GetHash(strInput))
				sb.Append(b.ToString("X2"));

			return sb.ToString();
		}

		public static bool CompareHashes(string strHash1, string strHash2) {
			bool blnEqual = false;

			int i = 0;
			while ((i < strHash1.Length) && strHash1[i] == strHash2[i]) {
				i += 1;
			}
			if (i == strHash1.Length) {
				blnEqual = true;
			}

			return blnEqual;
		}
	}
}