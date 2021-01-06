using System;
using System.Collections.Generic;
using System.Text;

namespace Entity {
	public class DataType {

		/// <summary>
		/// –¼‘O
		/// </summary>
		private string _name;

		public string Name {
			get {
				return _name;
			}
			set {
				_name = value;
			}
		}

		private int _maximumLength;

		public int MaximumLength {
			get {
				return _maximumLength;
			}
			set {
				_maximumLength = value;
			}
		}

		private int _numericPrecision;

		public int NumericPrecision {
			get {
				return _numericPrecision;
			}
			set {
				_numericPrecision = value;
			}
		}

		private int _numericScale;

		public int NumericScale {
			get {
				return _numericScale;
			}
			set {
				_numericScale = value;
			}
		}

		private bool _isIdentity;

		public bool IsIdentity {
			get {
				return _isIdentity;
			}
			set {
				_isIdentity = value;
			}
		}

		private long _identitySeed;

		public long IdentitySeed {
			get {
				return _identitySeed;
			}
			set {
				_identitySeed = value;
			}
		}

		private long _identityIncrement;

		public long IdentityIncrement {
			get {
				return _identityIncrement;
			}
			set {
				_identityIncrement = value;
			}
		}
	
	}
}
