using System;
namespace Psi.Compiler
{
	internal static class Extensions
	{
		public static T NotNull<T>(this T value)
			where T : class
			=> NotNull<T>(value, null);
	
		public static T NotNull<T>(this T value, string name)
			where T : class
		{
			if (value == null)
			{
				if(name != null)
					throw new ArgumentNullException(name);
				else
					throw new ArgumentNullException();
			}
			return value;
		}
		
		
		public static T? NotNull<T>(this T? value)
			where T : struct
			=> NotNull<T>(value, null);
	
		public static T? NotNull<T>(this T? value, string name)
			where T : struct
		{
			if (value == null)
			{
				if(name != null)
					throw new ArgumentNullException(name);
				else
					throw new ArgumentNullException();
			}
			return value;
		}
	}
}
