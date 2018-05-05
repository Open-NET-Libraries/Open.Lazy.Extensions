/*!
 * @author electricessence / https://github.com/electricessence/
 * Licensing: MIT https://github.com/electricessence/Open/blob/dotnet-core/LICENSE.md
 */

using System.Diagnostics.Contracts;
using System.Threading;

namespace System
{
	public static class Lazy
	{
		public static Lazy<T> Create<T>(Func<T> factory, LazyThreadSafetyMode mode = LazyThreadSafetyMode.ExecutionAndPublication)
		{
			if (factory == null)
				throw new ArgumentNullException(nameof(factory));
			Contract.EndContractBlock();

			return new Lazy<T>(factory, mode);
		}
	}
}
