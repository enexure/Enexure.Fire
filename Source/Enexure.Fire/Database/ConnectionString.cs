using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enexure.Fire.Formatting;

namespace Enexure.Fire.Database
{
	/// <summary>
	/// Represents a connection string and allows easy manipulation of values
	/// </summary>
	public class ConnectionString : DynamicObject, IDictionary<string, string>
	{
		private bool isDirty = false;
		private string cachedValue = null;

		private readonly Dictionary<string, string> parts = new Dictionary<string, string>();

		/// <summary>Creates a new empty ConnectionString</summary>
		public ConnectionString()
		{
		}

		/// <summary>Creates a new ConnectionString</summary>
		/// <param name="value">Connection string to use as the initial cachedValue</param>
		public ConnectionString(string value)
		{
			Value = value;
		}

		public override bool TrySetMember(SetMemberBinder binder, object value)
		{
			this[binder.Name] = value != null ? value.ToString() : null;
			return true;
		}

		public override bool TryGetMember(GetMemberBinder binder, out object result)
		{
			result = this[binder.Name];
			return true;
		}

		/// <summary>Gets the string representation of the conncetion string</summary>
		/// <returns>The connection string</returns>
		public string Value
		{
			get { return GetConnectionString(); }
			set { SetConnectionString(value); }
		}

		private string GetConnectionString()
		{
			if (isDirty) {
				var builder = new StringBuilder();
				foreach (var item in parts) {
					builder.AppendFormat("{0}={1};", item.Key, item.Value);
				}
				cachedValue = builder.ToString();
			}
			return cachedValue;
		}

		private void SetConnectionString(string connectionString)
		{
			this.cachedValue = connectionString;
			this.isDirty = false;

			// TODO: Actually parse properly
			var partList = connectionString.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
			foreach (var item in partList) {
				var pair = item.Split(new[] {'='}, StringSplitOptions.RemoveEmptyEntries);
				if (pair.Length == 2) {
					var key = pair[0].Trim().ToLowerInvariant();
					var val = pair[1].Trim();

					this[key] = val;
				}
			}

		}

		/// <summary>Sets or gets any part of the connection string</summary>
		/// <param name="key">The key of the cachedValue to retrive or set</param>
		/// <returns>The current cachedValue for the key</returns>
		public string this[string key]
		{
			get
			{
				key = key.ToLowerInvariant();

				if (parts.ContainsKey(key)) {
					return parts[key];
				} else {
					return null;
				}
			}
			set
			{
				key = key.ToLowerInvariant();

				if (parts.ContainsKey(key)) {
					parts[key] = value;
				} else {
					if (IsKeyNameValid(key)) {
						parts.Add(key, value);
					} else {
						throw new KeyNotValidException(key);
					}
				}
				this.isDirty = true;
			}
		}

		private static bool IsKeyNameValid(string keyname)
		{
			if (keyname == null) {
				return false;
			}
			return (((
				  (0 < keyname.Length) 
				  && (';' != keyname[0])) 
				 && !char.IsWhiteSpace(keyname[0])) 
				&& (-1 == keyname.IndexOf('\0')));
		}

		/// <summary>Gets the string representation of the conncetion string</summary>
		/// <returns>The connection string</returns>
		public override string ToString()
		{
			return Value;
		}

		public static implicit operator string(ConnectionString connectionString)
		{
			return connectionString.ToString();
		}

		public static implicit operator ConnectionString(string connectionString)
		{
			return new ConnectionString(connectionString);
		}

		#region IDictionary

		public void Add(string key, string value)
		{
			this[key] = value;
		}

		public bool ContainsKey(string key)
		{
			return this[key] != null;
		}

		public ICollection<string> Keys
		{
			get { return parts.Keys; }
		}

		public bool Remove(string key)
		{
			if (ContainsKey(key)) {
				this[key] = null;
				return true;
			} else {
				return false;
			}
		}

		public bool TryGetValue(string key, out string value)
		{
			value = this[key];
			return value != null;
		}

		public ICollection<string> Values
		{
			get { return parts.Values; }
		}

		public void Add(KeyValuePair<string, string> item)
		{
			throw new NotSupportedException();
		}

		public void Clear()
		{
			parts.Clear();
			cachedValue = "";
			isDirty = false;
		}

		public bool Contains(KeyValuePair<string, string> item)
		{
			throw new NotSupportedException();
		}

		public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
		{
			throw new NotSupportedException();
		}

		public int Count
		{
			get { return parts.Count; }
		}

		public bool IsReadOnly
		{
			get { return false; }
		}

		public bool Remove(KeyValuePair<string, string> item)
		{
			throw new NotSupportedException();
		}

		public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
		{
			return parts.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return parts.GetEnumerator();
		}

		#endregion

	}

	public class KeyNotValidException : Exception
	{
		public KeyNotValidException(string key)
			: base(ExceptionMessages.Enexure_Fire_Database_ConnectonString_KeyNotValid.FormatWith(key))
		{
		}
	}
}
