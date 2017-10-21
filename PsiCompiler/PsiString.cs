using System;
using System.Text;

namespace PsiCompiler
{
	public static class PsiString
	{
		public static string Unescape(string escaped)
		{
			var original = new StringBuilder(escaped.Length);
			for (int i = 0; i < escaped.Length;)
			{
				if (escaped[i] != '\\')
				{
					original.Append(escaped[i++]);
					continue;
				}
				switch (escaped[++i])
				{
					case 'a':
						++i; original.Append(char.ConvertFromUtf32(0x07));
						break;
					case 'b':
						++i; original.Append(char.ConvertFromUtf32(0x08));
						break;
					case 'f':
						++i; original.Append(char.ConvertFromUtf32(0x0C));
						break;
					case 'n':
						++i; original.Append(char.ConvertFromUtf32(0x0A));
						break;
					case 'r':
						++i; original.Append(char.ConvertFromUtf32(0x0D));
						break;
					case 't':
						++i; original.Append(char.ConvertFromUtf32(0x09));
						break;
					case 'v':
						++i; original.Append(char.ConvertFromUtf32(0x0B));
						break;
					case 'e':
						++i; original.Append(char.ConvertFromUtf32(0x1B));
						break;
					case '\\':
						++i; original.Append(char.ConvertFromUtf32(0x5C));
						break;
					case '\'':
						++i; original.Append(char.ConvertFromUtf32(0x27));
						break;
					case '\"':
						++i; original.Append(char.ConvertFromUtf32(0x22));
						break;
					
					case '0':
					case '1':
					case '2':
					case '3':
					case '4':
					case '5':
					case '6':
					case '7':
						original.Append(char.ConvertFromUtf32(Convert.ToInt32(
							escaped.Substring(i, 3),
							8)));
						i += 3;
						break;
					
					case 'x':
						++i;
						original.Append(char.ConvertFromUtf32(Convert.ToInt32(
							escaped.Substring(i, 2),
							16)));
						i += 2;
						break;
					
					case 'u':
						++i;
						original.Append(char.ConvertFromUtf32(Convert.ToInt32(
							escaped.Substring(i, 4),
							16)));
						i += 4;
						break;
					
					case 'U':
						++i;
						original.Append(char.ConvertFromUtf32(Convert.ToInt32(
							escaped.Substring(i, 8),
							16)));
						i += 8;
						break;

					default:
						original.Append(escaped[i++]);
						break;
				}
			}
			return original.ToString();
		}
	}
}
